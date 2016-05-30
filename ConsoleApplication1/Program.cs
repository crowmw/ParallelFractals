using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            //Przykład1();
            int p = rnd.Next(0, 9999);
            int t = rnd.Next(10);
            int n = 5;
            int s = rnd.Next(0, 9999);
            Console.WriteLine("sekret s=" + s);
            Console.WriteLine("czesci n=" + n);
            Console.WriteLine("t=" + t);
            Console.WriteLine("p=" + p);

            List<int> aList = new List<int>();
            for(int i = 0; i<=t-1; i++)
            {
                aList.Add(rnd.Next(9999));
                Console.Write(aList[i] + ", ");
            }
            Console.WriteLine("\n\n");

            List<int> sList = new List<int>();
            for(int i =0; i<=5; i++)
            {
                int tmpS = 0;
                for (int j = 0; j <= t - 1; j++)
                {
                    tmpS += aList[j] % p; 
                }
                Console.WriteLine("S" + i + " = " + tmpS+s);
            }

            Console.ReadKey();
        }

        private static void Przykład1()
        {
            int k = 999;
            int s = rnd.Next(0, k);
            Console.WriteLine("s = " + s);
            int n = 3;
            int s1 = rnd.Next(0, k);
            Console.WriteLine("s2 = " + s1);
            int s2 = rnd.Next(0, k);
            Console.WriteLine("s2 = " + s2);

            int s3 = (s - s1 - s2) % k;
            Console.WriteLine("s3 = " + s3);

            int snew = (s1 + s2 + s3) % k;
            Console.WriteLine("SNew = " + snew);
            Console.ReadKey();
        }
    }
}
