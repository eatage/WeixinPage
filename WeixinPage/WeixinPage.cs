using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using WeixinPage.Core;
using System.Collections;
using System.Collections.Generic;

namespace WeixinPage
{
    public partial class WeixinPage : Form
    {
        public WeixinPage()
        {
            Disable();
            this.Icon = Resource1.ico;
            InitializeComponent();
            this.skinEngine1.SkinFile = "Longhorn.ssk";
            BindMenu();
            WriteINI();
            Initialization();
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.Visible = true;
        }

        #region 创建ini文件
        /// <summary>
        /// 创建ini文件
        /// </summary>
        private void WriteINI()
        {
            string ls_INIFile = Application.StartupPath + "\\Config.ini";
            if (!File.Exists(ls_INIFile))
            {
                StringBuilder str = new StringBuilder();
                str.Append(";内容由程序自动生成，请不要修改此文件内容\r\n");
                str.Append("[weixin]\r\n");
                str.Append("Appid=请输入你的Appid\r\n");
                str.Append("AppSecret=请输入你的AppSecret\r\n");
                str.Append("updatemode=1\r\n");
                str.Append("gettime=\r\n");
                str.Append("access_token=\r\n");
                str.Append("secondappid=");
                //StreamWriter sw = default(StreamWriter);
                //sw = File.CreateText(ls_INIFile);
                //sw.WriteLine(str.ToString());
                //sw.Close();
                File.WriteAllText(ls_INIFile, str.ToString(), Encoding.Unicode);
                File.SetAttributes(ls_INIFile, FileAttributes.Hidden);
                string icon = "ico.ico";
                notifyIcon1.Icon = new Icon(icon);
                //File.SetAttributes(ls_INIFile, FileAttributes.Hidden);//隐藏该文件
            }
        }
        #endregion

        #region 添加菜单类型绑定
        /// <summary>
        /// 添加菜单类型绑定
        /// </summary>
        private void BindMenu()
        {

            DataTable dt = TypeMenu.Typemenu();
            DataTable dt1 = TypeMenu.Typemenu();
            DataTable dt2 = TypeMenu.Typemenu();
            DataTable dt3 = TypeMenu.Typemenu();
            DataTable dt4 = TypeMenu.Typemenu();
            DataTable dt5 = TypeMenu.Typemenu();
            DataTable dt6 = TypeMenu.Typemenu();
            DataTable dt7 = TypeMenu.Typemenu();
            DataTable dt8 = TypeMenu.Typemenu();
            DataTable dt9 = TypeMenu.Typemenu();
            DataTable dt10 = TypeMenu.Typemenu();
            DataTable dt11 = TypeMenu.Typemenu();
            DataTable dt12 = TypeMenu.Typemenu();
            DataTable dt13 = TypeMenu.Typemenu();
            DataTable dt14 = TypeMenu.Typemenu();
            DataTable dt01 = TypeMenu.Typemenu();
            DataTable dt02 = TypeMenu.Typemenu();
            DataTable dt03 = TypeMenu.Typemenu();

            comboBox1.DataSource = dt01;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "value";
            comboBox2.DataSource = dt02;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "value";
            comboBox3.DataSource = dt03;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "value";

            comboBox11.DataSource = dt;
            comboBox11.DisplayMember = "name";
            comboBox11.ValueMember = "value";
            comboBox12.DataSource = dt1;
            comboBox12.DisplayMember = "name";
            comboBox12.ValueMember = "value";
            comboBox13.DataSource = dt2;
            comboBox13.DisplayMember = "name";
            comboBox13.ValueMember = "value";
            comboBox14.DataSource = dt3;
            comboBox14.DisplayMember = "name";
            comboBox14.ValueMember = "value";
            comboBox15.DataSource = dt4;
            comboBox15.DisplayMember = "name";
            comboBox15.ValueMember = "value";

            comboBox21.DataSource = dt5;
            comboBox21.DisplayMember = "name";
            comboBox21.ValueMember = "value";
            comboBox22.DataSource = dt6;
            comboBox22.DisplayMember = "name";
            comboBox22.ValueMember = "value";
            comboBox23.DataSource = dt7;
            comboBox23.DisplayMember = "name";
            comboBox23.ValueMember = "value";
            comboBox24.DataSource = dt8;
            comboBox24.DisplayMember = "name";
            comboBox24.ValueMember = "value";
            comboBox25.DataSource = dt9;
            comboBox25.DisplayMember = "name";
            comboBox25.ValueMember = "value";

            comboBox31.DataSource = dt10;
            comboBox31.DisplayMember = "name";
            comboBox31.ValueMember = "value";
            comboBox32.DataSource = dt11;
            comboBox32.DisplayMember = "name";
            comboBox32.ValueMember = "value";
            comboBox33.DataSource = dt12;
            comboBox33.DisplayMember = "name";
            comboBox33.ValueMember = "value";
            comboBox34.DataSource = dt13;
            comboBox34.DisplayMember = "name";
            comboBox34.ValueMember = "value";
            comboBox35.DataSource = dt14;
            comboBox35.DisplayMember = "name";
            comboBox35.ValueMember = "value";
        }
        #endregion

