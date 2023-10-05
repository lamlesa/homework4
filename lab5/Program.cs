using System;

namespace lab5
{
    public class Program
    {
        public static int LargerNumber(int a, int b)
        {
            if (a > b)
            {
                return (a);
            }
            else if (a == b)
            {
                throw new ArgumentException();
            }
            else
            {
                return (b);
            }
        }
        public static Tuple<int, int> Swap(ref int a, ref int b)
        {
            int k = a;
            a = b;
            b = k;
            return Tuple.Create(a, b);
        }
        public static bool Factorial_True(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                try
                {
                    checked
                    {
                        factorial *= i;
                    }
                }
                catch (OverflowException)
                {
                    return(false);
                }
            }
            return (true);
        }
        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return (1);
            }
            else
            {
                return (n * Factorial(n - 1));
            }
        }
        public static int NOD(int m, int n)
        {
            int nod;
            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }
            nod = n;
            return (nod);
        }
        public static int NOD(int k, int m, int n)
        {
            int nod = NOD(k, m);
            nod = NOD(nod, n);
            return (nod);
        }
        public static int Fibonacci(int n)
        {
            if (n == 1)
            {
                return (1);
            }
            else if (n == 2)
            {
                return(1);
            }
            else
            {
                return (Fibonacci(n - 1) + Fibonacci(n - 2));
            }
        }
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Упражнение 5.1:");
                int a = 442, b = 443;
                Console.WriteLine(LargerNumber(a, b));
            }

            {
                Console.WriteLine("Упражнение 5.2:");
                int a = 15, b = 16;
                Console.WriteLine(Swap(ref a, ref b));
            }

            {
                Console.WriteLine("Упражнение 5.3:");
                Console.WriteLine(Factorial_True(10));
            }

            {
                Console.WriteLine("Упражнение 5.4:");
                Console.WriteLine(Factorial(6));
            }

            {
                Console.WriteLine("Домашнее задание 5.1:");
                Console.WriteLine(NOD(12, 8));
                Console.WriteLine(NOD(12, 8, 6));
            }

            {
                Console.WriteLine("Домашнее задание 5.2:");
                Console.WriteLine(Fibonacci(10));
            }
        }
    }
}
