using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentForC_
{
    internal class outputPrime
    {
        static bool isPrime(int number)
        {
            if (number <= 1 || number % 2 == 0)
                return false;
            else if (number == 2)
                return true;

            int half = number / 2;
            int sqrt = (int)Math.Sqrt(number);
            for (int factor = 3; factor <= sqrt; factor += 2)
            {
                if (number % factor == 0)
                    return false;
            }
            return true;
        }


        /*static void Main(string[] args)
        {
            //handle input
            Console.WriteLine("the lower limit: ");
            int lower = int.Parse(Console.ReadLine());
            Console.WriteLine("the upper limit: ");
            int upper = int.Parse(Console.ReadLine());

            //get prime list 
            List<int> primeList = new List<int>();
            for (int check = lower; check <= upper; check++)
            {
                if (isPrime(check))
                    primeList.Add(check);
            }

            //output prime
            Console.WriteLine($"{lower}到{upper}的所有质数为:");
            int count = 1;
            foreach (int prime in primeList)
            {
                Console.Write($"{prime} ");
                if (count % 10 == 0)
                    Console.WriteLine();
                count++;

            }
        }*/
    }
}
