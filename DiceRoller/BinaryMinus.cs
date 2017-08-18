using System;
using System.Numerics;
using Troschuetz.Random;

namespace DiceRoller
{
	internal class BinaryMinus : BinaryOperation
	{
		public BinaryMinus(Expression secondExpression, Expression firstExpression) : base(secondExpression, firstExpression) { }

		public override BigInteger Evaluate(IGenerator rng)
		{
			return firstTerm.Evaluate(rng) - secondTerm.Evaluate(rng);
		}
	}
}