using Antlr4.Runtime.Misc;
using System;

namespace AntlrCalculator.WinForms.Grammar
{
    public class CalculatorVisitor : CalculatorBaseVisitor<double>
    {
        public override double VisitNumberExpr([NotNull] CalculatorParser.NumberExprContext context)
        {
            return double.Parse(context.NUMBER().GetText());
        }

        public override double VisitParenthesizedExpr([NotNull] CalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr([NotNull] CalculatorParser.ExponentialExprContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));
            return Math.Pow(left, right);
        }

        public override double VisitMultiplicativeExpr([NotNull] CalculatorParser.MultiplicativeExprContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));
            
            return context.operatorToken.Type == CalculatorParser.MULTIPLY 
                ? left * right 
                : right != 0 ? left / right : throw new DivideByZeroException();
        }

        public override double VisitAdditiveExpr([NotNull] CalculatorParser.AdditiveExprContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));
            
            return context.operatorToken.Type == CalculatorParser.ADD 
                ? left + right 
                : left - right;
        }
    }
} 