        #region 是否可用
        /// <summary>
        /// 是否可用
        /// </summary>
        private void Disable()
        {
            string datetime = DateTime.Now.ToString("yyyyMMdd");
            if (Convert.ToInt32(datetime) - 20151120 > 0)
            {
                this.Controls.Clear();
                this.Width = 400;
                this.Height = 200;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MinimizeBox = false;
                this.Text = "提示：";
                Label lb = new Label();
                lb.Top = 20;
                lb.Left = 5;
                lb.Width = 400;
                lb.Height = 200;
                lb.Text = "软件试用期已到谢谢你的使用,联系QQ:346414491获取正式版";
                lb.Font = new Font("宋体", 20, FontStyle.Bold);
                lb.ForeColor = Color.Blue;
                //lb.Font.Size = new Font("隶书", 9, FontStyle.Bold);
                //添加控件
                this.Controls.Add(lb);
                this.skinEngine1.SkinFile = "DiamondBlue.ssk";
                return;
            }
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialization()
        {
            string ls_tempFolder = System.AppDomain.CurrentDomain.BaseDirectory + "菜单备份\\";
            if (!Directory.Exists(ls_tempFolder))
            {
                Directory.CreateDirectory(ls_tempFolder);
            }
            try
            {
                if (INIFile.ContentValue("weixin", "debug") == "true")
                {
                    btn_kf.Visible = true;
                    button1.Visible = true;
                }
            }
            catch { }
            txt_appid.Text = INIFile.ContentValue("weixin", "Appid");
            txt_secret.Text = INIFile.ContentValue("weixin", "AppSecret");
            switch (INIFile.ContentValue("weixin", "updatemode"))
            {
                case "1":
                    radioButton1.Checked = true;
                    break;
                case "2":
                    radioButton2.Checked = true; break;
                case "3":
                    break;
            }
        }
        #endregion

        #region 执行Post或Get请求
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
                //Response.Write(content);
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }
        /// <summary>
        /// Get方法
        /// </summary>
        /// <param name="strUrl">Url地址</param>
        /// <returns></returns>
        private static string getPageInfo(string url)
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
        #endregion

