using OrderProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderServiceWFA
{
    public partial class Form1 : Form
    {
        public OrderService orders = new OrderService();

        public Form1()
        {
            InitializeComponent();
        }

        
        private void createOrderButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(orders,orderBindingSource);
            f2.Owner = this;
            f2.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            OrderItem item1 = new OrderItem("apple", 10, 4);

            List<OrderItem> items = new List<OrderItem>();
            items.Add(item1);

            Order o1 = new Order("blossom", 456,items);
            
            orders.AddOrder(o1);
            orderBindingSource.DataSource = orders.OrderData;
           
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try {
                List<Order> results = orders.OrderData.Where(order => order.clientID == clientIDText.Text && order.OrderID == int.Parse(orderIDText.Text)).ToList();
                orderBindingSource.DataSource = results;
                foreach (Order temp in results)
                {
                    orderItembindingSource.DataSource = temp.OrderList;
                }
            }
            catch
            {
                MessageBox.Show("请输入完整订单信息");
            }
            
            
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(orders, orderBindingSource);
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<Order> results = orders.OrderData.Where(order => order.clientID == clientIDText.Text).ToList();
            orderBindingSource.DataSource = results;
            try
            {
                foreach (Order temp in results)
                {

                    orders.RemoveOrder(temp);

                }
                
            }
            catch
            {
                MessageBox.Show("该订单不存在，删除失败");
            }
            orderBindingSource.ResetBindings(false);
        }
    }
}
