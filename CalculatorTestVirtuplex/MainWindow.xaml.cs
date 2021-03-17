using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Linq.Expressions;
using System;

namespace CalculatorTestVirtuplex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool OutputFIleChosen { get; set; }

        private async void Choose_Input_File_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var inputFileManager = new InputFileManager();
            
            await inputFileManager.ManageInputFileAsync();
            //return control of ui thread

        }

        private async void Choose_Output_File_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
           await OpenFileDialogHandler.OpenTextFile();
        }


    }
}
