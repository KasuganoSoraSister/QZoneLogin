using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>  
    /// Cookie操作帮助类  
    /// </summary>  
    public static class HttpCookieHelper
    {
        /// <summary>  
        /// 根据字符生成Cookie列表  
        /// </summary>  
        /// <param name="cookie">Cookie字符串</param>  
        /// <returns></returns>  
        public static List<CookieItem> GetCookieList(string cookie)
        {
            List<CookieItem> cookielist = new List<CookieItem>();
            foreach (string item in cookie.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (Regex.IsMatch(item, @"([\s\S]*?)=([\s\S]*?)$"))
                {
                    Match m = Regex.Match(item, @"([\s\S]*?)=([\s\S]*?)$");
                    cookielist.Add(new CookieItem() { Key = m.Groups[1].Value, Value = m.Groups[2].Value });
                }
            }
            return cookielist;
        }

        /// <summary>  
        /// 根据Key值得到Cookie值,Key不区分大小写  
        /// </summary>  
        /// <param name="Key">key</param>  
        /// <param name="cookie">字符串Cookie</param>  
        /// <returns></returns>  
        public static string GetCookieValue(string Key, string cookie)
        {
            foreach (CookieItem item in GetCookieList(cookie))
            {
                if (item.Key == Key)
                    return item.Value;
            }
            return "";
        }
        /// <summary>  
        /// 格式化Cookie为标准格式  
        /// </summary>  
        /// <param name="key">Key值</param>  
        /// <param name="value">Value值</param>  
        /// <returns></returns>  
        public static string CookieFormat(string key, string value)
        {
            return string.Format("{0}={1};", key, value);
        }

        public static string updateCookie(string oldcookie, string newcookie)
        {
            List<string> oldcookielist = new List<string>();
            if (oldcookie.Contains(";"))
                oldcookielist = new List<string>(oldcookie.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
            else
                oldcookielist.Add(oldcookie);

            List<string> newcookielist = new List<string>();
            if (newcookie.Contains(";"))
                newcookielist = new List<string>(newcookie.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
            else
                newcookielist.Add(newcookie);

            foreach (string cookie in newcookielist)
            {
                //Console.WriteLine("cookie:" + cookie);
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    if (cookie.Split('=').Length > 1) //判断cookie的value值是为空,不为空时才进行操作
                    {
                        bool isFind = false; //判断是否是新值
                        for (int i = 0; i < oldcookielist.Count; i++)
                        {
                            if (cookie.Split('=')[0] == oldcookielist[i].Split('=')[0])
                            {
                                //oldcookielist[i].Split('=')[1] = cookie.Split('=')[1];
                                oldcookielist[i] = cookie;
                                isFind = true;
                                break;
                            }
                        }

                        if (!isFind && cookie.IndexOf('=') != cookie.Length - 1) //如果计算后还是false,则表示newcookie里出现新值了,将新值添加到老cookie里
                            oldcookielist.Add(cookie);
                    }
                }
            }

            oldcookie = string.Empty;

            for (int i = 0; i < oldcookielist.Count; i++)
                oldcookie += oldcookielist[i] + ";";

            return oldcookie;
        }


    }

    /// <summary>  
    /// Cookie对象  
    /// </summary>  
    public class CookieItem
    {
        /// <summary>  
        /// 键  
        /// </summary>  
        public string Key { get; set; }
        /// <summary>  
        /// 值  
        /// </summary>  
        public string Value { get; set; }
    }
}