using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestVirtuplex
{
    public class CalculateLineHandler
    {
        public Expression LeftExpression { get; set; }
        private async void AddToCalculateBuilder(int left, int right)
        {
            if (LeftExpression == null)
            {
                LeftExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Add, LeftExpression, rightExpression);
            }
            else
                LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Add, LeftExpression, Expression.Constant(right));
            //LeftExpression = Expression.AddChecked(LeftExpression, Expression.Constant(right));
        }
        private async void DivideCalculateBuilder(int left, int right)
        {
            //if (LeftExpression == null)
            //{
                var leftDivideExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                var divideExpression = Expression.Divide(leftDivideExpression, rightExpression);
                Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(divideExpression);
                var evalString = expressionForEvaluation.ToString();
                var compiledExpression = expressionForEvaluation.Compile();
                int result = compiledExpression();
                var resultExpression = Expression.Constant(result);
            if (LeftExpression == null)
                LeftExpression = resultExpression;
            else
                LeftExpression = Expression.Add(LeftExpression, resultExpression);
            //}
            //else
            //{
            //    LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Divide, LeftExpression, Expression.Constant(right));
            //    Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(LeftExpression);
            //    var evalString = expressionForEvaluation.ToString();
            //    var compiledExpression = expressionForEvaluation.Compile();
            //    int result = compiledExpression();
            //    LeftExpression = Expression.Constant(result);
            //}
            //LeftExpression = Expression.Divide(LeftExpression, Expression.Constant(right));
            //var rightExpression = Expression.Constant(right);
            //LeftExpression = Expression.Divide(LeftExpression, rightExpression);
        }

        private async void MultiplyCalculateBuilder(int left, int right)
        {
            //if (LeftExpression == null)
            //{
                var leftMultiplicationExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                var multiplicationExpression = Expression.MultiplyChecked(leftMultiplicationExpression, rightExpression);
                Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(multiplicationExpression);
                var evalString = expressionForEvaluation.ToString();
                var compiledExpression = expressionForEvaluation.Compile();
                int result = compiledExpression();
                var resultExpression = Expression.Constant(result);
            if (LeftExpression == null)
                LeftExpression = resultExpression;
            else
                LeftExpression = Expression.Add(LeftExpression, resultExpression);
            //}
            //else
            //{
            //    LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Multiply, LeftExpression, Expression.Constant(right));
            //    Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(LeftExpression);
            //    var evalString = expressionForEvaluation.ToString();
            //    var compiledExpression = expressionForEvaluation.Compile();
            //    int result = compiledExpression();
            //    LeftExpression = Expression.Constant(result);
            //}

            //LeftExpression = Expression.MultiplyChecked(LeftExpression, Expression.Constant(right));
            //var rightExpression = Expression.Constant(right);
            //LeftExpression = Expression.MultiplyAssignChecked(LeftExpression, rightExpression);
        }

        private async void SubtractCalculateBuilder(int left, int right)
        {
            if (LeftExpression == null)
            {
                LeftExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                LeftExpression = Expression.SubtractChecked(LeftExpression, rightExpression);
            }
            else
                 LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Subtract, LeftExpression, Expression.Constant(right));
                //LeftExpression = Expression.SubtractChecked(LeftExpression, Expression.Constant(right));
        }

        public async void CalculateExpression(int leftNumber, int rightNumber, string calculationOperator)
        {
            switch (calculationOperator)
            {
                case "/":
                    DivideCalculateBuilder(leftNumber, rightNumber);
                    break;
                case "*":
                    MultiplyCalculateBuilder(leftNumber, rightNumber);
                    break;
                case "+":
                    AddToCalculateBuilder(leftNumber, rightNumber);
                    break;
                case "-":
                    SubtractCalculateBuilder(leftNumber, rightNumber);
                    break;
            }
        }

        public int Evaluation()
        {
            Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(LeftExpression);
            var evalString = expressionForEvaluation.ToString();
            //var lambdaEpression = DynamicExpressionParser.ParseLambda(typeof(int), evalString, null);
            //var expre = (Expression<Func<int>>)lambdaEpression;
            //var s = new Expression<Func<int>>(evalString);
            //var compiledExpression = expressionForEvaluation.Compile();
            var compiledExpression = expressionForEvaluation.Compile();
            int result = compiledExpression();
            return result;
        }
    }
}
