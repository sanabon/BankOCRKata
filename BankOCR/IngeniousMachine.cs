using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    public class IngeniousMachine
    {

        public IEnumerable<Tuple<char[][], string, string>> Translate(string filePath) 
        {
            return Translate(new StreamReader(filePath));
        }

        public IEnumerable<Tuple<char[][], string, string>> Translate(TextReader reader) 
        {
            string line;

            char[][] digits = new char[9][];
            int lineCount = 1;

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);

                if (lineCount < 4)
                {
                    // For the first 3 lines iterate through digit segments in line and add them to digit char array
                    for (var i = 0; i < 9; i++)
                    {
                        if (digits[i] == null)
                        {
                            digits[i] = new char[9];
                        }

                        var digit = digits[i];

                        var digit_line = line.ToCharArray().Skip(i * 3).Take(3).ToArray();
                        digit_line.CopyTo(digit, (lineCount - 1) * 3);
                    }
                    lineCount++;
                }
                else
                {
                    // In fourth line, perform digit parsing and account validation
                    int checkSum = 0;
                    string validationCode = string.Empty;
                    char[] account = new char[9];

                    // TryParse each digit in the account, and if succeeded calculate checksum.
                    // If not, set validation code to 'ILL'
                    for (var i=0; i<9; i++)
                    {
                        account[i] = ParseDigit((new string(digits[i])).Replace('\0',' '));

                        if (validationCode == string.Empty)
                        {
                            if (account[i] != '?')
                            {
                                checkSum += Convert.ToInt32(account[i].ToString()) * (9 - i);
                            }
                            else
                            {
                                validationCode = "ILL";
                            }
                        }
                    }

                    if (validationCode == string.Empty) 
                    {
                        validationCode = checkSum % 11 == 0 ? string.Empty : "ERR";
                    }

                    yield return new Tuple<char[][],string,string>(digits, new string(account), validationCode);

                    lineCount = 1;
                    digits = new char[9][];
                }
            }
        }

        private char ParseDigit(string digit_str) 
        {
            switch (digit_str)
            {
                case "     |  |":
                    {
                        return '1';
                    }
                case " _  _||_ ":
                    {
                        return '2';
                    }
                case " _  _| _|":
                    {
                        return '3';
                    }
                case "   |_|  |":
                    {
                        return '4';
                    }
                case " _ |_  _|":
                    {
                        return '5';
                    }
                case " _ |_ |_|":
                    {
                        return '6';
                    }
                case " _   |  |":
                    {
                        return '7';
                    }
                case " _ |_||_|":
                    {
                        return '8';
                    }
                case " _ |_| _|":
                    {
                        return '9';
                    }
                case " _ | ||_|":
                    {
                        return '0';
                    }
                default:
                    return '?';
            }
        }
    }
}
