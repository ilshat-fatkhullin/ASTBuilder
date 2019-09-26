using ASTBuilder.AST;
using System;

namespace ASTBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression:");
            string expression = Console.ReadLine();
            Parser.Parser parser = new Parser.Parser(expression);
            Console.WriteLine(parser.Parse().GetResult());     
        }
    }
}
