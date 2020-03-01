using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuzuYuansu
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;      //数组长度

            int[] array;
            Console.WriteLine("请输入数组长度：");
            n = int.Parse(Console.ReadLine());
            array = new int[n];
            Console.WriteLine($"请输入{n}个数组元素：");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("数组元素有：");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            int max, min, sum;
            double ave;
            Calculate(array, out max, out min, out sum, out ave);
            Console.WriteLine($"数组的最大值是{max},最小值是{min}");
            Console.WriteLine($"数组元素的和为{sum},平均值是{ave}");

        }
        public static void Calculate(int[] a, out int max, out int min, out int sum, out double ave)
        {
            max = a[0]; min = a[0]; sum = 0; ave = 0;
            foreach (int i in a)
            {
                if (max < i)
                    max = i;
                if (min > i)
                    min = i;
                sum += i;
            }
            ave = (double)sum / a.Length;
        }
    }
}
