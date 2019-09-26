namespace ASTBuilder.AST
{
    public class Expression
    {
        public Relation Relation { get; private set; }

        public Expression(string content)
        {
            content.Trim();
            Relation = new Relation(content);
        }

        public int GetResult()
        {
            return Relation.GetResult();
        }
    }
}
