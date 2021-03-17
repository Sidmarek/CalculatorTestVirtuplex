using CalculatorTestVirtuplex.Model.DTO;
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
        private LineDTO currentLine { get; set; }

        private async void AddToCalculateBuilder(int indexOfLeftNumber, int indexOfRightNumber)
        {
            var left = currentLine.Numbers[indexOfLeftNumber];
            var right = currentLine.Numbers[indexOfRightNumber];

            if (LeftExpression == null)
            {
                LeftExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Add, LeftExpression, rightExpression);
            }
            else
                LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Add, LeftExpression, Expression.Constant(right));
        }

        private async void DivideCalculateBuilder(int indexOfLeftNumber, int indexOfRightNumber)
        {

            var left = currentLine.Numbers[indexOfLeftNumber];
            var right = currentLine.Numbers[indexOfRightNumber];

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
        }

        private async void MultiplyCalculateBuilder(int indexOfLeftNumber, int indexOfRightNumber)
        {
            var left = currentLine.Numbers[indexOfLeftNumber];
            var right = currentLine.Numbers[indexOfRightNumber];

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
        }

        private async void SubtractCalculateBuilder(int indexOfLeftNumber, int indexOfRightNumber)
        {
            if (LeftExpression == null)
            {
                LeftExpression = Expression.Constant(left);
                var rightExpression = Expression.Constant(right);
                LeftExpression = Expression.SubtractChecked(LeftExpression, rightExpression);
            }
            else
                 LeftExpression = BinaryExpression.MakeBinary(ExpressionType.Subtract, LeftExpression, Expression.Constant(right));
        }

        public async void CalculateExpression(LineDTO lineDTO)
        {
            currentLine = lineDTO;
            foreach (var calculationOperator in currentLine.Operators)
            {
                int indexInLine = 0;
                switch (calculationOperator)
                {
                    case "/":
                        DivideCalculateBuilder(indexInLine, ++indexInLine);
                        break;
                    case "*":
                        MultiplyCalculateBuilder(indexInLine, ++indexInLine);
                        break;
                    case "+":
                        AddToCalculateBuilder(indexInLine, ++indexInLine);
                        break;
                    case "-":
                        SubtractCalculateBuilder(indexInLine, ++indexInLine);
                        break;
                }
                indexInLine++;
            }
        }

        public int Evaluation()
        {
            Expression<Func<int>> expressionForEvaluation = Expression.Lambda<Func<int>>(LeftExpression);
            var evalString = expressionForEvaluation.ToString();

            var compiledExpression = expressionForEvaluation.Compile();
            int result = compiledExpression();
            return result;
        }
    }
}
