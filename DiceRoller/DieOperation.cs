using System;
using System.Numerics;
using Troschuetz.Random;

namespace DiceRoller
{
	internal class DieOperation : BinaryOperation
	{
		public DieOperation(Expression secondExpression, Expression firstExpression) : base(secondExpression, firstExpression) { }

		public override BigInteger Evaluate(IGenerator rng)
		{
			var numb = firstTerm.Evaluate(rng);
			if (numb < 0)
				// TODO Make runtime exception type?
				throw new Exception($"Number of dice must be non-negative, {numb} is invalid");
			var dieSize = secondTerm.Evaluate(rng);
			if (dieSize < 0)
				// TODO Make runtime exception type?
				throw new Exception($"Die size must be non-negative, {dieSize} is invalid");

			BigInteger sum = numb;
			//TODO optimize for very large numbers, either consider one roll to be many or use probability curves
			while (numb-- > 0)
				//TODO make fully compatible with bigger numbers
				sum += rng.NextUInt((uint)dieSize);
			return sum;
		}
	}
}