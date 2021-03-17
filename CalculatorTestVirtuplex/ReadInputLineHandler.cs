using CalculatorTestVirtuplex.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorTestVirtuplex
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadInputLineHandler
    {

        public LineDTO ReadLine(string line)
        {
            var line
            //var lineSegments = new List<LineSegmentDTO>();
            //Splits input file by space on scheme number, operator. number
            var splittedLineBySpace = line.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (var lineSegment in splittedLineBySpace) 
            {

                if (int.TryParse(splittedLineBySpace[i], out int firstNumber))
                {
                    lineSegmentDTO.LeftNumber = firstNumber;
                }
                else
                {
                    lineSegmentDTO.Error = "";
                }

            }

            //TODO into constants
            //Each segment should contains number operator and number
            //for (int i= 0; (i + 2) < splittedLineBySpace.Length; i += 2)
            //{
            //    var lineSegmentDTO = new LineSegmentDTO();

            //    //int FirstNumberIndex = 0;

            //    ////After first segment all segments have left number as right number of the previouse segment.
            //    //if (i > 0)
            //    //    FirstNumberIndex = i - 1;

            //    if(int.TryParse(splittedLineBySpace[i], out int firstNumber))
            //    {
            //        lineSegmentDTO.LeftNumber = firstNumber;
            //    } 
            //    else
            //    {
            //        lineSegmentDTO.Error = "";
            //    }

            //    if (splittedLineBySpace[i+1].Contains("/") || splittedLineBySpace[i + 1].Contains("*") || 
            //        splittedLineBySpace[i + 1].Contains("+") || splittedLineBySpace[i + 1].Contains("-"))
            //    {
            //        lineSegmentDTO.CalculationOperator = splittedLineBySpace[i + 1];
            //    }
            //    else
            //    {
            //        lineSegmentDTO.Error = "";
            //    }

            //    if (int.TryParse(splittedLineBySpace[i+2], out int secondNumber))
            //    {
            //        lineSegmentDTO.RightNumber = secondNumber;
            //    }
            //    else
            //    {
            //        lineSegmentDTO.Error = "";
            //    }

            //    lineSegments.Add(lineSegmentDTO);
            //}

            return lineSegments;
        }
    }
}
