using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;

namespace WeixinPage.Core
{
    class INIFile
    {
        ///// <summary>
        ///// 设置INI文件参数
        ///// </summary>
        ///// <param name="section">INI文件中的段落</param>
        ///// <param name="key">INI文件中的关键字</param>
        ///// <param name="val">INI文件中关键字的数值</param>
        ///// <param name="filePath">INI文件的完整的路径和名称</param>
        ///// <returns></returns>
        //[DllImport("kernel32")]
        //private static extern long WritePrivateProfileString(
        //    string section, string key, string val, string filePath);

        ///// <summary>
        ///// 获取INI文件参数
        ///// </summary>
        ///// <param name="section">INI文件中的段落名称</param>
        ///// <param name="key">INI文件中的关键字</param>
        ///// <param name="def">无法读取时候时候的缺省数值</param>
        ///// <param name="retVal">读取数值</param>
        ///// <param name="size">数值的大小</param>
        ///// <param name="filePath">INI文件的完整路径和名称</param>
        //[DllImport("kernel32")]
        //private static extern int GetPrivateProfileString(
        //    string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //static string gs_FileName = System.AppDomain.CurrentDomain.BaseDirectory + "Config.ini";

        ///// <summary>
        ///// 获取INI文件参数
        ///// </summary>
        ///// <param name="as_section">INI文件中的段落名称</param>
        ///// <param name="as_key">INI文件中的关键字</param>
        ///// <param name="as_FileName">INI文件的完整路径和名称</param>
        //public static string GetINIString(string as_section, string as_key, string as_FileName)
        //{
        //    StringBuilder temp = new StringBuilder(255);
        //    int i = GetPrivateProfileString(as_section, as_key, "", temp, 255, as_FileName);
        //    return temp.ToString();
        //}
        ///// <summary>
        ///// 获取INI文件参数
        ///// </summary>
        ///// <param name="as_section">INI文件中的段落名称</param>
        ///// <param name="as_key">INI文件中的关键字</param>
        ///// <param name="as_FileName">INI文件的完整路径和名称</param>
        //public static string GetINIString(string as_section, string as_key)
        //{
        //    return GetINIString(as_section, as_key, gs_FileName);
        //}

        ///// <summary>
        ///// 设置INI文件参数
        ///// </summary>
        ///// <param name="as_section">INI文件中的段落</param>
        ///// <param name="as_key">INI文件中的关键字</param>
        ///// <param name="as_Value">INI文件中关键字的数值</param>
        ///// <param name="as_FileName">INI文件的完整路径和名称</param>
        //public static long SetINIString(string as_section, string as_key, string as_Value, string as_FileName)
        //{
        //    return WritePrivateProfileString(as_section, as_key, as_Value, as_FileName);
        //}
        ///// <summary>
        ///// 设置INI文件参数
        ///// </summary>
        ///// <param name="as_section">INI文件中的段落</param>
        ///// <param name="as_key">INI文件中的关键字</param>
        ///// <param name="as_Value">INI文件中关键字的数值</param>
        //public static long SetINIString(string as_section, string as_key, string as_Value)
        //{
        //    return SetINIString(as_section, as_key, as_Value, gs_FileName);
        //}
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32.dll")]
        public extern static int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);
        /// <summary>
        /// 写入INI文件(section:节点名称 key:键 val:值)
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        public static long SetINIString(string section, string key, string val, string as_FilePath = "")
        {
            if (as_FilePath == "")
            {
                return (WritePrivateProfileString(section, key, val, strFilePath));
            }
            else
            {
                return (WritePrivateProfileString(section, key, val, as_FilePath)); 
            }
        }
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        public static string strFilePath = Application.StartupPath + "\\Config.ini";//获取INI文件默认路径
        public static string strSec = "";

        //INI文件名

        
        /// <summary>
        /// 读取INI文件中的内容方法 (Section 节点名称;key 键)
        /// </summary>
        /// <param name="Section">节点名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string ContentValue(string Section, string key, string as_FilePath = "")
        {

            StringBuilder temp = new StringBuilder(1024);
            if (as_FilePath == "")
            {
                GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            }
            else
            {
                GetPrivateProfileString(Section, key, "", temp, 1024, as_FilePath); 
            }
            return temp.ToString();
        }
        /// <summary>
        /// 获取指定小节所有项名和值的一个列表 
        /// </summary>
        /// <param name="section">节 段，欲获取的小节。注意这个字串不区分大小写</param>
        /// <param name="buffer">缓冲区 返回的是一个二进制的串，字符串之间是用"\0"分隔的</param>
        /// <param name="nSize">缓冲区的大小</param>
        /// <param name="filePath">初始化文件的名字。如没有指定完整路径名，windows就在Windows目录中查找文件</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileSection(string section, byte[] buffer, int nSize, string filePath);
        /// <summary>
        /// 获取指定段section下的所有键值对 返回集合的每一个键形如"key=value"
        /// </summary>
        /// <param name="section">指定的段落</param>
        /// <param name="filePath">ini文件的绝对路径</param>
        /// <returns></returns>
        public static List<string> ReadKeyValues(string section, string as_FilePath = "")
        {
            byte[] buffer = new byte[32767];
            List<string> list = new List<string>();
            int length = 0;
            if (as_FilePath == "")
            {
                length = GetPrivateProfileSection(section, buffer, buffer.GetUpperBound(0), strFilePath);
            }
            else
            {
                length = GetPrivateProfileSection(section, buffer, buffer.GetUpperBound(0), as_FilePath); 
            }
            string temp;
            int postion = 0;
            for (int i = 0; i < length; i++)
            {
                if (buffer[i] == 0x00) //以'\0'来作为分隔
                {
                    temp = System.Text.ASCIIEncoding.Default.GetString(buffer, postion, i - postion).Trim();
                    postion = i + 1;
                    if (temp.Length > 0)
                    {
                        list.Add(temp);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 删除指定的key
        /// </summary>
        /// <param name="section">要写入的段落名</param>
        /// <param name="key">要删除的键</param>
        /// <param name="fileName">INI文件的完整路径和文件名</param>
        public static void DelKey(string section, string key, string as_FilePath = "")
        {
            if (as_FilePath == "")
            {
                WritePrivateProfileString(section, key, null, strFilePath);
            }
            else
            {
                WritePrivateProfileString(section, key, null, as_FilePath);
            }
        }
        /// <summary>
        /// 返回该配置文件中所有Section名称的集合
        /// </summary>
        public static ArrayList ReadSections()
        {
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), strFilePath);  
            int iCnt, iPos;
            ArrayList arrayList = new ArrayList();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.UTF8.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }  
    }
}
