using System;

namespace ASTBuilder.AST
{
    public class Primary
    {
        public int Integer { get; private set; }

        public Expression Expression { get; private set; }

        public Primary(string content)
        {
            content.Trim();
            if (content[0] == '(' && content[content.Length - 1] == ')')
            {
                Expression = new Expression(content.Substring(1, content.Length - 2));
                return;
            }

            int result;
            if (int.TryParse(content, out result))
            {
                Integer = result;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetResult()
        {
            if (Expression != null)
            {
                return Expression.GetResult();
            }

            return Integer;
        }
    }
}
