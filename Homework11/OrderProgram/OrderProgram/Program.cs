using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        private List<OrderItem> orderlist;
        [Key]
        public int OrderID { get; set; }
        public string clientID { get; set; }

        public List<OrderItem> OrderList
        {   get { return orderlist; }
            set { orderlist = value; }
        }
        public Order() { }
        public Order(string cid, int oid)
        {
            clientID = cid;
            OrderID = oid;
            
        }
        public Order(string cid,int oid,List<OrderItem> items)
        {
            clientID = cid;
            OrderID = oid;
            OrderList = items;
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

        public void AddItem(OrderItem item)
        {
            
            using (var db=new OrderContext())
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderID == this.OrderID);
                order.OrderList.Add(item);
                db.items.Add(item);
                int result=db.SaveChanges();
                if (result <= 0)
                    Console.WriteLine("添加失败");
                
            }
        }

        public void RemoveItem(OrderItem item)
        {
            using (var db = new OrderContext())
            {
                
                var deleteitem = db.items.FirstOrDefault(i => i.itemID == item.itemID);
                db.items.Remove(deleteitem);
                int result = db.SaveChanges();
                if (result <= 0)
                    Console.WriteLine("删除失败");
            }
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
        [Key]
        public int itemID { get; set; }
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
       
        public void AddOrder(Order order) {

            using (var db = new OrderContext())
            {
                db.Orders.Add(order);
                int result = db.SaveChanges();
                if (result <= 0)
                    Console.WriteLine("添加订单失败");
            }

        }
        public void RemoveOrder(Order order) {
            using (var db = new OrderContext())
            {
                var deleteorder = db.Orders.Include("OrderList").FirstOrDefault(o => o.OrderID == order.OrderID && o.clientID == order.clientID);
                if (deleteorder != null)
                {
                    db.Orders.Remove(deleteorder);
                    int result=db.SaveChanges();
                    if (result <= 0)
                        Console.WriteLine("删除订单失败");
                    return;
                }
                Console.WriteLine("删除订单失败");
            }

        }
        public void ModifyOrder(int orderid,string clienid,Order order) {

            using( var db=new OrderContext())
            {
                var oldorder = db.Orders.Include("OrderList").FirstOrDefault(o => o.clientID == clienid && o.OrderID == orderid);
                if (oldorder != null)
                {
                    oldorder.OrderID = order.OrderID;
                    oldorder.clientID = order.clientID;
                    oldorder.OrderList = order.OrderList;
                    int result = db.SaveChanges();
                    if (result <= 0)
                        Console.WriteLine("订单修改失败");
                    return;
                }
                Console.WriteLine("订单修改失败");
            }


        }
        public List<Order> SearchByOrderID(int orderID) {
            using (var db = new OrderContext()) {
                List<Order> list = db.Orders.Where(o => o.OrderID == orderID).ToList();
            return list; }
            
        }
        public List<Order> SearchByClient(string clientID)
        {
            using (var db = new OrderContext())
            {
                List<Order> list = db.Orders.Where(o => o.clientID == clientID).ToList();
                return list;
            }
        }
            public List<Order> SearchByGoodsName(string name)
        {
            using (var db = new OrderContext()) {
                var result = db.Orders.Where(o => o.OrderList.Exists(item => item.goodsName == name));
                List<Order> list = result.ToList();
                return list;
            }
        }

        public List<Order> SearchAll()
        {
            using (var db=new OrderContext())
            {
                var result = db.Orders;
                List<Order> list = result.ToList();
                return list;
            }
        }
       
        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (var db = new OrderContext())
            {
                List<Order> orderList = db.Orders.ToList();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orderList);
                }
            }
        }
        public void Import(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> importedOrderList = (List<Order>)xmlSerializer.Deserialize(fs);
                for (int i = 0; i < importedOrderList.Count; i++)
                {
                    AddOrder(importedOrderList[i]);
                }
            }
        }

        public override string ToString()
        {
            using (var db = new OrderContext()) {
                foreach (Order temp1 in db.Orders)
                {
                    Console.WriteLine(temp1);
                }
                return "以上为目前添加订单";
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order("blossom", 456,null);
            Order o2 = new Order("chord", 123, null);
            OrderService service = new OrderService();
            service.AddOrder(o1);
            service.AddOrder(o2);
            OrderItem item1 = new OrderItem("apple", 12, 12);
            o1.AddItem(item1);
            
           // Console.WriteLine(service);
        }
    }
}
