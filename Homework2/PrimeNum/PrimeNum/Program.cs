using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNum
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("请输入您想要分解的正整数：");
            int n = int.Parse(Console.ReadLine());
            while (n <= 1)
            {
                Console.WriteLine("输入不能分解的数字，请重新输入：");
                n = int.Parse(Console.ReadLine());
            }
            Analyze(n);
            
        
        }
        public static void Analyze(int i)
        { 
           
                Console.Write($"{i}=", i);
                for (int j = 2; j < i + 1; j++)
                {
                    while (i % j == 0 && i != j)
                    {
                        i = i / j;
                        Console.Write($"{j}*");
                    }
                    if (i == j)
                        Console.WriteLine($"{j}");

                }
            
        
        }
    }
}
