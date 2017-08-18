using System;
using System.Runtime.Serialization;
using System.Text;
using static DiceRoller.Token;

namespace DiceRoller
{
	[Serializable]
	internal class UnacceptableTokenException : Exception
	{
		public TokenType Found { get; }
		public TokenType[] Expceted { get; }
		
		private static string makeString(TokenType found, TokenType[] expected)
		{
			switch (found) {
				case TokenType.Exception:
					throw new NotEnoughTokensException();
				default:
					string seperator = " ,";
					var sb = new StringBuilder($"A {found} was found, however only the following are acceptable:\n\t");
					foreach (var item in expected)
						sb.Append(item).Append(seperator);
					if (expected.Length != 0)
						sb.Length -= seperator.Length;
					return sb.ToString();
			}
		}

		public UnacceptableTokenException(TokenType found, params TokenType[] acceptable)
		{
			Found = found;
			Expceted = acceptable;
		}

		protected UnacceptableTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}