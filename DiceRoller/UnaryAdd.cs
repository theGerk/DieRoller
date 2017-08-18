using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace DiceRoller
{
	class UnaryAdd : UnaryOperation
	{
		public UnaryAdd(Expression expr) : base(expr) { }

		public override BigInteger Evaluate(IGenerator rng)
		{
			return term.Evaluate(rng);
		}
	}
}
