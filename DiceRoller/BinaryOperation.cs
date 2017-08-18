using System;

namespace DiceRoller
{
	abstract class BinaryOperation : Expression
	{
		public Expression firstTerm, secondTerm;

		public BinaryOperation(Expression expr2, Expression expr1)
		{
			firstTerm = expr1;
			secondTerm = expr2;
		}

		public static BinaryOperation Create(Operator.Identifier identification, Expression secondExpression, Expression firstExpression)
		{
			switch (identification.Symbol) {
				case Token.TokenType.DieOperator:
					return new DieOperation(secondExpression, firstExpression);
				case Token.TokenType.Plus:
					return new BinaryAdd(secondExpression, firstExpression);
				case Token.TokenType.Minus:
					return new BinaryMinus(secondExpression, firstExpression);
				default:
					throw new Exception($"No Binary operation using {identification.Symbol}");
			}
		}
	}
}