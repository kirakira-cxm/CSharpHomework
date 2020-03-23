using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderProgram
{
    /*
     * 订单：订单号，商品名，客户，金额，数量
     */
   public class Order
    {
        
        public string clientID { get; set; }
        public int OrderID { get; set; }
        public List<OrderItem> OrderList = new List<OrderItem>();
        public Order() { }

       public Order(string cid,int oid)
        {
            clientID = cid;
            OrderID = oid;
        }
        public int sumPrice()
        {
            int sum = 0;
                foreach (OrderItem temp in OrderList)
                {
                    sum += temp.goodsPrice * temp.goodsQuan;
                }
                return sum;
           
           
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.clientID == clientID && m.OrderID == OrderID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            foreach (OrderItem temp in OrderList)
            {
                Console.WriteLine(temp);
            }
            return "订单号" +OrderID + " 订单客户："+clientID ;
             
            
        }
    }
   public class OrderItem
    {
        //订单明细类存储商品名，商品单价与商品数量
        
        public string goodsName { get; set; }
        public int goodsQuan { get; set; }
        public int goodsPrice { get; set; }
        public OrderItem() { }
        public OrderItem(string gn,int gq,int gp) {
            goodsName = gn;
            goodsQuan = gq;
            goodsPrice = gp;
        }
        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null &&m.goodsName==goodsName&& m.goodsPrice == goodsPrice && m.goodsQuan == goodsQuan ;
         
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {

            return "商品名：" + goodsName + " 商品数量：" + goodsQuan + " 商品单价：" + goodsPrice;
             
        }
    }
     public class OrderService
    {
        public   List<Order> OrderData = new List<Order>();
        public void AddOrder(Order order, string gn, int gq, int gp) {

            Order newOrder = order;
            OrderItem newOrderItem = new OrderItem(gn, gq, gp);
            if (!OrderData.Contains(newOrder))
            {
                OrderData.Add(newOrder);
            }
            else
            {
                foreach (Order temp1 in OrderData)
                {
                    if (newOrder.Equals(temp1))
                        newOrder = temp1;
                }
            }
            if (!newOrder.OrderList.Contains(newOrderItem))
            {
                newOrder.OrderList.Add(newOrderItem);
            }
            else
            {
                Console.WriteLine(gn + gq + gp + "该订单已经添加过");
            }

        }
        public void RemoveOrder(Order order) {
            try
            {
                OrderData.Remove(order);
            }
            catch {
                Console.WriteLine("删除错误");
            }

        }
        public void ModifyOrder(Order order, string gn, int gq, int gp, string newgn, int newgq, int newgp) {

            OrderItem modifiedOrderItem = new OrderItem(gn, gq, gp);
            try
            {
                foreach (OrderItem temp in order.OrderList)
                {
                    if (temp.Equals(modifiedOrderItem))
                    {
                        temp.goodsName = newgn;
                        temp.goodsQuan = newgq;
                        temp.goodsPrice = newgp;
                    }
                }
            }
            catch
            {
                Console.WriteLine("修改错误");
            }

        }
        public List<Order> SearchByOrderID(int orderID) {
            var result = OrderData.Where(o => o.OrderID == orderID).OrderBy(o => o.sumPrice());
            List<Order> list = result.ToList();
            return list;
            
        }
        public List<Order> SearchByClient(string clientID)
        {
            var result = OrderData.Where(o => o.clientID == clientID).OrderBy(o => o.sumPrice());
            List<Order> list = result.ToList();
            return list;
        }
            public List<Order> SearchByGoodsName(string name)
        {
            var result = OrderData.Where(o => o.OrderList.Exists(item => item.goodsName == name));
            List<Order> list = result.ToList();
            return list;
        }
        public void Sort()
        {
            OrderData.Sort((o1, o2) => o1.OrderID - o2.OrderID);
        }
        public void Export(string path)
        { 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, OrderData);
            }
        }
        public void Import(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> orders = (List<Order>)xmlSerializer.Deserialize(fs);
                
            }
        }

        public override string ToString()
        {
           foreach(Order temp1 in OrderData)
            {
               Console.WriteLine(temp1);
            }
            return "以上为目前添加订单";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order("blossom", 456);
            Order o2 = new Order("chord", 123);
            OrderService service = new OrderService();
            service.AddOrder(o1, "苹果", 10, 10);
            service.AddOrder(o1, "苹果", 12, 10);
            service.AddOrder(o1, "苹果", 12, 10);
            service.AddOrder(o1, "梨子", 4, 5);
            service.AddOrder(o2, "西瓜", 2, 15);
            Console.WriteLine(service);
            service.Sort();
            Console.WriteLine(service);
            service.ModifyOrder(o1, "苹果", 10, 10,"苹果",3,17);
            Console.WriteLine(service);
        }
    }
}
