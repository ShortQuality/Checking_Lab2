using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Checking_Lab2
{
    class Checking_Lab2
    {
        static void EnteringMethodSelection(out char enteringMethod)
        {
            try
            {
                Console.WriteLine("What method of entering you want? Command Line(0)/File(1)");
                enteringMethod = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                enteringMethod = Convert.ToChar(2);
            }
        }

        static void Text_F_entering(out string[] coordsLine)
        {
            try
            {
                using (StreamReader fr = new StreamReader(@"IO\Inlet.in"))
                {

                    char[] lineSep = { '\n', '\r' };
                    coordsLine = fr.ReadToEnd().Split(lineSep, System.StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine("Successful reading.");
                }
            }
            catch (Exception ex)
            {
                coordsLine = new string[0];
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Unsuccessful reading!");
            }
        }

        static void Text_F_output(int count)
        {
            try
            {
                using (StreamWriter fw = new StreamWriter(@"IO\Outlet.out"))
                {
                    fw.WriteLine(count);
                    Console.WriteLine("Succesful writing.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Unsuccesful writing!");
            }
        }
        static void Text_C_entering(out string[] coordsLine)
        {
            try
            {
                int count = 0;
                string s;
                string[] coordsLine_2;
                Console.WriteLine("Enter strings:");
                coordsLine = new string[count];

                do
                {
                    s = Console.ReadLine().Replace(",", " ").Trim(' ');
                    if (s != "")
                    {
                        count++;
                        coordsLine_2 = new string[count];

                        for (int i = 0; i < coordsLine_2.Length - 1; i++)
                        {
                            coordsLine_2[i] = coordsLine[i];
                        }

                        coordsLine_2[count - 1] = s;
                        coordsLine = coordsLine_2;
                    }
                } while (s != "");
            }
            catch (Exception ex)
            {
                coordsLine = new string[0];
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine();
            }
        }

        static void Text_C_output(string[] outLine)
        {
            for (int i = 0; i < outLine.Length; i++)
            {
                char[] separator = { ' ' };
                string[] i_word = outLine[i].Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < i_word.Length; j++)
                {
                    if (j == 0 || j % 2 == 0)
                    {
                        Console.WriteLine(i_word[j] + " " + i_word[j + 1]);
                    }
                }
            }
        }

        static void CoordsSep(string[] coordsLine, out string[] outLine)
        {
            outLine = new string[coordsLine.Length];
            char[] separator = { ' ', ',' };
            for(int i = 0; i < coordsLine.Length; i++)
            {
                string[] i_word = coordsLine[i].Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                string[] tempLine = new string[i_word.Length];
                for(int j = 0; j < i_word.Length; j++)
                {
                    if(j % 2 == 0 || j == 0)
                    {
                        tempLine[j]= "X:" + i_word[j] + " ";
                    }
                    else
                    {
                        tempLine[j] = "Y:" + i_word[j] + " ";
                    }
                }
                outLine[i] = String.Join(" ",tempLine);
            }
        }

        static void Main(string[] args)
        {
            EnteringMethodSelection(out char enteringMethod);
            if (enteringMethod == '0')
            {
                Text_C_entering(out string[] coordsLine);
                CoordsSep(coordsLine, out string[] outLine);
                Text_C_output(outLine);
            }
            else if (enteringMethod == '1')
            {
                Text_F_entering(out string[] coordsLine);
                CoordsSep(coordsLine, out string[] outLine);
                Text_C_output(outLine);
            }
            else
            {
                Console.WriteLine("Incorrect Method!");
            }
        }
    }
}
