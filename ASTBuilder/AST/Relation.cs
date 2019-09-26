using System;

namespace ASTBuilder.AST
{
    public class Relation
    {
        public Term[] Terms { get; private set; }

        public char Value { get; private set; }

        public Relation(string content)
        {
            int depth = 0;
            for (int i = 0; i < content.Length; i++)
            {                
                char c = content[i];

                if (c == '(')
                {
                    depth++;
                }
                else if (c == ')')
                {
                    depth--;
                }

                if (depth == 0 && (c == '<' || c == '>' || c == '='))
                {
                    Terms = new Term[2];
                    Terms[0] = new Term(content.Substring(0, i));
                    Terms[1] = new Term(content.Substring(i + 1));
                    Value = c;
                    return;
                }
            }
            Terms = new Term[1];
            Terms[0] = new Term(content);
        }

        public int GetResult()
        {
            if (Terms.Length == 1)
            {
                return Terms[0].GetResult();
            }

            int term0Result = Terms[0].GetResult(), term1Result = Terms[1].GetResult();

            switch (Value)
            {
                case '<':
                    return BoolToInt(term0Result < term1Result);
                case '>':
                    return BoolToInt(term0Result > term1Result);
                case '=':
                    return BoolToInt(term0Result == term1Result);
            }

            throw new Exception();
        }

        private static int BoolToInt(bool value)
        {
            if (value)
                return 1;
            else
                return 0;
        }
    }
}
