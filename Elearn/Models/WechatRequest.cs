using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;

namespace Elearn.Models
{
    public class WechatRequest
    {
        /*
         * 所有Get.*_Relpy的函数，都返回直接能回复的xml格式字符
         */
        public string Format = "";
        public string Event = "";
        public string EventKey = "";
        public string ToUserName = "";
        public string FromUserName = "";
        public string CreateTime = "";
        public string MsgType = "";
        public string Content = "";
        public string MsgId = "";
        public string PicUrl = "";
        public string MediaId = "";
        public string studentid = null;//同上
        public string ty_pwd = null;//同上
        public static string elearning_testmsg1 = "请输入您想学习的单元前的数字：\r\n0011 Unit1\r\n0012 Unit2\r\n0013 Unit3\r\n0014 Unit4\r\n0015 Unit5\r\n0016 Unit6\r\n0017 Unit7\r\n0018 Unit8";
        public static string elearning_testmsg2 = "请输入您想学习的单元前的数字：\r\n2011 Unit1\r\n2012 Unit2\r\n2013 Unit3\r\n2014 Unit4\r\n2015 Unit5\r\n2016 Unit6\r\n2017 Unit7\r\n2018 Unit8";
        public static string elearning_changestudentnum = "想要更改绑定吗？后台回复xh+学号，如xh10161000，重新绑定学号";
        public static string elearning_textlearn = "您想学习哪本书上的课文？\r\n（请输入相应数字）\r\n201.综合教程3\r\n202.综合教程4\r\n203.阅读教程上\r\n204.阅读教程下";
        public static string elearning_textintensivelearn = "您想练习哪本书上的课文？\r\n（请输入相应数字）\r\n301.综合教程3\r\n302.综合教程4\r\n303.阅读教程上\r\n304.阅读教程下";
        public static string elearning_wordintensivelearn = "您想练习哪本书上的单词？\r\n（请输入相应数字）\r\n101.综合教程3\r\n102.综合教程4\r\n103.阅读教程上\r\n104.阅读教程下\r\n105.视听说教程3\r\n106.视听说教程4";
        public static string elearning_wordlearn = "您想学习哪本书上的单词？\r\n（请输入相应数字）\r\n001.综合教程3\r\n002.综合教程4\r\n003.阅读教程上\r\n004.阅读教程下\r\n005.视听说教程3\r\n006.视听说教程4";
        public static string elearn_welcome = "Hello，关注E学，英语易学。\r\n请输入xh加学号，jwc加密码进行初始绑定后就可以使用公众号所有功能啦！";

