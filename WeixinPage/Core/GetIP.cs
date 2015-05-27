using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeixinPage.Core
{
    class GetIP
    {
        public static string Getip()//判断是否联网
        {
            string strUrl = "http://www.ip138.com/ip2city.asp"; //获得IP的网址了

            Uri uri = new Uri(strUrl);
            System.Net.WebRequest wr = System.Net.WebRequest.Create(uri);
            System.IO.Stream s = wr.GetResponse().GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(s, Encoding.Default);
            string all = sr.ReadToEnd(); //读取网站的数据

            int i = all.IndexOf("[") + 1;
            string tempip = all.Substring(i, 15);
            string ip = tempip.Replace("]", "").Replace(" ", "");//找出i
            return ip;
        }
    }
}
