using Crypter.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crypter
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

        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Word documents (*.docx)|*.docx";

            if (openFileDialog.ShowDialog() != true)
                return;

            string fileText = string.Empty;
            string fileName = openFileDialog.FileName;
            if (openFileDialog.FilterIndex == 1)
            {
                fileText = new TxtFileHandler().Read(fileName);
            }
            else if (openFileDialog.FilterIndex == 2)
            {
                fileText = new DocxFileHandler().Read(fileName);
            }
            textBoxInput.Text = fileText;
        }
    }
}
