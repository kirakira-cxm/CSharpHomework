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
        [TestMethod()]
        public void AddOrderTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService testService = new OrderService();
            testService.AddOrder(o1, "苹果", 10, 10);
            testService.AddOrder(o1, "苹果", 10, 10);
            Assert.IsTrue(testService.OrderData.Contains(o1));
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService testService = new OrderService();
            testService.AddOrder(o1, "苹果", 10, 10);
            testService.RemoveOrder(o1);
            Assert.IsFalse(testService.OrderData.Contains(o1));
        }


        [TestMethod()]
        public void ModifyOrderTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService testService = new OrderService();
            testService.AddOrder(o1, "苹果", 10, 10);
            testService.ModifyOrder(o1, "苹果", 10, 10, "苹果", 12, 10);
            Assert.AreEqual(o1, testService.OrderData[0]);

        }

        [TestMethod()]
        public void SearchByOrderIDTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService service = new OrderService();
            service.AddOrder(o1, "苹果", 10, 10);
            List<Order> testOrders = service.SearchByOrderID(123);
            Assert.AreEqual(testOrders[0], service.OrderData[0]);
        }

        [TestMethod()]
        public void SearchByClientTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService service = new OrderService();
            service.AddOrder(o1, "苹果", 10, 10);
            List<Order> testOrders = service.SearchByClient("blossom");
            Assert.AreEqual(testOrders[0], service.OrderData[0]);
        }

        [TestMethod()]
        public void SearchByGoodsNameTest()
        {
            Order o1 = new Order("blossom", 123);
            OrderService service = new OrderService();
            service.AddOrder(o1, "苹果", 10, 10);
            List<Order> testOrders = service.SearchByGoodsName("苹果");
            Assert.AreEqual(testOrders[0], service.OrderData[0]);

        }

        [TestMethod()]
        public void SortTest()
        {
            Order o1 = new Order("blossom", 456);
            Order o2 = new Order("chord", 123);
            OrderService service = new OrderService();
            service.AddOrder(o1, "苹果", 10, 10);
            service.AddOrder(o2, "西瓜", 2, 15);
            service.Sort();

            Assert.IsTrue(o1==service.OrderData[1]&&o2==service.OrderData[0]);
        }
    }
}