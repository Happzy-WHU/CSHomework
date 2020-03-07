using System;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    //订单管理
    public class Order:OrderDetails
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Orders { get; set; }
        public Order(string ID,string Name,string Orders)
        {
            this.ID = ID;
            this.Name = Name;
            this.Orders = Orders;
        }
        public static List<string> myList = new List<string>();
        public Order() { }
        public static string[] List2 = new string[] { "张三", "李四", "小红", "小明" };
        public static string MySort(string m)    //查找
        {
            for (int i = 0; i <= 3; i++)
            {
                myList.Add($"{i + 1} {List2[i]} {List1[i]}");
            }
            for (int i = 0; i <= 3; i++)
            {
                if (m == $"{i + 1}" || m == List1[i] || m == List2[i])
                {
                    return myList[i];
                }
            }
            return " ";
        }
    }
    
    public class OrderDetails
    {
        public static string[] Lists = new string[] { "Apple $8 ", "meat $10 ", "pants $30 ", "cake $10 "," " };
        [Key]
        public static string[] List1 = new string[] { $"{Lists[0]} { Lists[1]}", $"{Lists[3]}",
             $"{Lists[2]} { Lists[3]}", $"{ Lists[1]}"};
    }
    public class CreatOrders    //创建订单
    {
        public string List1;
        public CreatOrders(string s)
        {
            this.List1 = s;
        }
        public CreatOrders() { }
    }
    public class OrderService : Order
    {
        public static string add(int i, int j)  //从i的订单加上j订单
        {
            List1[i] += Lists[j];
            return List1[i];
        }
        public static string delete(int m, int n)   //从m的订单中删除n订单
        {
            int a = List1[m].IndexOf($"{Lists[n]}");
            if (a == -1)
                return "Detail n isn't in m";
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        for (int k = 0; k <= 4; k++)
                        {
                            for (int l = 0; l <= 4; l++)
                            {
                                if (List1[m] == Lists[i] )   //m的订单为List[i]
                                {
                                    if (i == n) { return "NULL Detail"; }
                                    else { return "n isn't in m"; }
                                }

                                if (List1[m] == Lists[i] + Lists[j] )  //两个空格，即m的订单为Lists[i]+Lists[j]
                                {
                                    if (i == n) { return $"{Lists[j]}"; }
                                    if (j == n) { return $"{Lists[i]}"; }
                                    return "n isn't in m";
                                }
                                if (List1[m] == Lists[i] + Lists[j] + Lists[k] )
                                {
                                    if (i == n) { return $"{Lists[j]}" + $"{Lists[k]}"; }
                                    if (j == n) { return $"{Lists[i]}" + $"{Lists[k]}"; }
                                    if (k == n) { return $"{Lists[i]}" + $"{Lists[j]}"; }
                                    return "n isn't in m";
                                }
                            }
                        }
                    }
                }
                return " ";
            }
        }
        public static string Adjust(int i,int m,int n)
        {

            delete(i, m);
            add(i, n);
            return List1[i];
        }
        public static void Export(object obj)
        {
            

            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream("OrderLists.xml", FileMode.Create))
            {
                xs.Serialize(fs, obj);
            }
        }
        public static object Import(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(CreatOrders[]));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                object obj = xs.Deserialize(fs);
                return obj;
            }
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            //订单管理
            OrderService.add(1, 0);
            OrderService.delete(1, 0);
            OrderService.Adjust(0,0,2);
            Order.MySort("1");
            //序列化
            List<CreatOrders> OrderList = new List<CreatOrders>();
            OrderList.Add(new CreatOrders(OrderDetails.List1[0] + OrderDetails.List1[1]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[3] ));
            OrderList.Add(new CreatOrders(OrderDetails.List1[2] + OrderDetails.List1[3]));
            OrderList.Add(new CreatOrders(OrderDetails.List1[1] ));
            OrderService.Export(OrderList);
            String s = File.ReadAllText("OrderLists.xml");
            Console.WriteLine(s);                    //输出序列化后的内容
            //反序列化
            CreatOrders []OrderLists = OrderService.Import("OrderLists.xml") as CreatOrders[];
            foreach(CreatOrders Co in OrderLists)
            {
                Console.WriteLine(Co.List1);
            }
            return;
        }
    }
}
