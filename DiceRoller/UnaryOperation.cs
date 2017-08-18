using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace DiceRoller
{
	abstract class UnaryOperation : Expression
	{
		protected UnaryOperation(Expression expr)
		{
			term = expr;
		}

		public Expression term;

		public static UnaryOperation Create(Operator.Identifier op, Expression expr)
		{
			switch (op.Symbol) {
				case Token.TokenType.Minus:
					return new UnaryMinus(expr);
				case Token.TokenType.Plus:
					return new UnaryAdd(expr);
				case Token.TokenType.DieOperator:
					return new UnaryDie(expr);
				default:
					throw new Exception($"Invalid unary operator: {op.Symbol}");
			}
		}
	}
}
