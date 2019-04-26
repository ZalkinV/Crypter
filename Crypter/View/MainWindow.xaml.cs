using Crypter.Model;
using Crypter.Control;
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
        const string FILE_FILTERS =
            "Text files (*.txt)|*.txt|" +
            "Word documents (*.docx)|*.docx|" +
            "All files (*.*)|*.*";

        CaesarCrypter caesarCrypter;
        HashSet<Languages> selectedLanguages;

        public MainWindow()
        {
            InitializeComponent();
            selectedLanguages = new HashSet<Languages>();
            checkBoxLangRus.IsChecked = true;
            checkBoxLangDig.IsChecked = true;

            caesarCrypter = new CaesarCrypter(new Alphabet(Languages.Russian), new Alphabet(Languages.Digits));
        }

        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
            IFileHandler fileHandler;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILE_FILTERS;

            if (openFileDialog.ShowDialog() != true)
                return;

            if (openFileDialog.FilterIndex == 2)
                fileHandler = new DocxFileHandler();
            else
                fileHandler = new TxtFileHandler();

            textBoxInput.Text = fileHandler?.Read(openFileDialog.FileName);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            IFileHandler fileHandler;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FILE_FILTERS;

            if (saveFileDialog.ShowDialog() != true)
                return;

            if (saveFileDialog.FilterIndex == 2)
                fileHandler = new DocxFileHandler();
            else
                fileHandler = new TxtFileHandler();

            fileHandler?.Save(saveFileDialog.FileName, textBoxOutput.Text);
        }

        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (!IsStepValid(textBoxStep.Text))
                return;

            textBoxOutput.Text = caesarCrypter.Encrypt(textBoxInput.Text, int.Parse(textBoxStep.Text));
        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (!IsStepValid(textBoxStep.Text))
                return;

            textBoxOutput.Text = caesarCrypter.Decrypt(textBoxInput.Text, int.Parse(textBoxStep.Text));
        }

        private bool IsStepValid(string textStep)
        {
            bool isValid = true;
            int step;
            if (!int.TryParse(textStep, out step))
            {
                MessageBox.Show("Step must be a digital number!", "Wrong step");
                isValid = false;
            }
            return isValid;
        }

        private void CheckBoxLangRus_Changed(object sender, RoutedEventArgs e)
        {
            CheckBoxLangChanged(Languages.Russian, (sender as CheckBox).IsChecked);
        }

        private void CheckBoxLangEng_Changed(object sender, RoutedEventArgs e)
        {
            CheckBoxLangChanged(Languages.English, (sender as CheckBox).IsChecked);
        }

        private void CheckBoxLangDig_Changed(object sender, RoutedEventArgs e)
        {
            CheckBoxLangChanged(Languages.Digits, (sender as CheckBox).IsChecked);
        }

        private void CheckBoxLangChanged(Languages language, bool? isChecked)
        {
            if (isChecked == true)
                selectedLanguages.Add(language);
            else if (isChecked == false)
                selectedLanguages.Remove(language);
        }
    }
}
