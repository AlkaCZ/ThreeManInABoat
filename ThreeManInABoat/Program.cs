using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreeManInABoat
{
   public static class FileMoves
    {
        public static void ReadAll(string path) 
        {
            string textOut = "";
        StreamReader sr = new StreamReader(path);
            textOut = sr.ReadToEnd();
            sr.Close();
            Console.Write(textOut);
        }

        public static void FindWord(string word)
        {
            string lineNums = "";
            string currentLine;
            int lineNum = 1;
            StreamReader sr = new StreamReader("BaseText.txt");
            StreamWriter sw = new StreamWriter("WordLines.txt");

            while (!sr.EndOfStream)
            {
                currentLine = sr.ReadLine();
                if (currentLine.Contains(word))
                {
                    lineNums += lineNum + ", ";
                    lineNum++;
                }
                else
                {
                    lineNum++;
                }
            }
            sr.Close();

            sw.Write(word + " > " + lineNums);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          string myPath = "BaseText.txt";
            //FileMoves.ReadAll(myPath);
            Console.WriteLine("Write your word > ");
            FileMoves.FindWord(Console.ReadLine());
            Console.ReadKey();
        }

    }
}

