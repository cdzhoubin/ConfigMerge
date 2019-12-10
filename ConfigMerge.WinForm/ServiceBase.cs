using System;
using System.Configuration;
using System.IO;

namespace ConfigMerge.WinForm
{
    public class ServiceBase
    {
        protected static string GetAppSetting(string key, string defaultValue = "")
        {
            var str = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }

            return str;
        }
        static string GetApplictionData()
        {
            var str = GetAppSetting("ApplictionData", AppDomain.CurrentDomain.BaseDirectory.Trim('\\') + "\\Data");
            return EnableSureEixts(str);
        }
        static string applictionData = GetApplictionData();
        protected static string EnableSureEixts(string str)
        {
            if (!Directory.Exists(str))
            {
                Directory.CreateDirectory(str);
            }
            return str.TrimEnd('\\') + "\\";
        }

        static string applictionDataTemp = GetApplictionDataTemp();
        static string GetApplictionDataTemp()
        {
            var str = string.Format("{0}Temp", applictionData);
            return EnableSureEixts(str);
        }
        protected virtual string ApplictionData { get { return applictionData; } }

        protected virtual string ApplictionDataTemp { get { return applictionDataTemp; } }
        protected string ParseUrl(string url, string parentUrl)
        {
            string[] strs = parentUrl.Split("/".ToCharArray(), 2);
            string startUrl = strs[0];
            if (url.StartsWith("//"))
            {
                return startUrl + url;
            }

            if (url.StartsWith("/"))
            {
                return "https://time.geekbang.org" + url;
            }
            if (url.StartsWith(startUrl))
            {
                return url;
            }

            return parentUrl.Substring(0, parentUrl.LastIndexOf('/')) + url;
        }
    }
}
