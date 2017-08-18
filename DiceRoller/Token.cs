using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
	public struct Token
	{
		public TokenType Type { get; }
		public string Str { get; }

		public Token(TokenType type, string str)
		{
			Type = type;
			Str = str;
		}

		public override string ToString()
		{
			return Str;
		}

		public static IEnumerator<Token> Tokenify(string expression)
		{
			for (int i = 0; i < expression.Length; i++) {
				switch (expression[i]) {
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						int j = i + 1;
						for (; j < expression.Length && char.IsDigit(expression[j]); j++) ;
						yield return new Token(TokenType.Number, expression.Substring(i, j - i));
						i = j - 1;
						break;
					case 'd':
					case 'D':
						yield return new Token(TokenType.DieOperator, new string(expression[i], 1));
						break;
					case '+':
						yield return new Token(TokenType.Plus, "+");
						break;
					case '-':
						yield return new Token(TokenType.Minus, "-");
						break;
					case ' ':
					case '\n':
					case '\r':
					case '\t':
						break;
					case '(':
						yield return new Token(TokenType.StartParenthese, "(");
						break;
					case ')':
						yield return new Token(TokenType.EndParenthese, ")");
						break;
					case ';':
						yield return new Token(TokenType.Semicolon, ";");
						break;
					default:
						throw new FormatException($"Unacceptable character, {expression[i]}, found at index {i}.");
				}
			}
			for (;;) yield return new Token(TokenType.Exception, "");
		}

		public enum TokenType : short
		{
			/// <summary>
			/// Used at end as a non token type to show exception
			/// </summary>
			Exception,
			Number,
			DieOperator,
			Plus,
			Minus,
			StartParenthese,
			EndParenthese,
			Semicolon
		}
	}
}
