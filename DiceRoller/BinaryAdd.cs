using System;
using System.Numerics;
using Troschuetz.Random;

namespace DiceRoller
{
	internal class BinaryAdd : BinaryOperation
	{

		public BinaryAdd(Expression firstExpression, Expression secondExpression) : base(firstExpression, secondExpression) { }

		public override BigInteger Evaluate(IGenerator rng)
		{
			return firstTerm.Evaluate(rng) + secondTerm.Evaluate(rng);
		}
	}
}