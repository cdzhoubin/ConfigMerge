using System.Linq.Expressions;

namespace ConfigMerge.Services.Core.Formatting
{
    public static class ExpressionExtensions
    {
        public static Expression StripQuotes(this Expression exp)
        {
            while (exp is UnaryExpression)
            {
                exp = ((UnaryExpression)exp).Operand;
            }
            return exp;
        }
    }
}