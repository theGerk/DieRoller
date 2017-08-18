using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace DiceRoller
{
	class NumberLiteral : Expression
	{
		private BigInteger value;
		public NumberLiteral(string expr)
		{
			value = BigInteger.Parse(expr);
		}

		public override BigInteger Evaluate(IGenerator rng)
		{
			return value;
		}
	}
}
