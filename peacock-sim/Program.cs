using System;


namespace peacocksim
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {

            //Test Code
            Console.Write("feathers:? ");
            Peacock pfau = new Peacock(Int32.Parse(Console.ReadLine()), rand);
            while (true)
            {
                Console.WriteLine(pfau.getDebug());
                Console.Write("round partner:? ");
                pfau.movePartner(Int32.Parse(Console.ReadLine()));
                Console.WriteLine(pfau.getTotalSuccessors());
                Console.WriteLine(pfau.getDebug());
                
            }
        }
    }
}
