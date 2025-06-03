using Antlr4.Runtime;
using AntlrCalculator.WinForms.Grammar;

namespace AntlrCalculator.WinForms
{
    public static class CalculatorHelper
    {
        public static double Calculate(string expression)
        {
            // Create the ANTLR input stream
            var inputStream = new AntlrInputStream(expression);
            
            // Create lexer and token stream
            var lexer = new CalculatorLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            
            // Create parser and parse tree
            var parser = new CalculatorParser(tokenStream);
            var tree = parser.compileUnit();
            
            // Create visitor and calculate result
            var visitor = new CalculatorVisitor();
            return visitor.Visit(tree);
        }

        public static string GetVersion()
        {
            return "ANTLR Calculator v1.0";
        }
    }
} 