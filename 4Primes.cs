using System;

namespace Prime
{
    internal class Program
    {
        static List<long> primes = new List<long>();


        static void Main(string[] args)
        {
            int maximum = 1000;
            primes.Add(2);

            Program p = new Program();

            p.findPrimes(maximum);
            p.cullSmallPrimes();
            p.findValue();
        }

        void findPrimes(int m)
        {
            for(int i = 3; i < m; i += 2)
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                }
            }
        }

        //Checks to see if number is divisble by any other prime up to it's square root
        bool isPrime(int n)
        {
            foreach(int i in primes)
            {
                if(i * i > n)
                {
                    return true;
                }
                if (n % i == 0)
                {
                    return false;
                }
            }

            return false;
        }

        void cullSmallPrimes()
        {
            int n = 0;

            //All numbers must be at least 3 digits to reach 12 digits
            while (primes[++n] < 100);
  
            primes.RemoveRange(0, n);
        }
        void findValue()
        {
            long product = 0;

            //First value iterates up through list values
            for (int a = 0; a < primes.Count; a++)
            {
                //Second, third and fourth value iterates down through list values until it has the same value as another. Then the next stage up iterates down one value.
                for (int b = primes.Count - 1; b > 0; b--)
                {
                    if (b == a) break;

                    for (int c = primes.Count - 1; c > 0; c--)
                    {
                        if (c == b || c == a) break;

                        for (int d = primes.Count - 1; d > 0; d--)
                        {
                            if (d == c || d == b || d == a) break;

                            product = primes[a] * primes[b] * primes[c] * primes[d];

                            long productTest = product;


                            //Checks how many times 10 can go into the number to find number of digits
                            int digits = 1;
                            while ((productTest /= 10L) != 0L) digits++;

                            if (digits == 12)
                            {
                                if (isSequential(product))
                                {
                                    Console.WriteLine(product.ToString() + " " + primes[a] + " " + primes[b] + " " + primes[c] + " " + primes[d]);
                                }
                            }
                        }
                    }
                }
            }
        }

        bool isSequential(long n)
        {
            int previous = 0;
            int[] numerals = new int[12];

            //Converts the long into an array of ints.
            string nums = n.ToString();
            for (int i = 0; i < nums.Length; i++) numerals[i] = nums[i];

            //Checks to see if current digit is same as or higher than previous digit.
            foreach (int i in numerals)
            {
                if (previous == 0)
                {
                    previous = i;
                    continue;
                }

                if (i == previous || i - 1 == previous)
                {
                    previous = i;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}