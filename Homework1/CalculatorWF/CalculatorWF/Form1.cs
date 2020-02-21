using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Calculate()
        {
            double num1 = 0, num2 = 0, result = 0;
            bool flag = false;
            string op;
            if (!double.TryParse(this.textBox1.Text, out num1))
            {
                MessageBox.Show("输入错误！请在第一个输入框输入正确数字");
                flag = true;
            }
            if (!double.TryParse(this.textBox2.Text, out num2))
            {
                MessageBox.Show("输入错误！请在第二个输入框输入正确数字");
                flag = true; result.ToString();
            }
            if (flag)
                return;
            try
            {
                op = this.comboBox1.SelectedItem.ToString();
                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            MessageBox.Show("除0错误！请重新输入除数");
                            return;
                        }
                        result = num1 / num2;
                        break;
                    default:
                        MessageBox.Show("请选择运算符！");
                        return;
                }
            }
            catch 
            {
                MessageBox.Show("请选择正确运算符！");
                return;
            }

            this.textBox3.Text = result.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
