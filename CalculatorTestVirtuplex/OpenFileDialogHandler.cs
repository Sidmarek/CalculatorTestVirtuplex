using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestVirtuplex
{
    public class OpenFileDialogHandler
    {
        public static async Task<Stream> OpenTextFile()
        {
            Stream fileStream = null;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckFileExists)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                fileStream = openFileDialog.OpenFile();

                
            }

            return fileStream;
        }
    }
}
