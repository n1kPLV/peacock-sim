using System;
using System.IO;
using System.Text;

namespace peacocksim
{
    class Program
    {
        private static Random rand = new Random();
        ///first arg: needed, number of samples
        ///second arg: optional, share of partners
        ///third arg: optional, share of enemies
        ///4th arg: optional, outputfile
        static void Main(string[] args)
        {
            string file;
            StreamWriter log;
            int arg1 = 0;
            int arg2 = 1;
            int arg3 = 1;

            if (args.Length >= 4)
            {
                if (File.Exists(args[3]))
                {
                    Console.WriteLine("Given File exists. Ignoring");
                    file = Path.GetTempFileName() + ".csv";
                }
                else
                {
                    try
                    {
                        File.Create(args[4]);
                        file = args[4];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("File could not be created. Ignoring");
                        file = Path.GetTempFileName() + ".csv";
                    }
                }
                
            }
            else
            {
                file = Path.GetTempFileName() + ".csv";
            }
            if (args.Length >= 2)
            {
                if (!int.TryParse(args[1], out arg2))
                {
                    Console.WriteLine("second argument set invalid");
                }
                
            }
            if (args.Length >= 3)
            {
                if (!int.TryParse(args[2], out arg3))
                {
                    Console.WriteLine("third argument set invalid");
                }
            }
            
            
            log = new StreamWriter(file);

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
                            int rr = rand.Next(1, arg2 + arg3);
                            if (rr >= arg3)
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

