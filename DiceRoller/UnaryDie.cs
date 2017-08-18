using System;
using System.Numerics;
using Troschuetz.Random;

namespace DiceRoller
{
	internal class UnaryDie : UnaryOperation
	{
		public UnaryDie(Expression expr) : base(expr)
		{ 
		}

		public override BigInteger Evaluate(IGenerator rng)
		{
			return rng.NextUInt((uint)term.Evaluate(rng)) + 1;
		}
	}
}