using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeixinPage.Core;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace WeixinPage
{
    public partial class Kf_account : Form
    {
        string as_INIFile = Application.StartupPath + "\\user.ini";
        DataTable adt_user = new DataTable();

        public Kf_account()
        {
            BindUser();
        }

        private void BindUser()
        {
            if (!File.Exists(as_INIFile))
            {
                StringBuilder str = new StringBuilder();
                str.Append(";内容由程序自动生成，请不要修改此文件内容\r\n");
                str.Append("[total]\r\n");
                str.Append("total=\r\n");
                str.Append("[count]\r\n");
                str.Append("count=\r\n");
                str.Append("[user]\r\n");
                //StreamWriter sw = default(StreamWriter);
                //sw = File.CreateText(ls_INIFile);
                //sw.WriteLine(str.ToString());
                //sw.Close();
                File.WriteAllText(as_INIFile, str.ToString(), Encoding.Unicode);
                File.SetAttributes(as_INIFile, FileAttributes.Hidden);
            }
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Icon = Resource1.ico;
            lkl_num.Text = INIFile.ContentValue("total", "total", as_INIFile);
            lkl_num_c.Text = INIFile.ContentValue("count", "count", as_INIFile);
            pictureBox1.Visible = true;
            StreamReader sr = new StreamReader(as_INIFile, Encoding.Unicode);
            String line;
            int li_count = 0;
            adt_user.Columns.Clear();
            adt_user.Columns.Add("username", Type.GetType("System.String"));
            adt_user.Columns.Add("openid", Type.GetType("System.String"));
            while ((line = sr.ReadLine()) != null)
            {
                li_count++;
                if (li_count > 6)
                {
                    line = SysVisitor.Current.GetFormatStr(line);
                    DataRow newRow;
                    newRow = adt_user.NewRow();
                    newRow["username"] = line.Substring(0, line.LastIndexOf('=')).ToString();
                    newRow["openid"] = line.Substring(line.LastIndexOf('=') + 1).ToString();
                    adt_user.Rows.Add(newRow);
                }
            }
            sr.Close();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = adt_user;
            //dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            lbl_count.Text = "共" + (li_count - 6) + "行";
            pictureBox1.Visible = false;
        }

        private void btn_GetUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"拉取用户信息的速度取决于你的关注数与网络速度，
可能需要几分钟甚至更长时间。
使用此功能将消耗大量用户管理接口配额。
要继续此操作吗？", 
                 "提示：", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Thread thr = new Thread(Get_user_list);
            thr.Start();
        }

        private void Get_user_list()
        {

            File.Delete(as_INIFile);
            StringBuilder str = new StringBuilder();
            str.Append(";内容由程序自动生成，请不要修改此文件内容\r\n");
            str.Append("[total]\r\n");
            str.Append("total=\r\n");
            str.Append("[count]\r\n");
            str.Append("count=\r\n");
            str.Append("[user]\r\n");
            File.WriteAllText(as_INIFile, str.ToString(), Encoding.Unicode);
            File.SetAttributes(as_INIFile, FileAttributes.Hidden);

            string ls_appid = INIFile.ContentValue("weixin", "Appid");
            string ls_secret = INIFile.ContentValue("weixin", "AppSecret");
            string access_token = "";
            string menu = "";
            if (ls_appid.Length != 18 || ls_secret.Length != 32)
            {
                MessageBox.Show("你的Appid或AppSecret不对，请检查后再操作");
                return;
            }
            access_token = SysVisitor.Current.Get_Access_token(ls_appid, ls_secret);
            if (access_token == "") { MessageBox.Show("Appid或AppSecret不对，请检查后再操作"); return; }
            menu = SysVisitor.Current.GetPageInfo("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + access_token);
            if (menu.Substring(2, 7) == "errcode")
            {
                MessageBox.Show("拉取失败，返回消息：\r\n" + menu);
            }

            JObject json = JObject.Parse(menu);
            lkl_num.Text = json["total"].ToString();
            INIFile.SetINIString("total", "total", lkl_num.Text, as_INIFile);
            lkl_num_c.Text = json["count"].ToString();
            INIFile.SetINIString("count", "count", lkl_num_c.Text, as_INIFile);
            int li_count = int.Parse(json["count"].ToString());
            btn_GetUser.Enabled = false;
            pictureBox1.Visible = true;
            FileStream fs = null;
            Encoding encoder = Encoding.Unicode;
            for (int i = 0; i < li_count; i++)
            {
                string openid, username;
                openid = Get_UserName(json["data"]["openid"][i].ToString());
                username = json["data"]["openid"][i].ToString();
                //INIFile.SetINIString("user", openid, username, as_INIFile);
                byte[] bytes = encoder.GetBytes(openid + "=" + username + " \r\n");
                fs = File.OpenWrite(as_INIFile);
                //设定书写的開始位置为文件的末尾  
                fs.Position = fs.Length;
                //将待写入内容追加到文件末尾  
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                lab_nums.Text = "已拉取" + i + "个，还剩" + (li_count - i) + "个，请耐心等待";
            }
            lab_nums.Text = "";
            //BindUser();
            btn_GetUser.Enabled = true;
            pictureBox1.Visible = false;
            MessageBox.Show("已全部拉取完毕,请重新打开该窗口");
        }

        /// <summary>
        /// 获取用户信息详情，返回json
        /// </summary>
        /// <param name="as_openid"></param>
        private string Get_User(string as_openid)
        {
            string ls_json = "";
            string access_token = "";
            access_token = SysVisitor.Current.Get_Access_token();
            ls_json = SysVisitor.Current.GetPageInfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token + "&openid=" + as_openid + "&lang=zh_CN");
            return ls_json;
        }

        /// <summary>
        /// 获取用户用户的昵称
        /// </summary>
        private string Get_UserName(string as_openid)
        {
            string ls_json = "";
            ls_json = Get_User(as_openid);
            string username = "";
            JObject json = JObject.Parse(ls_json);
            username = json["nickname"].ToString();
            username = SysVisitor.Current.GetFormatStr(username);
            return username;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string username = txt_search.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                return;
            }
            DataRow[] datarows = adt_user.Select("username like '%" + username + "%'");

            DataTable ldt = new DataTable();
            ldt.Columns.Clear();
            ldt.Columns.Add("username", Type.GetType("System.String"));
            ldt.Columns.Add("openid", Type.GetType("System.String"));
            ldt = ToDataTable(datarows);
            try
            {
                lbl_count.Text = ldt.Rows.Count.ToString();
            }
            catch { }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ldt;
        }
        public DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构  
            foreach (DataRow row in rows)
                tmp.Rows.Add(row.ItemArray);  // 将DataRow添加到DataTable中  
            return tmp;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                SysVisitor.Current.Wx_openid = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                SysVisitor.Current.Wx_username = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(str);
                grb_chat.Enabled = true;
                grb_chat.Text = SysVisitor.Current.Wx_username;
            }
            catch
            { }
            webBrowser_msg.DocumentText = "";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getrecord?access_token={0}", SysVisitor.Current.Get_Access_token());
            string ls_text = @"{";
            ls_text += "\"starttime\" : " + DateTime.Now.AddDays(-3).Ticks.ToString() +",";
            ls_text += "\"endtime\" : " + DateTime.Now.Ticks.ToString() + ",";
            ls_text += "\"openid\" : \"" + SysVisitor.Current.Wx_openid + "\",";
            ls_text += "\"pagesize\" : 1000,";
            ls_text += "\"pageindex\" : 1,";
            ls_text += "}";
            string ls_history = SysVisitor.Current.PostPage(url, ls_text);
            webBrowser_msg.DocumentText = ls_history;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string ls_msg = richTextBox_msg.Text;
            string ls_text = @"{";
            ls_text += "\"touser\":\"" + SysVisitor.Current.Wx_openid + "\",";
            ls_text += "\"msgtype\":\"text\",";
            ls_text += "\"text\":";
            ls_text += "{";
            ls_text += "\"content\":\"" + ls_msg + "\"";
            ls_text += "}";
            ls_text += "}";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", SysVisitor.Current.Get_Access_token());
            string ls_isright = SysVisitor.Current.PostPage(url, ls_text);

            webBrowser_msg.DocumentText += "<P align=right><FONT size=3>" + ls_isright + "</FONT></P>";
        }

        private void btn_addkf_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}", SysVisitor.Current.Get_Access_token());
            string ls_text = "{";
            ls_text += "\"kf_account\":test2@gz-gysoft,";
            ls_text += "\"nickname\":\"客服2\",";
            ls_text += "\"password\":\"12345\",";
            ls_text += "}";
            string ls_kf = @"{
                            'kf_account' : 'test1@gz-gysoft',
                            'nickname' : '客服1',
                            'password' : '123456',
                        }";
            string ls_isok = SysVisitor.Current.PostPage(url, ls_text);
            MessageBox.Show(ls_isok);
        }
    }
}