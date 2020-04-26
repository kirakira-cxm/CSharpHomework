using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
/*
 * 改进书上例子9-10的爬虫程序。
 （1）优选爬取起始网站上的网页 
（2）只有当爬取的是html文本时，才解析并爬取下一级URL。
 （3）相对地址转成绝对地址进行爬取。
（4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。
（5）使用并行处理进行优化
 * */

namespace SimpleCrawler
{
    class Crawler
    {
        public Hashtable urls = new Hashtable();
        public int count { get; set; }
        public string startUrl { get; set; }

        public Crawler()
        {
            count = 0;
        }

           //起始网页
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            myCrawler.startUrl = "http://www.cnblogs.com/dstang2000/"; 
            if (args.Length >= 1) myCrawler.startUrl = args[0];
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            try { urls.Add(startUrl, false); }
            catch
            {
                Console.WriteLine("初始地址为空或已添加");
            }
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    else
                    {
                        current = url;
                        break;
                    }
                }

                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html);//解析,并加入新的链接
                Console.WriteLine("爬行结束");
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

      
        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(.html|.HTML)[""']";            //(2)
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');

                if (strRef.Length == 0)
                    continue;

                Uri uri = new Uri(startUrl);
                string domain = uri.Scheme + "://" + uri.Host;

                if (Regex.IsMatch(strRef, "^[/]"))                   //(3)
                    strRef = domain + strRef;
                else if (!Regex.IsMatch(strRef, "^(http|HTTP)"))
                    strRef = startUrl + "/" + strRef;

                if (Regex.IsMatch(strRef, domain))               //(1)
                    continue;
                if (urls[strRef] == null)
                    urls[strRef] = false;
            }
        }
    }
}
