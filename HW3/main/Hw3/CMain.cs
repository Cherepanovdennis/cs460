using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;



namespace Hw3
{

    public class CMain
    {

        private static void printUsage()
        {
            Console.WriteLine("Usage is:\n" +
                "\tjava Main C inputfile outputfile\n\n" +
                "Where:" +
                "  C is the column number to fit to\n" +
                "  inputfile is the input text file \n" +
                "  outputfile is the new output file base name containing the wrapped text.\n" +
                "e.g. java Main 72 myfile.txt myfile_wrapped.txt");
        }

        public static void Main(string[] args)
        {
            int C = 72;                     // Column length to wrap to
            String InputFileName;
            String OutputFileName = "output.txt";
            String[] Text = { }; 

            // Read the command line arguments ...
            if (args.Length != 3)
            {
                printUsage();
                Environment.Exit(1);
            }
            try
            {
                C = Int32.Parse(args[0]);
                InputFileName = args[1];
                OutputFileName = args[2];
                Console.WriteLine(InputFileName);
                StreamReader helper = new StreamReader(InputFileName);
                Text = helper.ReadToEnd().Split();

                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something is wrong with the input.");
                printUsage();
                Environment.Exit(1);
            }

            // Read words and their lengths into these vectors
            QueueInterface<String> words = new LinkedQueue<String>();
            int i = 0;

            // Read input file, tokenize by whitespace
            while (i < Text.Length)
            {
                String word = Text[i];
                words.push(word);
                i++;
            }
            // At this point the input text file has now been placed, word by word, into a FIFO queue
            // Each word does not have whitespaces included, but does have punctuation, numbers, etc.

            /* ------------------ Start here ---------------------- */

            // As an example, do a simple wrap
            int spacesRemaining = wrapSimply(words, C, OutputFileName);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
        }
        // End main()

        /*-----------------------------------------------------------------------
            Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
          -----------------------------------------------------------------------*/

        /**
            As an example only, write out the file directly to the output with _simple_ wrapping,
            i.e. adding spaces between words and moving to the next line if a word would go past the
            indicated column number C.  This will fail if any word length exceeds the column limit C,
            but it still goes ahead and just puts one word on that line.
        */

        private static int wrapSimply(QueueInterface<String> words, int columnLength, String outputFilename)
        {
            StreamWriter Outer = null;

            try
            {
			Outer = new StreamWriter(outputFilename);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Cannot create or open " + outputFilename +
                            " for writing.  Using standard output instead.");
			//Outer = new StringReader(Console);
            }

            int col = 1;
            int spacesRemaining = 0;            // Running count of spaces left at the end of lines
            while (!words.isEmpty())
            {
                String str = words.peek();
                int len = str.Length;
                // See if we need to wrap to the next line
                if (col == 1)
                {
				Outer.Write(str);
                    col += len;
                    words.pop();
                }
                else if ((col + len) >= columnLength)
                {
                    // go to the next line
                    Outer.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {   // Typical case of printing the next word on the same line
                    Outer.Write(" ");
                    Outer.Write(str);
                    col += (len + 1);
                    words.pop();
                }

            }
            Outer.WriteLine();
            Outer.Flush();
            Outer.Close();
            return spacesRemaining;
        }

    }

}





