using System;
using System.Collections.Generic;

namespace ASTBuilder.AST
{
    public class Term
    {
        public Factor[] Factors { get; private set; }

        public char[] Signs { get; private set; }

        public Term(string content)
        {
            content.Trim();

            List<Factor> factors = new List<Factor>();
            List<char> signs = new List<char>();

            string buffer = "";

            int depth = 0;

            foreach (char c in content)
            {
                if (c == '(')
                {
                    depth++;
                }
                else if (c == ')')
                {
                    depth--;
                }

                if (depth == 0 && (c == '+' || c == '-'))
                {
                    factors.Add(new Factor(buffer));
                    signs.Add(c);
                    buffer = "";
                    continue;
                }

                buffer += c;
            }

            factors.Add(new Factor(buffer));

            Factors = factors.ToArray();
            Signs = signs.ToArray();
        }

        public int GetResult()
        {
            if (Factors.Length == 1)
            {
                return Factors[0].GetResult();
            }

            int result = Factors[0].GetResult();

            for (int i = 1; i < Factors.Length; i++)
            {
                int r = Factors[i].GetResult();

                switch (Signs[i - 1])
                {
                    case '+':
                        result += r;
                        break;
                    case '-':
                        result -= r;
                        break;
                }
            }

            return result;
        }
    }
}
