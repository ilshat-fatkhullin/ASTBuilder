using ASTBuilder.AST;

namespace ASTBuilder.Parser
{
    public class Parser
    {
        public string Input { get; private set; }

        public Parser(string input)
        {
            Input = input;
        }

        public Expression Parse()
        {
            return new Expression(Input);
        }
    }
}
