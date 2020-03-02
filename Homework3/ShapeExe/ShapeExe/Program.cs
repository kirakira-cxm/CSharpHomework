using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeExe
{
    interface Shape
    {
        double Area();
        bool isLegal();

    }

    class Rectangle:Shape       //实现Shape接口
    {
        private double sidea;
        private double sideb;
        public double Height { set; get; }
        public double Width { set; get; }
        public  Rectangle (double a,double b)
        {
            sidea = a;
            sideb = b;
            
        }
        public double Area()
        {
            if (isLegal())
                return sidea * sideb;
            else
                return -1;
        }
        public bool isLegal()
        {
            return sidea > 0 && sideb > 0;
         
        }
    }

    class Square : Shape  //正方形类继承长方形类
    {
        private double side;
        public double Side { set; get; }
        public Square (double a)
        {
            side = a;
            
           
        }
        public  double Area()
        {
             if (isLegal())
                  return side * side;
             else
                  return -1;
                
       
        }
        public  bool isLegal()
        {
            return side > 0;

        }

    }

    class Triangle : Shape
    {
        private double sidea;
        private double sideb;
        private double sidec;
        public double Sidea { set; get; }
        public double Sideb { set; get; }
        public double Sidec { set; get; }

        public Triangle(double a,double b,double c)
        {
            sidea = a;
            sideb = b;
            sidec = c;
            
        }
        public double Area()
        {
            if (isLegal())
            {
                double p = (sidea + sideb + sidec) / 2;
                double S = Math.Sqrt(p * (p - sidea) * (p - sideb) * (p - sidec));
                return S;
            }
            else return -1;
        }
        public bool isLegal()
        {
            return sidea > 0 && sideb > 0 && sidec > 0 && sidea + sideb > sidec && sideb + sidec > sidea && sidea + sidec > sideb;

        }

    }

    class ShapeFactory
    {
       
        public static Shape CreateShape(String type,double [] sides)     //参数为对象类型与边长数组
        {
            Shape product = null;
            switch (type)
            {
                case "r":
                    product = new Rectangle(sides[0], sides[1]);
                    break;
                case "s":
                    product = new Square(sides[0]);
                    break;
                case "t":
                    product = new Triangle(sides[0], sides[1], sides[2]);
                    break;
                default:
                    Console.WriteLine("输入形状错误！");
                    break;

            }
            return product;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] sides = new double[3];   //存放边长
            Shape[] products= new Shape[10];    //存放生成的对象
            double S = 0;     //对象的面积总和

            Console.WriteLine("开始生成形状对象，输入r,s,t生成对应的不同对象：");
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    sides[j] = new Random().Next(1, 20);     //边长随机生成
                }
                String p = Console.ReadLine();
                try
                {
                    products[i] = ShapeFactory.CreateShape(p, sides);
                    Console.WriteLine($"第{i + 1}个对象为{p},面积为{products[i].Area()}");
                    S += products[i].Area();
                }
                catch
                {
                    Console.WriteLine($"输入第{i + 1}个对象错误，默认面积为-1");
                    S += -1;
                }

            }

            Console.WriteLine($"总面积为{S}");

        }
    }
}
