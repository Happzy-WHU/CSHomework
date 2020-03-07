using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            //Parallel.ForEach(, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (item, pls, i) =>
            //{

            //});
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            string startUr2 = "http://www.baidu.com/";
            string startUr3 = "http://www.cnblogs.com/";
            string startUr4 = "http://daohang.qq.com/";
            string startUr5 = "http://www.runoob.com/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            myCrawler.urls.Add(startUr2, false);
            myCrawler.urls.Add(startUr3, false);
            myCrawler.urls.Add(startUr4, false);
            myCrawler.urls.Add(startUr5, false);
            new Thread(myCrawler.Crawl).Start();
            return;
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了。。。。");
            List<string> al = new List<string>(count);
            foreach (string url in urls.Keys)
            {
                al.Add(url);
                count++;
            }
            ParallelLoopResult result = Parallel.ForEach<string>(al, (string url) =>
            {
                Parse(DownLoad(url));
                Console.WriteLine("爬行" + url + "页面！");
            });
            Console.WriteLine("爬行结束");
            Console.ReadKey();
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding=Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HERF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
    
    
}
