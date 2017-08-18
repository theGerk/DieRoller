using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static DiceRoller.Token;

namespace DiceRoller
{
	[Serializable]
	internal class NotEnoughTokensException : Exception
	{
		public TokenType[] Acceptable { get; }

		private static string makeString(TokenType[] expected)
		{
			string seperator = ", ";
			StringBuilder sb = new StringBuilder("No more tokens found, expecting one of the following:\n\t");
			foreach (var item in expected)
				sb.Append(item).Append(seperator);
			if (expected.Length != 0)
				sb.Length -= seperator.Length;
			return sb.ToString();
		}

		public NotEnoughTokensException(params TokenType[] acceptable) : base(makeString(acceptable))
		{
			Acceptable = acceptable;
		}

		public NotEnoughTokensException(TokenType[] acceptable, Exception innerException) : base(makeString(acceptable), innerException)
		{
			Acceptable = acceptable;
		}

		protected NotEnoughTokensException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}