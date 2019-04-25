﻿using Crypter.Model;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
            IFileHandler fileHandler;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Word documents (*.docx)|*.docx";

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
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Word documents (*.docx)|*.docx";

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

            textBoxOutput.Text = CaesarCrypter.Encrypt(textBoxInput.Text, int.Parse(textBoxStep.Text));
        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (!IsStepValid(textBoxStep.Text))
                return;

            textBoxOutput.Text = CaesarCrypter.Decrypt(textBoxInput.Text, int.Parse(textBoxStep.Text));
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
    }
}
