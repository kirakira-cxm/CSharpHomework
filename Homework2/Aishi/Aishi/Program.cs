using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aishi
{
    class Program
    {
        static void Main(string[] args)
        {
            int count=0;   //素数个数
            bool[] array = new bool[101];  //false表示该下标不为素数，true表示为素数
            array[0] = array[1] = false;   //0与1都不是素数

            for (int i = 2; i <= 100; i++)
            {
                array[i] = true;   //假设都是素数，之后再排查
            }
            for (int i = 2; i * i <= 100; i++)
            {
                if (array[i] == true)
                {
                    for (int j = i; j * i <= 100; j++)
                    {
                        array[j * i] = false;    //剔除倍数
                    }
                }

            }
            Console.WriteLine("用埃氏筛法求2~100内的素数有：");
            for (int i = 2; i <= 100; i++)
            {
                if (array[i] == true)
                {
                    Console.Write($"{i}  ");
                    count++;
                    if(count%5==0)
                        Console.WriteLine();
                }
            }

        }
    }
}
