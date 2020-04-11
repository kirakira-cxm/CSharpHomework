using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderProgram;

namespace OrderServiceWFA
{
    public partial class Form2 : Form
    {
        OrderService orders = new OrderService();
        BindingSource bindingSource = new BindingSource();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(OrderService service,BindingSource bs)
        {
            InitializeComponent();
            orders = service;
            bindingSource = bs;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int orderID = int.Parse(orderIDText.Text);
            string clientID = clientIDText.Text; 
            Order order = new Order(clientID, orderID);
            try { orders.AddOrder(order); }
            catch
            {
                MessageBox.Show("该订单用户已存在");
            }

            bindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int orderID = int.Parse(orderIDText.Text);
            string clientID = clientIDText.Text;
            string iname = itemNameText.Text;
            int iprice = int.Parse(itemPriceText.Text);
            int iquan = int.Parse(itemQuanText.Text);
            OrderItem item = new OrderItem(iname, iquan, iprice);
            Order order = new Order(clientID, orderID);
            order.AddItem(item);
            
            try { orders.ModifyOrder(order); }
            catch
            {
                MessageBox.Show("该订单不存在，删除失败");
            }
            bindingSource.ResetBindings(false);
        }
    }
}
