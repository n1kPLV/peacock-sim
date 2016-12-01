using System;
using System.IO;
using System.Text;

namespace peacocksim
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            string file = Path.GetTempFileName() + ".csv";
            StreamWriter log = new StreamWriter(file);
            int arg1 = 0;


            if (!(args.Length == 0 || !int.TryParse(args[0], out arg1)))
            {
                for (int j = 0; j < arg1; j++)
                {
                    //Creating a Array of Peacocks
                    Peacock[] pfauen = new Peacock[] { new Peacock(1, rand), new Peacock(2, rand), new Peacock(3, rand), new Peacock(4, rand), new Peacock(5, rand), new Peacock(6, rand) };

                    for (int i = 1; i <= 10; i++)
                    {
                        foreach (Peacock pfau in pfauen)
                        {
                            if (rand.Next(0, 2) == 0)
                            {
                                pfau.moveEnemy(i);
                            }
                            else
                            {
                                pfau.movePartner(i);
                            }
                        }
                    }
                    StringBuilder logLine = new StringBuilder("");
                    foreach (Peacock pfau in pfauen)
                    {
                        logLine.Append(pfau.getTotalSuccessors());
                        logLine.Append(";");
                    }
                    Console.WriteLine(logLine.ToString());
                    log.WriteLine(logLine.ToString());
                }
                log.Close();
                Console.WriteLine("Finished after " + arg1 + " samples. Stats saved to "+file);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("first Argument need to be number of samples");
                Console.WriteLine("PLEASE PRESS ANY KEY TO CONTINUE");
                Console.ReadKey();
            }

                ////Test Code
                //Console.Write("feathers:? ");
                //Peacock pfau = new Peacock(Int32.Parse(Console.ReadLine()), rand);
                //while (true)
                //{
                //    Console.WriteLine(pfau.getDebug());
                //    Console.Write("round enemy:? ");
                //    pfau.moveEnemy(Int32.Parse(Console.ReadLine()));
                //    Console.WriteLine(pfau.getTotalSuccessors());
                //    Console.WriteLine(pfau.getDebug());

            }
        }
    }

