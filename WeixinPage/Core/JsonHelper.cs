using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace WeixinPage.Core
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    class JsonHelper
    {
        #region 格式化字符型、日期型、布尔型
        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        public static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = StringFilter(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type == typeof(Guid))
            {
                str = "\"" + str + "\"";
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        public static string StringFilter(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region DataTable列转json
        /// <summary>
        /// DataTableColumn转json
        /// </summary>
        /// <param name="dt">表</param>
        /// <param name="r">列</param>
        public static string DataTableColumnToJson(DataTable dt, int r)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql.Append(dt.Rows[i][r]);
                strSql.Append(",");
            }
            return strSql.ToString().Trim(',');
        }
        #endregion

        #region Json对象转json字符串
        /// <summary>
        /// 对象转json字符串
        /// </summary>
        public static string JsonObjectToJson(object jsonObject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                object objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, null);
                Type type = propertyInfo[i].PropertyType;
                string strValue = objectValue.ToString();
                strValue = StringFormat(strValue, type);
                sb.Append("\"" + propertyInfo[i].Name + "\":");
                sb.Append(strValue + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            return sb.ToString();
        }
        #endregion

        #region list转json
        /// <summary>
        /// list转json
        /// </summary>
        public static string ListToJson<T>(IList<T> list)
        {
            object obj = list[0];
            return ListToJson<T>(list, obj.GetType().Name);
        }

        private static string ListToJson<T>(IList<T> list, string JsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(JsonName))
                JsonName = list[0].GetType().Name;
            Json.Append("{\"" + JsonName + "\":[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        Type type = pi[j].GetValue(list[i], null).GetType();
                        Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));
                        if (j < pi.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
        #endregion

        #region 对象集合转json
        /// <summary>
        /// 对象集合转换为json
        /// </summary>
        /// <param name="array">对象集合</param>
        /// <returns>json字符串</returns>
        public static string ToJson(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString += JsonObjectToJson(item) + ",";
            }
            jsonString = jsonString.Substring(0, jsonString.Length - 1);
            return jsonString + "]";
        }
        #endregion

        #region 普通集合转Json
        /// <summary>    
        /// 普通集合转换Json   
        /// </summary>   
        /// <param name="array">集合对象</param> 
        /// <returns>Json字符串</returns>  
        public static string ToArrayString(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString = ToJson(item.ToString()) + ",";
            }
            jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            return jsonString + "]";
        }
        #endregion

        #region  DataSet转Json
        /// <summary>    
        /// DataSet转换为Json   
        /// </summary>    
        /// <param name="dataSet">DataSet对象</param>   
        /// <returns>Json字符串</returns>    
        public static string DataSetToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + JsonObjectToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        #endregion

        #region Datatable转Json
        /// <summary>
        /// Datatable转换为Json
        /// </summary>
        public static string DatatableToJson(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");
                DataRowCollection drc = dt.Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string strKey = dt.Columns[j].ColumnName;
                        string strValue = drc[i][j].ToString();

                        Type type = dt.Columns[j].DataType;
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (j < dt.Columns.Count - 1)
                            jsonString.Append(strValue + ",");
                        else
                            jsonString.Append(strValue);
                    }
                    jsonString.Append("},");
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
                return jsonString.ToString();
            }
            else
                return "[]";
        }
        /// <summary>    
        /// DataTable转换为Json
        /// </summary>    
        public static string DatatableToJson(DataTable dt, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                            Json.Append(",");
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                        Json.Append(",");
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
        #endregion

        #region DataReader转Json
        /// <summary>
        /// DataReader转换为Json
        /// </summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串</returns>  
        public static string DataReaderToJson(DbDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            while (dataReader.Read())
            {
                jsonString.Append("{");
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Type type = dataReader.GetFieldType(i);
                    string strKey = dataReader.GetName(i);
                    string strValue = dataReader[i].ToString();
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (i < dataReader.FieldCount - 1)
                        jsonString.Append(strValue + ",");
                    else
                        jsonString.Append(strValue);
                }
                jsonString.Append("},");
            }
            dataReader.Close();
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        #endregion

        #region Json转DataTable
        /// <summary>
        /// 将json转换为DataTable
        /// Json内含有一个数组的时候适用，数组名将作为表名
        /// 多出的数组将被忽略
        /// 当Json字符串含有#*字符时将转换失败
        /// 如Json含空格会被删除
        /// </summary>
        /// <param name="strJson">json字符串</param>
        public static DataTable JsonToDataTable(string strJson)
        {
            strJson = strJson.Replace("\r", "").Replace("\n", "").Replace(" ","");
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            #region 分隔符为单引号时
            strJson = strJson.Replace(",'", "*\"").Replace("':", "\"#").ToString();//单引号
            strJson = strJson.Replace("{'", "{\"").Replace("'}", "\"}");
            strJson = strJson.Replace("'*", "\"*").Replace("#'", "#\"");
            #endregion
            //取出表名
            //var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            var rg = new Regex("(?<=\")[^\"\"]*(?=\")", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名
            try
            {
                strJson = strJson.Substring(strJson.IndexOf("[") + 1);
                strJson = strJson.Substring(0, strJson.IndexOf("]"));
            }
            catch { }
            if (strJson.IndexOf('[') >= 0 || strJson.IndexOf(']') >= 0)
            {
                throw new Exception("字符串格式不正确");
            }
            //获取数据
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表
                if (tb == null)
                {
                    tb = new DataTable();
                    if (string.IsNullOrEmpty(strName))
                    {
                        strName = "Json";
                    }
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }

        #endregion

        #region Json转DataSet
        /// <summary>
        /// Json转DataSet
        /// Json内含有多个数组的时候适用，数组名将作为表名
        /// 当Json字符串含有#*字符时将转换失败
        /// 如Json含空格会被删除
        /// </summary>
        public static DataSet JsonToDataSet(string strJson)
        {
            DataSet ds = new DataSet();
            strJson = strJson.Replace("\r", "").Replace("\n", "").Replace(" ", "");
            strJson = strJson.Replace("],", "]#");
            string[] strj = strJson.Split('#');
            
            #region 生成DataTable
            DataTable tb;
            foreach (string json in strj)
            {
                tb = null;
                string listJson = json;
                if (listJson.Substring(0, 1) != "{")
                    listJson = "{" + listJson;
                if (listJson.Substring(listJson.Length-1, 1) != "}")
                    listJson = listJson + "}";
                //转换json格式
                listJson = listJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
                #region 分隔符为单引号时
                listJson = listJson.Replace(",'", "*\"").Replace("':", "\"#").ToString();//单引号
                listJson = listJson.Replace("{'", "{\"").Replace("'}", "\"}");
                listJson = listJson.Replace("'*", "\"*").Replace("#'", "#\"");
                #endregion
                var rg = new Regex("(?<=\")[^\"\"]*(?=\")", RegexOptions.IgnoreCase);//@"(?<={)[^:]+(?=:\[)"
                string strName = rg.Match(listJson).Value;
                //去除表名
                try
                {
                    listJson = listJson.Substring(listJson.IndexOf("[") + 1);
                    listJson = listJson.Substring(0, listJson.IndexOf("]"));
                }
                catch { }
                //获取数据
                rg = new Regex(@"(?<={)[^}]+(?=})");
                MatchCollection mc = rg.Matches(listJson);
                for (int i = 0; i < mc.Count; i++)
                {
                    string strRow = mc[i].Value;
                    string[] strRows = strRow.Split('*');

                    //创建表
                    if (tb == null)
                    {
                        tb = new DataTable();
                        if (string.IsNullOrEmpty(strName))
                        {
                            strName = "Json";
                        }
                        tb.TableName = strName;
                        foreach (string str in strRows)
                        {
                            var dc = new DataColumn();
                            string[] strCell = str.Split('#');

                            if (strCell[0].Substring(0, 1) == "\"")
                            {
                                int a = strCell[0].Length;
                                dc.ColumnName = strCell[0].Substring(1, a - 2);
                            }
                            else
                            {
                                dc.ColumnName = strCell[0];
                            }
                            tb.Columns.Add(dc);
                        }
                        tb.AcceptChanges();
                    }
                    //增加内容
                    DataRow dr = tb.NewRow();
                    for (int r = 0; r < strRows.Length; r++)
                    {
                        dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                    }
                    tb.Rows.Add(dr);
                    tb.AcceptChanges();
                }
                ds.Tables.Add(tb.Copy());
            }
            #endregion

            return ds;
        }
        #endregion

        #region 返回错误
        public static string error()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("error", typeof(int));
            DataRow dr = dt.NewRow();
            dr["error"] = 1;
            dt.Rows.Add(dr);
            return JsonObjectToJson(dt);
        }
        #endregion
    }
}