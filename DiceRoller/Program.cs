using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;
using Troschuetz.Random.Generators;

namespace DiceRoller
{
	class Program
	{
		//operator preference:
		// unary (+, -)
		// die (d) left to right
		// addition / subtraction (+, -) left to right
		static void Main(string[] args)
		{
			MT19937Generator rng = new MT19937Generator();
			for(;;) {
				Console.WriteLine(SyntaxTreeGenerator.Generate(Token.Tokenify(Console.ReadLine())).Evaluate(rng));
			}
		}
	}
}
