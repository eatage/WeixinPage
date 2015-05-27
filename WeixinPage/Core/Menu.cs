using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WeixinPage.Core
{
    class TypeMenu
    {
        /// <summary>
        /// 菜单事件类型
        /// </summary>
        /// <returns></returns>
        public static DataTable Typemenu()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("value");
            dt.Rows.Add(new object[] { "请选择事件类型：", "" });
            dt.Rows.Add(new object[] { "点击事件", "click" });
            dt.Rows.Add(new object[] { "跳转URL", "view" });
            dt.Rows.Add(new object[] { "扫码事件", "scancode_push" });
            dt.Rows.Add(new object[] { "扫码推事件且弹出“消息接收中”提示框", "scancode_waitmsg" });
            dt.Rows.Add(new object[] { "弹出系统拍照发图", "pic_sysphoto" });
            dt.Rows.Add(new object[] { "弹出拍照或者相册发图", "pic_photo_or_album" });
            dt.Rows.Add(new object[] { "弹出微信相册发图器", "pic_weixin" });
            dt.Rows.Add(new object[] { "弹出地理位置选择器", "location_select" });
            return dt;
        }
        /// <summary>
        /// 获取微信官方示例菜单(内容请勿修改)
        /// </summary>
        /// <returns></returns>
        public static string ExampleMenu()
        {
            string menu =
            @" {
                'button': [
                    {
		            'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    }, 
                    {
                        'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    },
		            {
		                'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            }, 
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
		            }
                ]
            }";
            return menu;
        }
        /// <summary>
        /// 返回菜单类型
        /// </summary>
        public static string ExampleMenu(int ai_NullPage)
        {
            string menu = "";

            #region ai_NullPage==1
            if (ai_NullPage==1)
            menu =
            @" {
                'button': [
                    {
		            'name': '一级菜单'
                    }, 
                    {
                        'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    },
		            {
		                'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            }, 
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==2
            if (ai_NullPage == 2)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    }, 
                    {
                        'name': '一级菜单'
                    },
		            {
		                'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            }, 
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==3
            if (ai_NullPage == 3)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    }, 
                    {
                        'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    },
		            {
		                'name': '一级菜单'
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==12
            if (ai_NullPage == 12)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单'
                    }, 
                    {
                    'name': '一级菜单'
                    },
		            {
		                'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            }, 
                            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'click', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==13
            if (ai_NullPage == 13)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单'
                    }, 
                    {
                        'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    },
		            {
		                'name': '一级菜单'
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==23
            if (ai_NullPage == 23)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单', 
                        'sub_button': [
                            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            },
				            {
                                'type': 'view', 
                                'name': '二级菜单'
                            }
                        ]
                    }, 
                    {
                        'name': '一级菜单'
                    },
		            {
		                'name': '一级菜单'
		            }
                ]
            }";
            #endregion
            #region ai_NullPage==123
            if (ai_NullPage == 123)
                menu =
                @" {
                'button': [
                    {
		            'name': '一级菜单'
                    }, 
                    {
                        'name': '一级菜单'
                    },
		            {
		                'name': '一级菜单'
		            }
                ]
            }";
            #endregion
            return menu;
        }

        /// <summary>
        /// 模板消息模板
        /// 参数名对应数字名，值对应数字名+1
        /// 最后一个参数名为end，值为end1
        /// is_url为true时url值为url1
        /// </summary>
        /// <param name="ai_num">参数个数</param>
        /// <returns></returns>
        public static string Formwork(int ai_num, bool is_url = false)
        {
            if (ai_num > 7 || ai_num < 2)
            {
                return "";
            }
            ai_num = ai_num - 1;
            string menu = @"{'
           'touser':'openid',
           'template_id':'templateid',
           'url':'url1',
           'topcolor':'#FF0000',
           'data':{
                   'one': {
                       'value':'one1',
                       'color':'#173177'
                   },";
            if (ai_num >= 2)
            {
                menu += @"'two':{
                       'value':'two1',
                       'color':'#173177'
                   },";
            }
            if (ai_num >= 3)
            {
                menu += @"'three': {
                       'value':'three1',
                       'color':'#173177'
                   },";
            }
            if (ai_num >= 4)
            {
                menu += @"'four': {
                       'value':'four1',
                       'color':'#173177'
                   },";
            }
            if (ai_num >= 5)
            {
                menu += @"'five':{
                       'value':'five1',
                       'color':'#173177'
                   },";
            }
            if (ai_num == 6)
            {
                menu += @"'six':{
                       'value':'six1',
                       'color':'#173177'
                   },";
            }
            menu += @"'end':{
                       'value':'end1',
                       'color':'#173177'
                   }
                }
            }";
            if (is_url == false)
            {
                menu = menu.Replace("url1", "");
            }
            return menu;
        }
    }
}
