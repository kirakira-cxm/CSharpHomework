using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProgram.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service = new OrderService();
        Order o1 = new Order("blossom", 123,null);

        [TestInitialize()]
        public void init()
        {
            service.AddOrder(o1);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order o = new Order("kira", 1234,null);
            service.AddOrder(o);
            CollectionAssert.Contains(service.OrderData, o);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Order o2 = new Order("biu", 456,null);
            service.AddOrder(o2);
            CollectionAssert.Contains(service.OrderData, o2);
            service.RemoveOrder(o2);
            CollectionAssert.Contains(service.OrderData, o2);
        }


        [TestMethod()]
        public void ModifyOrderTest()
        {
            Order o1 = new Order("blossom1", 123,null);
            service.ModifyOrder(o1);
            Assert.AreEqual(o1.clientID, service.OrderData[0].clientID);

        }

        [TestMethod()]
        public void SearchByOrderIDTest()
        {
            List<Order> testOrders = service.SearchByOrderID(123);
            Assert.AreEqual(testOrders[0], service.OrderData[0]);
        }

        [TestMethod()]
        public void SearchByClientTest()
        {
            
            List<Order> testOrders = service.SearchByClient("blossom");
            Assert.AreEqual(testOrders[0], service.OrderData[0]);
        }

        [TestMethod()]
        public void SearchByGoodsNameTest()
        {
            OrderItem item1 = new OrderItem("apple",2,2);
            service.OrderData[0].AddItem(item1);
            List<Order> testOrders = service.SearchByGoodsName("apple");
            Assert.AreEqual(testOrders[0], service.OrderData[0]);

        }

        
    }
}