        public WechatRequest(XmlDocument doc)
        {
            XmlElement xe = doc.DocumentElement;
            fillclass(xe);
        }
        public static void Save_log(string xml)
        {
            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\wechatlog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(xml + "\r\n");
            sw.Flush();
            fs.Close();
        }
        private static void Save_log(XmlElement xe)//有误
        {
            string xml = xe.Value;
            Save_log(xml);
        }
        /// <summary>
        /// 返回的值中0表示用户没有绑定学号，
        /// 1表示对应的密码存在，且同时对实例参数中对应的pwd赋值,
        /// 2表示有学号记录但是没有对应的密码。
        /// </summary>
        /// <param name="passwordcode">暂时的，输入0表示查询体育状态</param>
        /// <returns></returns>
        public WechatRequest(string xml)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            XmlElement xe = xmldoc.DocumentElement;
            fillclass(xe);
        }
        public WechatRequest(Stream xmlstream)
        {
            StreamReader sr = new StreamReader(xmlstream);
            string xml = sr.ReadToEnd();
            try
            {
                Save_log(xml);
            }
            catch
            {

            }
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            XmlElement xe = xmldoc.DocumentElement;
            fillclass(xe);
        }
        private void fillclass(XmlElement xe)//实例化的最后一步
        {
            ToUserName = xe.SelectSingleNode("ToUserName").InnerText;
            FromUserName = xe.SelectSingleNode("FromUserName").InnerText;
            CreateTime = xe.SelectSingleNode("CreateTime").InnerText;
            MsgType = xe.SelectSingleNode("MsgType").InnerText;
            if (MsgType == "text")
            {
                Content = xe.SelectSingleNode("Content").InnerText;
            }
            else if (MsgType == "image")
            {
                MediaId = xe.SelectSingleNode("MediaId").InnerText;
                PicUrl = xe.SelectSingleNode("PicUrl").InnerText;
            }
            else if (MsgType == "voice")
            {
                MediaId = xe.SelectSingleNode("MediaId").InnerText;
                Format = xe.SelectSingleNode("Format").InnerText;
            }
            else if (MsgType == "event")
            {
                Event = xe.SelectSingleNode("Event").InnerText + "";
                if (Event == "CLICK")
                {
                    EventKey = xe.SelectSingleNode("EventKey").InnerText + "";
                }
                else if (Event == "subscribe")
                {

                }
                return;
            }
        }
        public bool IsSubscribe()
        {
            if (Event == "" || Event == null)
                return false;
            return Event == "subscribe";
        }
        public bool IsClick()
        {
            if (Event == "" || Event == null)
                return false;
            return Event == "CLICK";
        }
        public bool IsVoice()
        {
            return MsgType == "voice";
        }
        public string Get_MJ_Reply(DateTime buyday, DateTime ticketday, string origination, string destination)
        {
            string url_origination = get_urlEncode(origination);
            string url_destination = get_urlEncode(destination);
            string url = "http://ecust.top/mj/html/index.php?buy_year=" +
                buyday.Year + "&buy_month=" +
                buyday.Month + "&buy_day=" +
                buyday.Day + "&buy_hour=" +
                buyday.Hour + "&buy_minute=" +
                buyday.Minute + "&stationary=0&origination=" +
                url_origination + "&destination=" +
                url_destination + "&ticket_year=" +
                ticketday.Year + "&ticket_month=" +
                ticketday.Month + "&ticket_day=" +
                ticketday.Day + "&ticket_hour=" +
                ticketday.Hour + "&ticket_minute=" +
                ticketday.Minute + "&ticket_year=" +
                ticketday.Year + "&ticket_month=" +
                ticketday.Month + "&ticket_day=" +
                ticketday.Day + "&ticket_hour=" +
                ticketday.Hour + "&ticket_minute=" +
                ticketday.Minute;

            return Get_Reply(Get_Link_Reply(url, "车票"));
        }
        private string get_urlEncode(string input)
        {
            return HttpUtility.UrlEncode(input);
        }
        public string Get_Link_Reply(string url, string text)
        {
            return Get_Reply("<a href=\"" + url + "\">" + text + "</a>");
        }
        public string Get_Reply(string content)
        {
            string reply = "<xml><ToUserName><![CDATA[" + FromUserName +
                "]]></ToUserName><FromUserName><![CDATA[" + ToUserName +
            "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) +
            "</CreateTime><MsgType><![CDATA[" + "text" +
            "]]></MsgType><Content><![CDATA[" + content +
            "]]></Content></xml>";
            return reply;
        }//返回最终的xml
        public string Get_Img(string mediaid)
        {
            string reply = "<xml><ToUserName><![CDATA[" + FromUserName +
                "]]></ToUserName><FromUserName><![CDATA[" + ToUserName +
            "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) +
            "</CreateTime><MsgType><![CDATA[" + "image" +
            "]]></MsgType><Image><MediaId><![CDATA[" + mediaid +
            "]]></MediaId></Image></xml>";
            return reply;
        }
        public string Get_Voice(string mediaid)
        {
            string reply = "<xml><ToUserName><![CDATA[" + FromUserName +
                "]]></ToUserName><FromUserName>< ![CDATA[" + ToUserName +
                "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now)
                + "</CreateTime><MsgType><![CDATA[" + "voice" +
                "]]></MsgType><Voice><MediaId><![CDATA[" + mediaid +
                "]]></MediaId></Voice></xml>";
            return reply;
        }
        public string Get_ImgText()
        {
            string reply = "<xml><ToUserName><![CDATA[" + FromUserName +
                "]]></ToUserName><FromUserName><![CDATA[" + ToUserName +
                "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now)
                + "</CreateTime><MsgType><![CDATA[" + "news" +
                "]]></MsgType><ArticleCount>" + "2" +
                "</ArticleCount><Articles>" +
                "<item><Title><![CDATA[Book3]]></Title><Description><![CDATA[]]></Description>" +
                "<PicUrl><![CDATA[http://www.xiaoliming96.com/images/test.jpg]]></PicUrl><Url><![CDATA[]]></Url></item>" +
                "<item><Title><![CDATA[Unit1]]></Title><Description><![CDATA[]]></Description><PicUrl><![CDATA[http://www.xiaoliming96.com/images/test.jpg]]></PicUrl><Url><![CDATA[http://www.xiaoliming96.com/englishtext/b3u1p2/]]></Url></item>" +
                "</Articles></xml>";
            return reply;
        }
        public static int ConvertDateTimeInt(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}