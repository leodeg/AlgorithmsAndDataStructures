using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms.StackProblem
{
	public static class BalancedParenthesis
	{
		public static bool IsBalancedParenthesis (string expression)
		{
			Stack<char> stackExpression = new Stack<char> ();

			foreach (char item in expression)
			{
				switch (item)
				{
					case '{':
					case '[':
					case '(':
						stackExpression.Push (item);
						break;

					case '}':
						if (stackExpression.Pop () != '{') return false;
						break;

					case ']':
						if (stackExpression.Pop () != '[') return false;
						break;

					case ')':
						if (stackExpression.Pop () != '(') return false;
						break;

					default: break;
				}
			}
			return stackExpression.Count == 0;
		}	
	}
}
