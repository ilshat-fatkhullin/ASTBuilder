using System;
using System.Collections.Generic;

namespace ASTBuilder.AST
{
    public class Factor
    {
        public Primary[] Primaries { get; private set; }

        public Factor(string content)
        {
            content.Trim();

            List<Primary> primaries = new List<Primary>();

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
                
                if (depth == 0 && c == '*')
                {
                    primaries.Add(new Primary(buffer));
                    buffer = "";
                    continue;
                }

                buffer += c;
            }

            primaries.Add(new Primary(buffer));
            Primaries = primaries.ToArray();
        }

        public int GetResult()
        {
            if (Primaries.Length == 1)
            {
                return Primaries[0].GetResult();
            }

            int result = Primaries[0].GetResult();

            for (int i = 1; i < Primaries.Length; i++)
            {
                int r = Primaries[i].GetResult();
                result *= r;
            }

            return result;
        }
    }
}
