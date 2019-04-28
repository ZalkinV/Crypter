# Crypter
Crypter — it is the desktop (Windows) program for encrypting and decrypting texts written in Russian and English languages with using the Caesar cipher.

## Description
This program is a final project of the C# basics course by FirstLineSoftware.  
It is written in C# with using .NET Framework 4.7.2 and WPF technology.

## Functionality
1. Encrypting/Decrypting texts with using Caesar cipher for digits and languages:
   - Russian
   - English
2. Ways of encrypting/decrypting:
   - Manual setting the step from -99999999 to 999999999
3. Types of text input:
   - Keyboard (text area on the left side)
   - TXT files
   - DOCX files
   - Any other files with text information
4. Types of text output:
   - Screen (text area on the right side)
   - TXT files
   - DOCX files
   - Any other files with text information

## Tutorial
1. Type the text in the text area on the left side.
2. Choose the languages near the label "Languages" which will be used in the encrypting/decrypting. Unchecked languages will be ignored.
3. Set the step in the field near the label "Step".
4. Press the button "Encrypt" to encrypt your text or "Decrypt" to decrypt your text.

Used step in encrypting/decrypting process depending on the pressed button:
- Button "Encrypt": will be used the set in field step with the same sign (3 -> 3; -3 -> -3).
- Button "Decrypt": will be used the set in field step with the opposite sign (5 -> -5; -5 -> 5)

## Downloading and running project
1. Clone project or download ZIP archive.
2. Open the Crypter solution in the Visual Studio.
3. Right click on the solution in the Solution Explorer and choose "Restore NuGet Packages" to install DocX package which is used for work with DOCX files.
4. Build and run Crypter project.

# Dependencies
- DocX (v1.3.0) by Xceed — to work with DOCX files
