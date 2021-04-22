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

        public static void FindWord(string word, string path)
        {
            string lineNums = "";
            string currentLine;
            int lineNum = 1;
            StreamReader sr = new StreamReader(path);

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
            using (StreamWriter sw = new StreamWriter("WordLines.txt", true))
            {
                sw.Write(word + " > " + lineNums);
                sw.WriteLine();
            }

        }

        public static void WordList (string path)
        {
            string textInString;
            List<string> Unwanted = new List<string>();
            Unwanted.Add("and");
            Unwanted.Add("nor");
            Unwanted.Add("but");
            Unwanted.Add("or");
            Unwanted.Add("yet");
            Unwanted.Add("so");
            Unwanted.Add("both");
            Unwanted.Add("either");
            Unwanted.Add("neither");
            Unwanted.Add("only");
            Unwanted.Add("also");
            Unwanted.Add("in");
            Unwanted.Add("at");
            Unwanted.Add("on");
            Unwanted.Add("by");
            Unwanted.Add("beside");
            Unwanted.Add("before");
            Unwanted.Add("below");
            Unwanted.Add("under");
            Unwanted.Add("over");
            Unwanted.Add("above");
            Unwanted.Add("across");
            Unwanted.Add("between");
            Unwanted.Add("towards");
            Unwanted.Add("for");


            HashSet<string> stringHash = new HashSet<string>();
            StreamReader sr = new StreamReader(path);
            textInString = sr.ReadToEnd();
            

            foreach (string word in textInString.Split(' ', '-', '"', ',', '.', '?', '!', '[', ']', '(', ')', '_', '*', '—', '“', '#', '”', ':', ';'))
            {
                if (!stringHash.Contains(word) && !Unwanted.Contains(word))
                {
                    stringHash.Add(word);
                }
            }
            foreach (string word in stringHash)
            {
                FindWord(word,path);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
          string myPath = "BaseText.txt";
            //FileMoves.ReadAll(myPath);
            //Console.WriteLine("Write your word > ");
            //FileMoves.FindWord(Console.ReadLine());
            FileMoves.WordList(myPath);
            Console.WriteLine("DONE");
            Console.ReadKey();
        }

    }
}

