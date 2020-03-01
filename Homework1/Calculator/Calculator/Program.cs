using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;  //计算器开关标记
            while (!flag)
            {
                string num1 = "", num2 = "";    //声明输入的两个运算变量字符串
                double finalnum1 = 0, finalnum2 = 0;
                Console.WriteLine("输入第一个运算数字：");
                num1 = Console.ReadLine();   //将命令行读入的字符转换为浮点数
                while (!double.TryParse(num1, out finalnum1))
                {
                    Console.WriteLine("输入无效值！请重新输入： ");
                    num1 = Console.ReadLine();
                }
                Console.WriteLine("输入第二个运算数字：");
                num2 = Console.ReadLine();
                while (!double.TryParse(num2, out finalnum2))
                {
                    Console.WriteLine("输入无效值！请重新输入：");
                    num2 = Console.ReadLine();
                }
                Console.WriteLine("请输入运算符(+,-,*,/)：");
                switch (Char.Parse(Console.ReadLine()))
                {
                    case '+':
                        Console.WriteLine($"Result:{finalnum1}+{finalnum2}=" + (finalnum1 + finalnum2));
                        break;
                    case '-':
                        Console.WriteLine($"Result:{finalnum1}-{num2}=" + (finalnum1 - finalnum2));
                        break;
                    case '*':
                        Console.WriteLine($"Result:{finalnum1}*{finalnum2}=" + (finalnum1 * finalnum2));
                        break;
                    case '/':
                        while (finalnum2 == 0)
                        {
                            Console.WriteLine("除数不能为0！请重新输入第二个数字：");
                            num2 = Console.ReadLine();
                            while (!double.TryParse(num2, out finalnum2))
                            {
                                Console.WriteLine("输入无效值！请重新输入：");
                                num2 = Console.ReadLine();
                            }
                        }
                        Console.WriteLine($"Result:{finalnum1}/{finalnum2}=" + (finalnum1 / finalnum2));
                        break;
                    default:
                        Console.WriteLine("输入了非法运算符！");
                        break;
                }
                Console.WriteLine("按任意键继续或打出“end”退出计算器");
                if (Console.ReadLine() == "end")
                    flag = true;

            }

        }
    }
}
