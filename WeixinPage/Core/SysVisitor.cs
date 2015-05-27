using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using WeixinPage;

namespace WeixinPage.Core
{
    class SysVisitor
    {
        private static SysVisitor visit = null;
        public static SysVisitor Current
        {
            get
            {
                if (visit == null)
                    visit = new SysVisitor();

                return visit;
            }
        }
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="appid">appid</param>
        /// <param name="secret">appsecret</param>
        /// <returns></returns>
        public string Get_Access_token(string appid, string appsecret)
        {
            string secondappid = INIFile.ContentValue("weixin", "secondappid");
            if (appid.ToLower() == secondappid.ToLower())
            {
                string ls_time = INIFile.ContentValue("weixin", "gettime");
                Decimal ldt;
                try
                {
                    ldt = Convert.ToDecimal(ls_time);
                    if (Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss")) - ldt < 7100)//每两个小时刷新一次
                    {
                        return INIFile.ContentValue("weixin", "access_token");
                    }
                }
                catch
                { }
            }
            string ls_appid = appid.Replace(" ", "");
            string ls_secret = appsecret.Replace(" ", "");
            string access_token = "";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", ls_appid, ls_secret);
            string json_access_token = GetPageInfo(url);
            //DataTable dt = Json.JsonToDataTable(json_access_token);
            DataTable dt = JsonHelper.JsonToDataTable(json_access_token);
            try
            {
                access_token = dt.Rows[0]["access_token"].ToString();
            }
            catch
            {
                return "";
            }
            INIFile.SetINIString("weixin", "gettime", DateTime.Now.ToString("yyyyMMddHHmmss"));
            INIFile.SetINIString("weixin", "access_token", access_token);
            INIFile.SetINIString("weixin", "secondappid", ls_appid);

            return access_token;
        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        public string Get_Access_token()
        {
            string ls_appid = INIFile.ContentValue("weixin", "Appid");
            string ls_secret = INIFile.ContentValue("weixin", "AppSecret");
            return Get_Access_token(ls_appid, ls_secret);
        }

        /// <summary>
        /// Get方法请求url并接收返回消息
        /// </summary>
        /// <param name="strUrl">Url地址</param>
        /// <returns></returns>
        public string GetPageInfo(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string ret = string.Empty;
            Stream s;
            string StrDate = "";
            string strValue = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                s = response.GetResponseStream();
                ////在这儿处理返回的文本
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);

                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate + "\r\n";
                }
                //strValue = Reader.ReadToEnd();
            }
            return strValue;
        }

        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="posturl">URL</param>
        /// <param name="postData">Post数据</param>
        /// <returns></returns>
        public string PostPage(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetFormatStr(string str)
        {
            if ("" == str)
                return "";
            else
            {
                str = str.Trim();
                str = str.Replace("’", "'");
                str = str.Replace("〈", "<");
                str = str.Replace("〉", ">");
                str = str.Replace("，", ",");
                return str;
            }
        }
        string ls_username = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string Wx_username
        {
            get
            {
                return ls_username;
            }
            set
            {
                ls_username = value;
            }
        }
        string ls_openid = "";
        /// <summary>
        /// Openid
        /// </summary>
        public string Wx_openid
        {
            get
            {
                return ls_openid;
            }
            set
            {
                ls_openid = value;
            }
        }
    }
}
