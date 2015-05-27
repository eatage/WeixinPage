using System;
using System.Windows.Forms;
using System.Reflection;

namespace WeixinPage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new WeixinPage());
                }
                else
                {
                    MessageBox.Show("该程序己启动");
                }
            }
        }
    }
}
