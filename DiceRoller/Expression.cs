using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace DiceRoller
{
	abstract class Expression
	{
		public abstract BigInteger Evaluate(IGenerator rng);
	}
}
