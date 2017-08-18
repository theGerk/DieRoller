using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceRoller.Token;

namespace DiceRoller
{
	class SyntaxTreeGenerator
	{
		public static Expression Generate(IEnumerator<Token> tokens)
		{
			return new SyntaxTreeGenerator(tokens).Expression();
		}

		protected SyntaxTreeGenerator(IEnumerator<Token> tokens)
		{
			this.tokens = tokens;
			this.tokens.MoveNext();
		}

		IEnumerator<Token> tokens;

		IEnumerable<Expression> Expressions()
		{
			while (tokens.Current.Type != TokenType.Exception)
				yield return Expression();
		}
		

		private static void PopHigherPrecidenceOperators(Operator op, Stack<Operator> opStack, Stack<Expression> exprStack)
		{
			while (opStack.Count > 0 && (op.Precidence > opStack.Peek().Precidence || (op.Precidence == opStack.Peek().Precidence && op.Associativity == OperatorAssociativity.Left))) {
				PushOperationToExpressionStack(opStack.Pop(), exprStack);

			}
		}

		private static void PushOperationToExpressionStack(Operator op, Stack<Expression> exprStack)
		{
			switch (op.Identification.Type) {
				case OperatorType.PrefixUnary:
				case OperatorType.PostfixUnary:
					exprStack.Push(UnaryOperation.Create(op.Identification, exprStack.Pop()));
					break;
				case OperatorType.InfixBinary:
					exprStack.Push(BinaryOperation.Create(op.Identification, exprStack.Pop(), exprStack.Pop()));
					break;
			}
		}

		Expression Expression()
		{
			Stack<Operator> operatorStack = new Stack<Operator>();
			Stack<Expression> expressionStack = new Stack<Expression>();
			bool prefix = true;

			do {
				switch (tokens.Current.Type) {

					case TokenType.Number:
						expressionStack.Push(new NumberLiteral(tokens.Current.Str));
						tokens.MoveNext();
						prefix = false;
						break;
					case TokenType.DieOperator:
					case TokenType.Plus:
					case TokenType.Minus:
						var op = Operator.Operators.Where(p => p.Identification.Symbol == tokens.Current.Type).Where(p => {
							//TODO maybe do some more error checking?
							if (prefix) {
								return p.Identification.Type == OperatorType.PrefixUnary;
							} else {
								return p.Identification.Type == OperatorType.PostfixUnary || p.Identification.Type == OperatorType.InfixBinary;
							}
						}).First();
						tokens.MoveNext();


						PopHigherPrecidenceOperators(op, operatorStack, expressionStack);
						if (op.Identification.Type == OperatorType.PostfixUnary) {
							expressionStack.Push(UnaryOperation.Create(op.Identification, expressionStack.Pop()));
						} else {
							operatorStack.Push(op);
							if (op.Identification.Type == OperatorType.InfixBinary) {
								prefix = true;
							}

						}

						break;
					case TokenType.StartParenthese:
						expressionStack.Push(Parenthese());
						break;
					case TokenType.EndParenthese:
					case TokenType.Semicolon:
					case TokenType.Exception:
						// end of expression
						// TODO add error checking
						while(operatorStack.Count != 0) {
							PushOperationToExpressionStack(operatorStack.Pop(), expressionStack);
						}
						return expressionStack.Peek();	// !!!!END CONDITION IS HERE!!!!
					default:
						//TODO throw exeption
						break;
				}
			} while (true);
		}

		Expression Parenthese()
		{
			if (tokens.Current.Type != TokenType.StartParenthese)
				throw new UnexpectedTokenException(TokenType.StartParenthese, tokens.Current.Type);
			tokens.MoveNext();

			Expression output = Expression();

			if (tokens.Current.Type != TokenType.EndParenthese)
				throw new UnexpectedTokenException(TokenType.EndParenthese, tokens.Current.Type);
			tokens.MoveNext();

			return output;
		}
	}
}
