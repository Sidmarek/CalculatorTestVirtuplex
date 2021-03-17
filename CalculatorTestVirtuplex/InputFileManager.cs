using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestVirtuplex
{
    public class InputFileManager
    {
        public async Task ManageInputFileAsync()
        {
            var readInputLineHandler = new ReadInputLineHandler();
            var calculateLineHandler = new CalculateLineHandler();
            var inputFileStream = await OpenFileDialogHandler.OpenTextFile();

            //temp construct
            using (StreamReader reader = new StreamReader(inputFileStream))
            {
                while (!reader.EndOfStream) 
                { 
                    var lineSegments = readInputLineHandler.ReadLine(await reader.ReadLineAsync());
                    calculateLineHandler.CalculateExpression();
                    var resultForLine = calculateLineHandler.Evaluation();
                }
            }
        }
    }
}
