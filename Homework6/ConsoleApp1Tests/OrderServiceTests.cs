using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void addTest()
        {
            //正确输入
            Assert.AreEqual(OrderService.add(1, 0),OrderDetails.Lists[3]+OrderDetails.Lists[0]);
            //错误输入
           // Assert.AreEqual(OrderService.add(1, 0), OrderDetails.Lists[3]);
        }

        [TestMethod()]
        public void deleteTest()
        {
            Assert.AreEqual(OrderService.delete(0, 0), OrderDetails.Lists[1]);
           // Assert.AreEqual(OrderService.delete(0, 0), OrderDetails.Lists[0] + OrderDetails.Lists[1]);
        }

        [TestMethod()]
        public void AdjustTest()
        {
            bool a = false, b = false;
            if (OrderService.Adjust(0, 0, 2)== OrderDetails.Lists[1] + OrderDetails.Lists[2])
            {
                a = true;
            }
            if (OrderService.Adjust(0, 0, 2)== OrderDetails.Lists[0] + OrderDetails.Lists[1])
            {
                b = true;
            }
            Assert.IsTrue(a);
            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void ExportTest()
        {
            string s2 = @".\OrderLists.xml";
            List<CreatOrders> OrderList = new List<CreatOrders>();
            OrderList.Add(new CreatOrders(OrderDetails.List1[0] + OrderDetails.List1[1]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[3]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[2] + OrderDetails.List1[3]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[1]));
            OrderService.Export(OrderList);
            String s1 = File.ReadAllText("OrderLists.xml");
            Assert.AreEqual(s1, s2);
            bool a = false;
            if (s1 == s2)
            {
                a = true;
            }
            Assert.IsTrue(a);
        }

        [TestMethod()]
        public void ImportTest()
        {
            CreatOrders[] OrderLists = OrderService.Import("OrderLists.xml") as CreatOrders[];
            List<CreatOrders> OrderList = new List<CreatOrders>();
            OrderList.Add(new CreatOrders(OrderDetails.List1[0] + OrderDetails.List1[1]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[3]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[2] + OrderDetails.List1[3]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[1]));
            bool a = false;
            if (OrderLists[0] == OrderList[0]&& OrderLists[1] == OrderList[1]&&
                OrderLists[2] == OrderList[2]&& OrderLists[3] == OrderList[3])
            {
                a = true;
            }
            Assert.IsTrue(a);
        }
    }
}