using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
	public enum OperatorType : short
	{
		PrefixUnary,
		InfixBinary,
		PostfixUnary
	}

	public enum OperatorAssociativity
	{
		Left,
		Right
	}

	public enum OperatorPrecidenceLevel
	{
		UnaryArithmatic = 0,
		Die = 1,
		Arithmatic = 2
	}

	public struct Operator
	{
		public struct Identifier : IEquatable<Identifier>
		{
			public Token.TokenType Symbol { get; }
			public OperatorType Type { get; }

			public Identifier(Token.TokenType symbol, OperatorType type)
			{
				Symbol = symbol;
				Type = type;
			}

			public bool Equals(Identifier other)
			{
				return Symbol == other.Symbol && Type == other.Type;
			}

			public override int GetHashCode()
			{
				int output = (short)Symbol;
				output <<= sizeof(int) * 8 / 2;
				output += (short)Type;
				return output;
			}
		}

		public static readonly Operator[] Operators = {
			new Operator(Token.TokenType.DieOperator, OperatorPrecidenceLevel.Die),
			new Operator(Token.TokenType.DieOperator, OperatorPrecidenceLevel.UnaryArithmatic, OperatorType.PrefixUnary, OperatorAssociativity.Right),
			new Operator(Token.TokenType.Minus, OperatorPrecidenceLevel.Arithmatic),
			new Operator(Token.TokenType.Minus, OperatorPrecidenceLevel.UnaryArithmatic, OperatorType.PrefixUnary, OperatorAssociativity.Right),
			new Operator(Token.TokenType.Plus, OperatorPrecidenceLevel.Arithmatic),
			new Operator(Token.TokenType.Plus, OperatorPrecidenceLevel.UnaryArithmatic, OperatorType.PrefixUnary, OperatorAssociativity.Right)
		};

		public Operator(Token.TokenType symbol, OperatorPrecidenceLevel precidenceLevel, OperatorType type = OperatorType.InfixBinary, OperatorAssociativity associativity = OperatorAssociativity.Left)
		{
			Identification = new Identifier(symbol, type);
			Precidence = (uint)precidenceLevel;
			Associativity = associativity;
		}
	
		public Identifier Identification { get; }
		public uint Precidence { get; }
		public OperatorAssociativity Associativity { get; }
	}
}
