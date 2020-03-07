using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    //订单管理
    public class Order : OrderDetails
    {
        public static string[] OrderId = new string[] { "0", "1", "2", "3" };
        public static string[] Names=new string[]{"张三","李四","小红","小明"};
       
        public static string MySort(string m)    //查找
        {
            List<string> myList = new List<string>();
            for(int i=0;i<=3;i++)
            {
                myList.Add($"{OrderId[i]} {Names[i]} {List1[i]}{AllCost[i]}");
            }
            var a = from n in OrderId where n == m orderby n select n;
            foreach(string n in a)
            {
                for(int i=0;i<=3;i++)
                {
                    if (n == OrderId[i])
                        return $"{OrderId[i]} {Names[i]} {List1[i]}";
                }
            }
            var a1 = from n in Names where n == m orderby n select n;
            foreach (string n in a1)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (n == Names[i])
                        return $"{OrderId[i]} {Names[i]} {List1[i]}";
                }
            }
            var a2 = from n in List1 where n == m orderby n select n;
            foreach (string n in a2)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (n == List1[i])
                        return $"{OrderId[i]} {Names[i]} {List1[i]}";
                }
            }
            return " ";
        }
        public static string SelectCost()
        {
            GetCost();
            var b = from n in AllCost where n > 10000 orderby n descending select n;
            foreach (var n in b)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (n == AllCost[i])
                    {
                        return $"{OrderId[i]} {Names[i]} {List1[i]}";
                    }
                }
            }
            return "All cost greater than 1000 is not found!";
        }

    }
    public class OrderDetails
    {
        public static string[] Lists = new string[] { "Apple $8 ", "meat $10 ", "pants $30 ", "cake $10 "," " };
        public static int[] perCost = new int[] { 8, 10, 30, 10 ,0};
        public static string[] List1 = new string[] { $"{Lists[0]} { Lists[1]}", $"{Lists[3]}",
             $"{Lists[2]} { Lists[3]}", $"{ Lists[1]}"};
        public static int[] AllCost = new int[] { 0, 0, 0, 0 };
        public static void GetCost()
        {
            for (int i = 0; i <= 3; i++)
            {
                for(int j=0;j<=4;j++)
                {
                    for(int k=0;k<=3;k++)
                    if((List1[k]==Lists[i]+Lists[j])||(List1[k]+" "==Lists[i]+Lists[j]))
                        {
                            AllCost[k] = perCost[i] + perCost[j];
                        }

                }
            }
        }
        
    }
  
    class Program
    {
       
        static int Main(string[] args)
        {
            //订单管理
           
            Console.WriteLine(Order.MySort("1"));
            Console.WriteLine(Order.SelectCost()); 
            return 0;
        }
    }
}
