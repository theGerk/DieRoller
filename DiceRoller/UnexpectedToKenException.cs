using System;
using System.Runtime.Serialization;
using static DiceRoller.Token;

namespace DiceRoller
{
	[Serializable]
	internal class UnexpectedTokenException : Exception
	{
		private static string makeString(TokenType expected, TokenType found)
		{
			switch (found) {
				case TokenType.Exception:
					throw new NotEnoughTokensException(expected);
				default:
					return $"Found a {found.ToString()} where a {expected.ToString()} was expected.";
			}
		}

		public TokenType Expected { get; }
		public TokenType Found { get; }
		
		public UnexpectedTokenException(TokenType expected, TokenType found) : base(makeString(expected, found))
		{
			Expected = expected;
			Found = found;
		}

		public UnexpectedTokenException(TokenType expected, TokenType found, Exception innerException) : base(makeString(expected, found), innerException)
		{
			Expected = expected;
			Found = found;
		}

		protected UnexpectedTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}