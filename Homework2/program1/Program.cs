using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SelNum();    //选择一个数的素数因子
            SelArr();    //数组的排序，求和，求平均
            ToSelect();   //不是埃式筛法
            AiSelect();   //埃式筛法
        }
        //数
        static void SelNum()
        {
            Console.Write("Please input a int:");
            int a = Int32.Parse(Console.ReadLine());
            bool b = false;
            bool c = true;
            for (int i = 2; i <= a; i++)
            {
                c = true;
                for (int j = 2; j <i; j++)
                {
                    if(i==2)
                    {
                        break;
                    }
                    if(i%j==0)
                    {
                        c = false;
                        break;
                    }
                }
                if (c&& (a % i == 0))
                {
                    Console.Write("\n");
                    Console.Write($"{i} ");
                    b = true;
                }
            }
            if (!b)
            {
                Console.Write("Not found!");
            }
        }
        //数组
        static void SelArr()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=0;j<(arr.Length-i-1);j++)
                {
                    if(arr[j]<arr[j+1])
                    {
                        int m = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = m;
                    }
                }
            }
            double sum = 0;
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write($"{arr[i]}  ");
                sum += arr[i];
            }
            Console.Write("Sum of the arr is:" + sum);
            Console.Write("\nThe average of the arr is:" + sum / arr.Length);
        }
        //筛法1,不是埃式筛法
        static void ToSelect()
        {
            bool m = false;
            for(int i=2;i<=100;i++)
            {
                if (i==2)
                {
                    Console.Write("2-100内的素数有;2  ");
                }
                else
                {
                    for (int j = 2; j < i; j++)
                    {
                        m = false;
                        if (i % j==0)
                        {
                            break;
                        }
                        m = true;
                    }
                    if(m)
                    {
                        Console.Write($"{i}  ");
                    }
                }

            }
        }
        //埃式筛法
        static void AiSelect()
        {
            int[] Num = new int[99];
            for (int j = 0; j <= 98; j++)   //创建数组
            {
                Num[j] = j + 2;

            }
            int sum = 0;    //记录第i删除个数
            int s = 0;    //记录前i-1删除总数
            int m = 0;    //实时记录删除总数
            for (int i=2;i<=100;i++)
            {
                if(i==2)
                {
                    Console.Write("2-100内的素数有:");
                }
                sum = 0;
                for (int k = 0; k <= 98 - s; k++)
                {

                    Num[k - sum] = Num[k];
                    if ((Num[k] % i == 0) && (Num[k] != i))
                    {                                                
                        sum++;
                        m++;
                    }
                }
                s = m;
            }
            for (int i = 0; i <= 98 - m; i++)
            {
                Console.Write(Num[i] + "  ");
            }
        }
    }
}
