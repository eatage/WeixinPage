using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeixinPage.Core;
using Newtonsoft.Json.Linq;

namespace WeixinPage
{
    public partial class Formwork : Form
    {
        public Formwork()
        {
            InitializeComponent();
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={0}", SysVisitor.Current.Get_Access_token());
            string str = "{ /r/n";
            str += "\"template_id_short\":\"TM00015\"/r/n";
            str += "}";
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", SysVisitor.Current.Get_Access_token());
            string menu = TypeMenu.Formwork(4);
            menu = menu.Replace("openid", SysVisitor.Current.Wx_openid);
            menu = menu.Replace("templateid", "");
            menu = menu.Replace("one", "");
            menu = menu.Replace("one1", "");
            menu = menu.Replace("two", "");
            menu = menu.Replace("two1", "");
            menu = menu.Replace("three", "");
            menu = menu.Replace("three1", "");
            menu = menu.Replace("end", "");
            menu = menu.Replace("end1", "");

            JObject json = JObject.Parse(menu);
        }
    }
}