        #region 将控件中的数据转为json数据
        /// <summary>
        /// 将控件中的数据转为json数据
        /// </summary>
        private string Of_Get_Menu()
        {
            JObject json = JObject.Parse(TypeMenu.ExampleMenu());

            #region 判断菜单类型
            int page1 = 0, page2 = 0, page3 = 0;
            if (comboBox1.SelectedValue.ToString() != "" && txt_key1.Text != "")
            {
                page1 = 1;
            }
            if (comboBox2.SelectedValue.ToString() != "" && txt_key2.Text != "")
            {
                page2 = 1;
            }
            if (comboBox3.SelectedValue.ToString() != "" && txt_key3.Text != "")
            {
                page3 = 1;
            }
            if (page1 == 1 && page2 == 0 && page3 == 0)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(1));
            }
            if (page1 == 0 && page2 == 1 && page3 == 0)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(2));
            }
            if (page1 == 0 && page2 == 0 && page3 == 1)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(3));
            }
            if (page1 == 1 && page2 == 1 && page3 == 0)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(12));
            }
            if (page1 == 1 && page2 == 0 && page3 == 1)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(13));
            }
            if (page1 == 0 && page2 == 1 && page3 == 1)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(23));
            }
            if (page1 == 1 && page2 == 1 && page3 == 1)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu(123));
            }
            if (page1 == 0 && page2 == 0 && page3 == 0)
            {
                json = JObject.Parse(TypeMenu.ExampleMenu());
            }
            #endregion

            #region 从控件获取最新菜单等待上传
            if (comboBox1.SelectedValue.ToString() == "" || txt_key1.Text == "")
            {
                #region 一级菜单（1）
                json["button"][0]["name"] = txt_name1.Text.Trim();
                if (json["button"][0]["name"].ToString() == "")
                { MessageBox.Show("请输入一级菜单名等其他信息\r\n或点击拉取菜单获取服务器端的菜单。", "提示：第一个一级菜单名不能为空"); return null; }

                json["button"][0]["sub_button"][0]["type"] = comboBox11.SelectedValue.ToString();
                json["button"][0]["sub_button"][0]["name"] = txt_name11.Text.Trim();
                string type11 = "";
                if (comboBox11.SelectedValue.ToString() == "view") { type11 = "url"; } else { type11 = "key"; }
                json["button"][0]["sub_button"][0][type11] = txt_key11.Text.Trim();

                json["button"][0]["sub_button"][1]["type"] = comboBox12.SelectedValue.ToString();
                json["button"][0]["sub_button"][1]["name"] = txt_name12.Text.Trim();
                string type12 = "";
                if (comboBox12.SelectedValue.ToString() == "view") { type12 = "url"; } else { type12 = "key"; }
                json["button"][0]["sub_button"][1][type12] = txt_key12.Text.Trim();

                json["button"][0]["sub_button"][2]["type"] = comboBox13.SelectedValue.ToString();
                json["button"][0]["sub_button"][2]["name"] = txt_name13.Text.Trim();
                string type13 = "";
                if (comboBox13.SelectedValue.ToString() == "view") { type13 = "url"; } else { type13 = "key"; }
                json["button"][0]["sub_button"][2][type13] = txt_key13.Text.Trim();

                json["button"][0]["sub_button"][3]["type"] = comboBox14.SelectedValue.ToString();
                json["button"][0]["sub_button"][3]["name"] = txt_name14.Text.Trim();
                string type14 = "";
                if (comboBox14.SelectedValue.ToString() == "view") { type14 = "url"; } else { type14 = "key"; }
                json["button"][0]["sub_button"][3][type14] = txt_key14.Text.Trim();

                json["button"][0]["sub_button"][4]["type"] = comboBox15.SelectedValue.ToString();
                json["button"][0]["sub_button"][4]["name"] = txt_name15.Text.Trim();
                string type15 = "";
                if (comboBox15.SelectedValue.ToString() == "view") { type15 = "url"; } else { type15 = "key"; }
                json["button"][0]["sub_button"][4][type15] = txt_key15.Text.Trim();


                if (comboBox11.SelectedValue.ToString() == "" || txt_name11.Text.Trim() == "")
                {
                    try
                    {
                        json["button"][0]["sub_button"][0].Remove();
                        json["button"][0]["sub_button"][0].Remove();
                        json["button"][0]["sub_button"][0].Remove();
                        json["button"][0]["sub_button"][0].Remove();
                        json["button"][0]["sub_button"][0].Remove();
                    }
                    catch { } //如果type和value有任何一项未填则删除该条菜单                
                }
                if (comboBox12.SelectedValue.ToString() == "" || txt_name12.Text.Trim() == "")
                {
                    try
                    {
                        json["button"][0]["sub_button"][1].Remove();
                        json["button"][0]["sub_button"][1].Remove();
                        json["button"][0]["sub_button"][1].Remove();
                        json["button"][0]["sub_button"][1].Remove();
                    }
                    catch { } //如果type和value有任何一项未填则删除该条菜单                
                }
                if (comboBox13.SelectedValue.ToString() == "" || txt_name13.Text.Trim() == "")
                {
                    try
                    {
                        json["button"][0]["sub_button"][2].Remove();
                        json["button"][0]["sub_button"][2].Remove();
                        json["button"][0]["sub_button"][2].Remove();
                    }
                    catch { } //如果type和value有任何一项未填则删除该条菜单
                }
                if (comboBox14.SelectedValue.ToString() == "" || txt_name14.Text.Trim() == "")
                {
                    try
                    {
                        json["button"][0]["sub_button"][3].Remove();
                        json["button"][0]["sub_button"][3].Remove();
                    }
                    catch { } //如果type和value有任何一项未填则删除该条菜单                           
                }
                if (comboBox15.SelectedValue.ToString() == "" || txt_name15.Text.Trim() == "")
                {
                    try { json["button"][0]["sub_button"][4].Remove(); }
                    catch { } //如果type和value有任何一项未填则删除该条菜单                
                }
                #endregion
            }
            else
            {
                json["button"][0]["type"] = comboBox1.SelectedValue.ToString();
                json["button"][0]["name"] = txt_name1.Text.Trim();
                string type1 = "";
                if (comboBox1.SelectedValue.ToString() == "view") { type1 = "url"; } else { type1 = "key"; }
                json["button"][0][type1] = txt_key1.Text.Trim();
            }
            if (comboBox2.SelectedValue.ToString() == "" || txt_key2.Text == "")
            {
                #region 一级菜单（2）
                json["button"][1]["name"] = txt_name2.Text.Trim();
                if (json["button"][1]["name"].ToString() == "")
                {
                    if (MessageBox.Show("你没有设置第二个一级菜单名，或者你不需要第二个一级菜单，继续将只有第一个一级菜单及其子菜单生效", "要继续吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    { json["button"][1].Remove(); }
                    else { return null; }
                }
                try
                {
                    json["button"][1]["sub_button"][0]["type"] = comboBox21.SelectedValue.ToString();
                    json["button"][1]["sub_button"][0]["name"] = txt_name21.Text.Trim();
                    string type21 = "";
                    if (comboBox21.SelectedValue.ToString() == "view") { type21 = "url"; } else { type21 = "key"; }
                    json["button"][1]["sub_button"][0][type21] = txt_key21.Text.Trim();

                    json["button"][1]["sub_button"][1]["type"] = comboBox22.SelectedValue.ToString();
                    json["button"][1]["sub_button"][1]["name"] = txt_name22.Text.Trim();
                    string type22 = "";
                    if (comboBox22.SelectedValue.ToString() == "view") { type22 = "url"; } else { type22 = "key"; }
                    json["button"][1]["sub_button"][1][type22] = txt_key22.Text.Trim();

                    json["button"][1]["sub_button"][2]["type"] = comboBox23.SelectedValue.ToString();
                    json["button"][1]["sub_button"][2]["name"] = txt_name23.Text.Trim();
                    string type23 = "";
                    if (comboBox23.SelectedValue.ToString() == "view") { type23 = "url"; } else { type23 = "key"; }
                    json["button"][1]["sub_button"][2][type23] = txt_key23.Text.Trim();

                    json["button"][1]["sub_button"][3]["type"] = comboBox24.SelectedValue.ToString();
                    json["button"][1]["sub_button"][3]["name"] = txt_name24.Text.Trim();
                    string type24 = "";
                    if (comboBox24.SelectedValue.ToString() == "view") { type24 = "url"; } else { type24 = "key"; }
                    json["button"][1]["sub_button"][3][type24] = txt_key24.Text.Trim();

                    json["button"][1]["sub_button"][4]["type"] = comboBox25.SelectedValue.ToString();
                    json["button"][1]["sub_button"][4]["name"] = txt_name25.Text.Trim();
                    string type25 = "";
                    if (comboBox25.SelectedValue.ToString() == "view") { type25 = "url"; } else { type25 = "key"; }
                    json["button"][1]["sub_button"][4][type25] = txt_key25.Text.Trim();


                    if (comboBox21.SelectedValue.ToString() == "" || txt_name21.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][1]["sub_button"][0].Remove();
                            json["button"][1]["sub_button"][0].Remove();
                            json["button"][1]["sub_button"][0].Remove();
                            json["button"][1]["sub_button"][0].Remove();
                            json["button"][1]["sub_button"][0].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单
                    }
                    if (comboBox22.SelectedValue.ToString() == "" || txt_name22.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][1]["sub_button"][1].Remove();
                            json["button"][1]["sub_button"][1].Remove();
                            json["button"][1]["sub_button"][1].Remove();
                            json["button"][1]["sub_button"][1].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                    if (comboBox23.SelectedValue.ToString() == "" || txt_name23.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][1]["sub_button"][2].Remove();
                            json["button"][1]["sub_button"][2].Remove();
                            json["button"][1]["sub_button"][2].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                    if (comboBox24.SelectedValue.ToString() == "" || txt_name24.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][1]["sub_button"][3].Remove();
                            json["button"][1]["sub_button"][3].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单

                    }
                    if (comboBox25.SelectedValue.ToString() == "" || txt_name25.Text.Trim() == "")
                    {
                        try { json["button"][1]["sub_button"][4].Remove(); }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                }
                catch { }
                #endregion
            }
            else
            {
                json["button"][1]["type"] = comboBox2.SelectedValue.ToString();
                json["button"][1]["name"] = txt_name2.Text.Trim();
                string type2 = "";
                if (comboBox2.SelectedValue.ToString() == "view") { type2 = "url"; } else { type2 = "key"; }
                json["button"][1][type2] = txt_key2.Text.Trim();
            }
            if (comboBox3.SelectedValue.ToString() == "" || txt_key3.Text == "")
            {
                #region 一级菜单（3）
                //当只设置一级菜单是，由于已经remove json["button"][1].Remove();
                //此时不存在json["button"][2]
                try
                {
                    json["button"][2]["name"] = txt_name3.Text.Trim();
                }
                catch
                {
                    json["button"][1].Remove();
                    return json.ToString();
                }
                if (json["button"][2]["name"].ToString() == "")
                {
                    if (MessageBox.Show("你没有设置第三个一级菜单名，或者你不需要第三个一级菜单，继续第三个一级菜单及其子菜单将不生效", "要继续吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    { json["button"][2].Remove(); }
                    else { return null; }
                }
                try
                {
                    json["button"][2]["sub_button"][0]["type"] = comboBox31.SelectedValue.ToString();
                    json["button"][2]["sub_button"][0]["name"] = txt_name31.Text.Trim();
                    string type31 = "";
                    if (comboBox31.SelectedValue.ToString() == "view") { type31 = "url"; } else { type31 = "key"; }
                    json["button"][2]["sub_button"][0][type31] = txt_key31.Text.Trim();

                    json["button"][2]["sub_button"][1]["type"] = comboBox32.SelectedValue.ToString();
                    json["button"][2]["sub_button"][1]["name"] = txt_name32.Text.Trim();
                    string type32 = "";
                    if (comboBox32.SelectedValue.ToString() == "view") { type32 = "url"; } else { type32 = "key"; }
                    json["button"][2]["sub_button"][1][type32] = txt_key32.Text.Trim();

                    json["button"][2]["sub_button"][2]["type"] = comboBox33.SelectedValue.ToString();
                    json["button"][2]["sub_button"][2]["name"] = txt_name33.Text.Trim();
                    string type33 = "";
                    if (comboBox33.SelectedValue.ToString() == "view") { type33 = "url"; } else { type33 = "key"; }
                    json["button"][2]["sub_button"][2][type33] = txt_key33.Text.Trim();

                    json["button"][2]["sub_button"][3]["type"] = comboBox34.SelectedValue.ToString();
                    json["button"][2]["sub_button"][3]["name"] = txt_name34.Text.Trim();
                    string type34 = "";
                    if (comboBox34.SelectedValue.ToString() == "view") { type34 = "url"; } else { type34 = "key"; }
                    json["button"][2]["sub_button"][3][type34] = txt_key34.Text.Trim();

                    json["button"][2]["sub_button"][4]["type"] = comboBox35.SelectedValue.ToString();
                    json["button"][2]["sub_button"][4]["name"] = txt_name35.Text.Trim();
                    string type35 = "";
                    if (comboBox35.SelectedValue.ToString() == "view") { type35 = "url"; } else { type35 = "key"; }
                    json["button"][2]["sub_button"][4][type35] = txt_key35.Text.Trim();


                    if (comboBox31.SelectedValue.ToString() == "" || txt_name31.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][2]["sub_button"][0].Remove();
                            json["button"][2]["sub_button"][0].Remove();
                            json["button"][2]["sub_button"][0].Remove();
                            json["button"][2]["sub_button"][0].Remove();
                            json["button"][2]["sub_button"][0].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                    if (comboBox32.SelectedValue.ToString() == "" || txt_name32.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][2]["sub_button"][1].Remove();
                            json["button"][2]["sub_button"][1].Remove();
                            json["button"][2]["sub_button"][1].Remove();
                            json["button"][2]["sub_button"][1].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单
                    }
                    if (comboBox33.SelectedValue.ToString() == "" || txt_name33.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][2]["sub_button"][2].Remove();
                            json["button"][2]["sub_button"][2].Remove();
                            json["button"][2]["sub_button"][2].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                    if (comboBox34.SelectedValue.ToString() == "" || txt_name34.Text.Trim() == "")
                    {
                        try
                        {
                            json["button"][2]["sub_button"][3].Remove();
                            json["button"][2]["sub_button"][3].Remove();
                        }
                        catch { } //如果type和value有任何一项未填则删除该条菜单
                    }
                    if (comboBox35.SelectedValue.ToString() == "" || txt_name35.Text.Trim() == "")
                    {
                        try { json["button"][2]["sub_button"][4].Remove(); }
                        catch { } //如果type和value有任何一项未填则删除该条菜单                    
                    }
                }
                catch { }
                #endregion
            }
            else
            {
                json["button"][2]["type"] = comboBox3.SelectedValue.ToString();
                json["button"][2]["name"] = txt_name3.Text.Trim();
                string type3 = "";
                if (comboBox3.SelectedValue.ToString() == "view") { type3 = "url"; } else { type3 = "key"; }
                json["button"][2][type3] = txt_key3.Text.Trim();
            }
            #endregion

            return json.ToString();
        }
        #endregion

        #region 更新菜单
        /// <summary>
        /// 更新菜单
        /// </summary>
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string ls_appid = txt_appid.Text.Trim();
            string ls_secret = txt_secret.Text.Trim();
            string access_token = "";
            string menu = "";
            if (ls_appid.Length != 18 || ls_secret.Length != 32)
            {
                MessageBox.Show("你的Appid或AppSecret不对，请检查后再操作");
                return;
            }
            //FileStream fs1 = new FileStream("menu.txt", FileMode.Open);//原方法，从txt文件中获取菜单示例
            //StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("GBK"));
            //string menu = sr.ReadToEnd();
            //sr.Close();
            //fs1.Close();
            //JObject json = JObject.Parse(menu);
            try
            {
                string ls_json = Of_Get_Menu();
                if (ls_json == null)
                {
                    MessageBox.Show("输入有误，请检查后在进行此操作！", "提示：");
                    return;
                }
                JObject json = JObject.Parse(ls_json);//new JObject(Of_Get_Menu());
                menu = json.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            access_token = SysVisitor.Current.Get_Access_token(ls_appid, ls_secret);
            if (access_token == "") { MessageBox.Show("Appid或AppSecret不对，请检查后再操作"); return; }
            string ls_Message = "";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_token);
            ls_Message = PostPage(url, menu);
            DataTable dt = JsonHelper.JsonToDataTable(ls_Message);
            try
            {
                string errmsg = dt.Rows[0]["errcode"].ToString();
                if (errmsg == "ok")
                {
                    string ls_tempFolder = System.AppDomain.CurrentDomain.BaseDirectory + "菜单备份\\";
                    string file = DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + "备份.txt";
                    if (!Directory.Exists(ls_tempFolder))
                    {
                        Directory.CreateDirectory(ls_tempFolder);
                    }

                    StreamWriter mySw;
                    mySw = File.CreateText(ls_tempFolder + file);
                    mySw.Write(menu);
                    mySw.Close();
                    //MessageBox.Show("写入成功");

                    MessageBox.Show("菜单更新成功！并且已备份到 " + ls_tempFolder, "提示：");
                }
                else
                { MessageBox.Show(ls_Message); }
                //Clear();
            }
            catch
            {
                MessageBox.Show(ls_Message);
            }

            INIFile.SetINIString("weixin", "Appid", txt_appid.Text.Trim());
            INIFile.SetINIString("weixin", "AppSecret", txt_secret.Text.Trim());

        }
        #endregion

        #region 备份菜单
        private void btn_backup_Click(object sender, EventArgs e)
        {
            string menu = "";
            try
            {
                string ls_json = Of_Get_Menu();
                JObject json = JObject.Parse(ls_json);
                menu = json.ToString();
            }
            catch { return; }
            try
            {
                    string ls_tempFolder = System.AppDomain.CurrentDomain.BaseDirectory + "菜单备份\\";
                    string file = DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + "备份.txt";
                    if (!Directory.Exists(ls_tempFolder))
                    {
                        Directory.CreateDirectory(ls_tempFolder);
                    }
                    StreamWriter mySw;
                    mySw = File.CreateText(ls_tempFolder + file);
                    mySw.Write(menu);
                    mySw.Close();
                    MessageBox.Show("菜单成功备份到 " + ls_tempFolder, "提示：");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 删除菜单
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除后将不可恢复，删除前请做好数据备份", "你确定要删除吗？", MessageBoxButtons.YesNo) != DialogResult.Yes)
            { return; }
            string ls_appid = txt_appid.Text.Trim();
            string ls_secret = txt_secret.Text.Trim();
            string ls_Message = "";
            string access_token = "";
            access_token = SysVisitor.Current.Get_Access_token(ls_appid, ls_secret);
            if (access_token == "") { MessageBox.Show("Appid或AppSecret不对，请检查后再操作"); return; }
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", access_token);
            ls_Message = getPageInfo(url);
            MessageBox.Show(ls_Message);
        }
        #endregion

        #region 从微信获取菜单并给控件赋值
        private void Btn_select_Click(object sender, EventArgs e)
        {
            string ls_appid = txt_appid.Text.Trim();
            string ls_secret = txt_secret.Text.Trim();
            if (ls_appid.Length != 18 || ls_secret.Length != 32)
            {
                MessageBox.Show("你的Appid或AppSecret不对，请检查后再操作");
                return;
            }
            string ls_Message = "";
            string access_token = "";
            access_token = SysVisitor.Current.Get_Access_token(ls_appid, ls_secret);
            if (access_token == "") { MessageBox.Show("Appid或AppSecret不对，请检查后再操作"); return; }
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token);
            ls_Message = getPageInfo(url);//获取当前菜单
            JObject json = JObject.Parse(ls_Message);
            #region 拉取菜单信息并为控件赋值
            ////////////////////////////////////////////
            try{txt_name1.Text= json["menu"]["button"][0]["name"].ToString();}
            catch { MessageBox.Show("该微信号未上传菜单或菜单已删除，请重新设置全部菜单"); btn_update.Enabled = true; return; }//没有任何菜单
            try
            {
                comboBox11.SelectedValue = json["menu"]["button"][0]["sub_button"][0]["type"].ToString();
                txt_name11.Text = json["menu"]["button"][0]["sub_button"][0]["name"].ToString();
                try { txt_key11.Text = json["menu"]["button"][0]["sub_button"][0]["url"].ToString(); }
                catch { txt_key11.Text = json["menu"]["button"][0]["sub_button"][0]["key"].ToString(); }

                comboBox12.SelectedValue = json["menu"]["button"][0]["sub_button"][1]["type"].ToString();
                txt_name12.Text = json["menu"]["button"][0]["sub_button"][1]["name"].ToString();
                try { txt_key12.Text= json["menu"]["button"][0]["sub_button"][1]["url"].ToString(); }
                catch {  txt_key12.Text= json["menu"]["button"][0]["sub_button"][1]["key"].ToString(); }

                comboBox13.SelectedValue = json["menu"]["button"][0]["sub_button"][2]["type"].ToString();
                txt_name13.Text = json["menu"]["button"][0]["sub_button"][2]["name"].ToString();
                try {  txt_key13.Text=json["menu"]["button"][0]["sub_button"][2]["url"].ToString(); }
                catch {  txt_key13.Text= json["menu"]["button"][0]["sub_button"][2]["key"].ToString(); }

                comboBox14.SelectedValue = json["menu"]["button"][0]["sub_button"][3]["type"].ToString();
                txt_name14.Text = json["menu"]["button"][0]["sub_button"][3]["name"].ToString();
                try {  txt_key14.Text= json["menu"]["button"][0]["sub_button"][3]["url"].ToString(); }
                catch {  txt_key14.Text= json["menu"]["button"][0]["sub_button"][3]["key"].ToString(); }

                comboBox15.SelectedValue = json["menu"]["button"][0]["sub_button"][4]["type"].ToString();
                txt_name15.Text = json["menu"]["button"][0]["sub_button"][4]["name"].ToString();
                try {  txt_key15.Text= json["menu"]["button"][0]["sub_button"][4]["url"].ToString(); }
                catch {  txt_key15.Text= json["menu"]["button"][0]["sub_button"][4]["key"].ToString(); }
            }
            catch 
            {
                try
                {
                    comboBox1.SelectedValue = json["menu"]["button"][0]["type"].ToString();
                    txt_name1.Text = json["menu"]["button"][0]["name"].ToString();
                    try { txt_key1.Text = json["menu"]["button"][0]["url"].ToString(); }
                    catch { txt_key1.Text = json["menu"]["button"][0]["key"].ToString(); }
                }
                catch { }
            }
            ////////////////////////////////////////////////
            try
            {
                txt_name2.Text= json["menu"]["button"][1]["name"].ToString();

                comboBox21.SelectedValue= json["menu"]["button"][1]["sub_button"][0]["type"].ToString();
                txt_name21.Text= json["menu"]["button"][1]["sub_button"][0]["name"].ToString();
                try { txt_key21.Text= json["menu"]["button"][1]["sub_button"][0]["url"].ToString(); }
                catch { txt_key21.Text= json["menu"]["button"][1]["sub_button"][0]["key"].ToString(); }

                comboBox22.SelectedValue= json["menu"]["button"][1]["sub_button"][1]["type"].ToString();
                txt_name22.Text= json["menu"]["button"][1]["sub_button"][1]["name"].ToString();
                try { txt_key22.Text=  json["menu"]["button"][1]["sub_button"][1]["url"].ToString(); }
                catch { txt_key22.Text=  json["menu"]["button"][1]["sub_button"][1]["key"].ToString(); }

                comboBox23.SelectedValue= json["menu"]["button"][1]["sub_button"][2]["type"].ToString();
                txt_name23.Text= json["menu"]["button"][1]["sub_button"][2]["name"].ToString();
                try { txt_key23.Text= json["menu"]["button"][1]["sub_button"][2]["url"].ToString(); }
                catch { txt_key23.Text=  json["menu"]["button"][1]["sub_button"][2]["key"].ToString(); }

                comboBox24.SelectedValue= json["menu"]["button"][1]["sub_button"][3]["type"].ToString();
                txt_name24.Text=  json["menu"]["button"][1]["sub_button"][3]["name"].ToString();
                try { txt_key24.Text=  json["menu"]["button"][1]["sub_button"][3]["url"].ToString(); }
                catch { txt_key24.Text=  json["menu"]["button"][1]["sub_button"][3]["key"].ToString(); }

                comboBox25.SelectedValue= json["menu"]["button"][1]["sub_button"][4]["type"].ToString();
                txt_name25.Text=  json["menu"]["button"][1]["sub_button"][4]["name"].ToString();
                try { txt_key25.Text=  json["menu"]["button"][1]["sub_button"][4]["url"].ToString(); }
                catch { txt_key25.Text=  json["menu"]["button"][1]["sub_button"][4]["key"].ToString(); }
            }
            catch 
            {
                try
                {
                    comboBox2.SelectedValue = json["menu"]["button"][1]["type"].ToString();
                    txt_name2.Text = json["menu"]["button"][1]["name"].ToString();
                    try { txt_key2.Text = json["menu"]["button"][1]["url"].ToString(); }
                    catch { txt_key2.Text = json["menu"]["button"][1]["key"].ToString(); }
                }
                catch { }
            }//没有菜单二

            /////////////////////////////////
            try
            {
                txt_name3.Text = json["menu"]["button"][2]["name"].ToString();

                comboBox31.SelectedValue = json["menu"]["button"][2]["sub_button"][0]["type"].ToString();
                txt_name31.Text = json["menu"]["button"][2]["sub_button"][0]["name"].ToString();
                try { txt_key31.Text = json["menu"]["button"][2]["sub_button"][0]["url"].ToString(); }
                catch { txt_key31.Text = json["menu"]["button"][2]["sub_button"][0]["key"].ToString(); }

                comboBox32.SelectedValue = json["menu"]["button"][2]["sub_button"][1]["type"].ToString();
                txt_name32.Text = json["menu"]["button"][2]["sub_button"][1]["name"].ToString();
                try { txt_key32.Text = json["menu"]["button"][2]["sub_button"][1]["url"].ToString(); }
                catch { txt_key32.Text = json["menu"]["button"][2]["sub_button"][1]["key"].ToString(); }

                comboBox33.SelectedValue = json["menu"]["button"][2]["sub_button"][2]["type"].ToString();
                txt_name33.Text = json["menu"]["button"][2]["sub_button"][2]["name"].ToString();
                try { txt_key33.Text = json["menu"]["button"][2]["sub_button"][2]["url"].ToString(); }
                catch { txt_key33.Text = json["menu"]["button"][2]["sub_button"][2]["key"].ToString(); }

                comboBox34.SelectedValue = json["menu"]["button"][2]["sub_button"][3]["type"].ToString();
                txt_name34.Text = json["menu"]["button"][2]["sub_button"][3]["name"].ToString();
                try { txt_key34.Text = json["menu"]["button"][2]["sub_button"][3]["url"].ToString(); }
                catch { txt_key34.Text = json["menu"]["button"][2]["sub_button"][3]["key"].ToString(); }

                comboBox35.SelectedValue = json["menu"]["button"][2]["sub_button"][4]["type"].ToString();
                txt_name35.Text = json["menu"]["button"][2]["sub_button"][4]["name"].ToString();
                try { txt_key35.Text = json["menu"]["button"][2]["sub_button"][4]["url"].ToString(); }
                catch { txt_key35.Text = json["menu"]["button"][2]["sub_button"][4]["key"].ToString(); }
            }
            catch 
            {
                try
                {
                    comboBox3.SelectedValue = json["menu"]["button"][2]["type"].ToString();
                    txt_name3.Text = json["menu"]["button"][2]["name"].ToString();
                    try { txt_key3.Text = json["menu"]["button"][2]["url"].ToString(); }
                    catch { txt_key3.Text = json["menu"]["button"][2]["key"].ToString(); }
                }
                catch { }
            }
            #endregion
            INIFile.SetINIString("weixin", "Appid", txt_appid.Text.Trim());
            INIFile.SetINIString("weixin", "AppSecret", txt_secret.Text.Trim());
            GC.Collect();
        }
        #endregion

        #region 查看全局返回码
        private void btn_error_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://mp.weixin.qq.com/wiki/17/fa4e1434e57290788bde25603fa2fcbd.html");
        }
        #endregion

        #region 为comboBox控件设置SelectedIndexChanged事件

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "" || comboBox1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                tabControl21.Enabled = true;
            }
            else
            {
                tabControl21.Enabled = false;
                if (comboBox1.Text == "跳转URL")
                { lab_1.Text = "Url："; }
                else
                { lab_1.Text = "Key："; }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue.ToString() == "" || comboBox2.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                tabControl22.Enabled = true;
            }
            else
            {
                tabControl22.Enabled = false;
                if (comboBox2.Text == "跳转URL")
                { lab_2.Text = "Url："; }
                else
                { lab_2.Text = "Key："; }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue.ToString() == "" || comboBox3.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                tabControl23.Enabled = true;
            }
            else
            {
                tabControl23.Enabled = false;
                if (comboBox3.Text == "跳转URL")
                { lab_3.Text = "Url："; }
                else
                { lab_3.Text = "Key："; }
            }
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "跳转URL")
            { lab_11.Text = "Url："; }
            else
            { lab_11.Text = "Key："; }
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text == "跳转URL")
            { lab_12.Text = "Url："; }
            else
            { lab_12.Text = "Key："; }
        }
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text == "跳转URL")
            { lab_13.Text = "Url："; }
            else
            { lab_13.Text = "Key："; }
        }
        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text == "跳转URL")
            { lab_14.Text = "Url："; }
            else
            { lab_14.Text = "Key："; }
        }
        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text == "跳转URL")
            { lab_15.Text = "Url："; }
            else
            { lab_15.Text = "Key："; }
        }
        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox21.Text == "跳转URL")
            { lab_21.Text = "Url："; }
            else
            { lab_21.Text = "Key："; }
        }
        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox22.Text == "跳转URL")
            { lab_22.Text = "Url："; }
            else
            { lab_22.Text = "Key："; }
        }
        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox23.Text == "跳转URL")
            { lab_23.Text = "Url："; }
            else
            { lab_23.Text = "Key："; }
        }
        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox24.Text == "跳转URL")
            { lab_24.Text = "Url："; }
            else
            { lab_24.Text = "Key："; }
        }
        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox25.Text == "跳转URL")
            { lab_25.Text = "Url："; }
            else
            { lab_25.Text = "Key："; }
        }
        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox31.Text == "跳转URL")
            { lab_31.Text = "Url："; }
            else
            { lab_31.Text = "Key："; }
        }
        private void comboBox32_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox32.Text == "跳转URL")
            { lab_32.Text = "Url："; }
            else
            { lab_32.Text = "Key："; }
        }
        private void comboBox33_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox33.Text == "跳转URL")
            { lab_33.Text = "Url："; }
            else
            { lab_33.Text = "Key："; }
        }
        private void comboBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox34.Text == "跳转URL")
            { lab_34.Text = "Url："; }
            else
            { lab_34.Text = "Key："; }
        }
        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox35.Text == "跳转URL")
            { lab_35.Text = "Url："; }
            else
            { lab_35.Text = "Key："; }
        }
        #endregion

        #region 选择文件
        private void btn_opentxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = Application.StartupPath + "\\菜单备份";
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "文本文件(*.txt)|*.txt";
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ls_file = fileDialog.FileName;
                    Lbl_folder.Text = ls_file;
                }
            }
            catch { }
        }
        #endregion

        #region 从文件更新菜单
        private void btn_updatefortxt_Click(object sender, EventArgs e)
        {
            string ls_file = Lbl_folder.Text;
            if (ls_file == "")
            {
                MessageBox.Show("请先选择文件");
                return;
            }
            string ls_appid = txt_appid.Text.Trim();
            string ls_secret = txt_secret.Text.Trim();
            string access_token = "";
            if (ls_appid.Length != 18 || ls_secret.Length != 32)
            {
                MessageBox.Show("你的Appid或AppSecret不对，请检查后再操作");
                return;
            }
            FileStream fs1 = new FileStream(ls_file, FileMode.Open);//原方法，从txt文件中获取菜单示例
            StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("utf-8"));
            string menu = sr.ReadToEnd();
            sr.Close();
            fs1.Close();
            try
            {
                JObject json = JObject.Parse(menu);
            }
            catch
            {
                MessageBox.Show("你选取的文件有误或文件已损坏，因为读取到的文件内容不符合微信菜单的格式");
                return;
            }
            access_token = SysVisitor.Current.Get_Access_token(ls_appid, ls_secret);
            if (access_token == "") { MessageBox.Show("Appid或AppSecret不对，请检查后再操作"); return; }
            string ls_Message = "";
            string url=string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_token);
            ls_Message = PostPage(url, menu);
            MessageBox.Show(ls_Message);
            Lbl_folder.Text = "";
            INIFile.SetINIString("weixin", "Appid", txt_appid.Text.Trim());
            INIFile.SetINIString("weixin", "AppSecret", txt_secret.Text.Trim());
        }
        #endregion

        #region 选择从控件处更新菜单
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_folder.Text = "";
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox1.Enabled = true;
            INIFile.SetINIString("weixin", "updatemode", "1");
            INIFile.SetINIString("weixin", "Appid", txt_appid.Text.Trim());
            INIFile.SetINIString("weixin", "AppSecret", txt_secret.Text.Trim());
        }
        #endregion

        #region 选择从文件处更新菜单
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_folder.Text = "";
            groupBox3.Enabled = false;
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
            INIFile.SetINIString("weixin", "updatemode", "2");
            INIFile.SetINIString("weixin", "Appid", txt_appid.Text.Trim());
            INIFile.SetINIString("weixin", "AppSecret", txt_secret.Text.Trim());
        }
        #endregion

        #region 界面初始化
        private void Clear()//重新载入
        {
            this.Controls.Clear();
            this.InitializeComponent();
            txt_appid.Text = INIFile.ContentValue("weixin", "Appid");
            txt_secret.Text = INIFile.ContentValue("weixin", "AppSecret");
            switch (INIFile.ContentValue("weixin", "updatemode"))
            {
                case "1":
                    radioButton1.Checked = true;
                    break;
                case "2":
                    radioButton2.Checked = true; break;
                case "3":
                    break;
            }
            #region 添加菜单类型绑定

            DataTable dt = TypeMenu.Typemenu();
            DataTable dt1 = TypeMenu.Typemenu();
            DataTable dt2 = TypeMenu.Typemenu();
            DataTable dt3 = TypeMenu.Typemenu();
            DataTable dt4 = TypeMenu.Typemenu();
            DataTable dt5 = TypeMenu.Typemenu();
            DataTable dt6 = TypeMenu.Typemenu();
            DataTable dt7 = TypeMenu.Typemenu();
            DataTable dt8 = TypeMenu.Typemenu();
            DataTable dt9 = TypeMenu.Typemenu();
            DataTable dt10 = TypeMenu.Typemenu();
            DataTable dt11 = TypeMenu.Typemenu();
            DataTable dt12 = TypeMenu.Typemenu();
            DataTable dt13 = TypeMenu.Typemenu();
            DataTable dt14 = TypeMenu.Typemenu();
            DataTable dt01 = TypeMenu.Typemenu();
            DataTable dt02 = TypeMenu.Typemenu();
            DataTable dt03 = TypeMenu.Typemenu();

            comboBox1.DataSource = dt01;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "value";
            comboBox2.DataSource = dt02;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "value";
            comboBox3.DataSource = dt03;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "value";

            comboBox11.DataSource = dt;
            comboBox11.DisplayMember = "name";
            comboBox11.ValueMember = "value";
            comboBox12.DataSource = dt1;
            comboBox12.DisplayMember = "name";
            comboBox12.ValueMember = "value";
            comboBox13.DataSource = dt2;
            comboBox13.DisplayMember = "name";
            comboBox13.ValueMember = "value";
            comboBox14.DataSource = dt3;
            comboBox14.DisplayMember = "name";
            comboBox14.ValueMember = "value";
            comboBox15.DataSource = dt4;
            comboBox15.DisplayMember = "name";
            comboBox15.ValueMember = "value";

            comboBox21.DataSource = dt5;
            comboBox21.DisplayMember = "name";
            comboBox21.ValueMember = "value";
            comboBox22.DataSource = dt6;
            comboBox22.DisplayMember = "name";
            comboBox22.ValueMember = "value";
            comboBox23.DataSource = dt7;
            comboBox23.DisplayMember = "name";
            comboBox23.ValueMember = "value";
            comboBox24.DataSource = dt8;
            comboBox24.DisplayMember = "name";
            comboBox24.ValueMember = "value";
            comboBox25.DataSource = dt9;
            comboBox25.DisplayMember = "name";
            comboBox25.ValueMember = "value";

            comboBox31.DataSource = dt10;
            comboBox31.DisplayMember = "name";
            comboBox31.ValueMember = "value";
            comboBox32.DataSource = dt11;
            comboBox32.DisplayMember = "name";
            comboBox32.ValueMember = "value";
            comboBox33.DataSource = dt12;
            comboBox33.DisplayMember = "name";
            comboBox33.ValueMember = "value";
            comboBox34.DataSource = dt13;
            comboBox34.DisplayMember = "name";
            comboBox34.ValueMember = "value";
            comboBox35.DataSource = dt14;
            comboBox35.DisplayMember = "name";
            comboBox35.ValueMember = "value";
            #endregion
        }
        #endregion

        private void WeixinPage_FormClosed(object sender, FormClosedEventArgs e)//关闭窗体
        {
            this.Dispose(true);
            Application.ExitThread();//释放资源
        }

        private void btn_kf_Click(object sender, EventArgs e)
        {
            string aa = Microsoft.VisualBasic.Interaction.InputBox("请输入值：", "提示：", "", 200, 200);
            if (aa != "10296")
            {
                MessageBox.Show("输入错误");
                btn_kf.Visible = false;
                return;
            }
            Kf_account kf = new Kf_account();
            kf.Show();
            //Formwork fw = new Formwork();
            //fw.Show();
        }

        private void WeixinPage_FormClosing(object sender, FormClosingEventArgs e)//关闭窗体前
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            { }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            { }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            Application.ExitThread();//释放资源
        }
        /// <summary>
        /// 最小化
        /// </summary>
        private void WeixinPage_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                try
                {
                    this.Hide();
                    this.notifyIcon1.Icon = this.Icon;
                    this.notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5, "提示：", "已最小化到任务栏，双击重新显示", ToolTipIcon.Info);
                }
                catch { }
            }
        }
        //测试
        private void button1_Click(object sender, EventArgs e)
        {
            string json = @"{
                        'tab':
                            [
                                {
                                'key':'123',
                                'value':'456'
                                },
                                {
                                'key':'123',
                                'value':456
                                }
                            ]
                        }";
            json = @"{'programmers':[
                    {'firstName':'Brett','lastName':'McLaughlin','email':'aaaa'},
                    {'firstName':'Jason','lastName':'Hunter','email':'bbbb'},
                    {'firstName':'Elliotte','lastName':'Harold','email':'cccc'}
                    ],
                    'authors':[
                    {'firstName':'Isaac','lastName':'Asimov','genre':'sciencefiction'},
                    {'firstName':'Tad','lastName':'Williams','genre':'fantasy'},
                    {'firstName':'Frank','lastName':'Peretti','genre':'christianfiction'}
                    ],
                    'musicians':[
                    {'firstName':'Eric','lastName':'Clapton','instrument':'guitar'},
                    {'firstName':'Sergei','lastName':'Rachmaninoff','instrument':'piano'}
                    ]}";
            DataSet dts = JsonHelper.JsonToDataSet(json);
            DataTable ldt = new DataTable();
            int i = dts.Tables.Count;
            //ldt = JsonHelper.JsonToDataTable(json);
            ldt = dts.Tables[0];
            ldt = dts.Tables[1];
            ldt = dts.Tables[2];
            string str = JsonHelper.DatatableToJson(ldt, "sb");
            if (ldt.Rows.Count > 0)
            {
                MessageBox.Show(str.ToString());
            }
        }
    }
}
