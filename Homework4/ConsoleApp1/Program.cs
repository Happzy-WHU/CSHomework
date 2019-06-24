using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   //闹钟
   public class Timer
    {
        public static string GetCount()
        {
            DateTime dt = new DateTime(2018, 10, 8, 20,12,20);//设置闹钟时间
            TimeSpan ts = dt - DateTime.Now;
            if (ts.TotalSeconds<0)
            {
                return "Wrong Time!";
            }
            return ts.TotalSeconds.ToString("#0.000");
        }

    }
    //订单管理
    public class Order:OrderDetails
    {
        public static string[] List1 = new string[] { $"{Lists[0]} { Lists[1]}", $"{Lists[3]}",
             $"{Lists[2]} { Lists[3]}", $"{ Lists[1]}"};
        public static string MySort(string m)    //查找
        {
            List<string> myList = new List<string>();
            myList.Add($"001 张三 {List1[0]}");
            myList.Add($"002 李四 {List1[1]}");
            myList.Add($"003 小红 {List1[2]}");
            myList.Add($"004 小明 {List1[3]}");
            if(m=="001"|| m == "张三"||m ==List1[0])
            {
                return myList[0];
            }
            if (m == "002" || m == "李四"|| m == List1[1])
            {
                return myList[1];
            }
            if (m == "003" || m == "小红"|| m == List1[0])
            {
                return myList[2];
            }
            if (m == "004" || m == "小明"|| m == List1[0])
            {
                return myList[3];
            }
            return " ";
        }
       
    }
    public class OrderDetails
    {
          public static string[] Lists = new string[] { "Apple $8", "meat $10", "pants $30", "cake $10" };
        
    }
    public class OrderService : Order
    {
        public static string add(int i,int j)
        {
            List1[j] += Lists[i];
            return List1[j];
        }
        public static string delete(int m,int n)
        {
            for(int k=0;k<=3;k++)
            {
                if (List1[n] == Lists[k])
                    return null;
            }
            int i = 0, j = 1;
            for (; i <= 3; i++)
            {
                for (; j <= 3; j++)
                {
                    if (List1[n] == Lists[i] +" "+ Lists[j])
                        break;
                }
            }
            List1[n] = null;
            if (Lists[i] != Lists[m])
            {
                List1[n] += " "+Lists[i];
                return List1[n];
            }
            else
            {
                Lists[n] += " "+Lists[j];
                return List1[n];
            }
        }
        public static string Adjust(int m)
        {
            
            delete(1,m);
            add(1, m);
            return List1[m];
        }
        
    }
    class Program:Timer
    {
       
        static void Main(string[] args)
        {
            //闹钟
            if(GetCount()== "Wrong Time!")
            {
                Console.WriteLine("Wrong Time!");
            }
            else
            {
                double m = double.Parse(GetCount());
                Thread.Sleep((int)(m * 1000));
                Console.WriteLine("Time out!");
            }
            //订单管理
            OrderService.delete(1, 0);
            OrderService.add(1, 0);
            OrderService.Adjust(0);
            Order.MySort("001");
        }
    }
}
