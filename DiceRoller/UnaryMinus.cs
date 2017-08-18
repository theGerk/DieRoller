using System;
using System.Numerics;
using Troschuetz.Random;

namespace DiceRoller
{
	class UnaryMinus : UnaryOperation
	{
		public UnaryMinus(Expression expr) : base(expr) { }

		public override BigInteger Evaluate(IGenerator rng)
		{
			return -term.Evaluate(rng);
		}
	}
}