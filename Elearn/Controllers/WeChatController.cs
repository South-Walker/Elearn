using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WeChatMVC.Controllers;
using System.Drawing;
using Elearn.Models;

namespace Elearn.Controllers
{
    // GET: WeChat
    public class WeChatController : BaseController
    {
        static WechatRequest WechatRequest;
        // GET: WeChat
        public string Index() //回复全都是xml格式的string
        {
            if (IsFromTencent("961016") && Request.HttpMethod == "GET")
            {
                return Request["echostr"];
            }
            if (IsFromTencent("961016") && Request.HttpMethod == "POST")
            {
                try
                {
                    #region wechatpost
                    WechatRequest = new WechatRequest(Request.InputStream);
                    if (WechatRequest.IsClick())
                    {
                        switch (WechatRequest.EventKey)
                        {
                            case "elearning_wordlearn":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_wordlearn);
                            case "elearning_wordintensivelearn":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_wordintensivelearn);
                            case "elearning_textlearn":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_textlearn);
                            case "elearning_textintensivelearn":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_textintensivelearn);
                            default:
                                return WechatRequest.Get_Reply("功能还在开发中，敬请期待");
                        }
                    }
                    else if (WechatRequest.IsSubscribe())
                    {
                        return WechatRequest.Get_Reply(WechatRequest.elearn_welcome);
                    }
                    else
                    {
                        switch (WechatRequest.Content)
                        {
                            case "001":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_testmsg1);
                            case "0011":
                                return WechatRequest.Get_Reply(WechatRequest.elearning_testmsg2);
                            default:
                                return WechatRequest.Get_Reply("识别错误，请重试"); 
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    WechatRequest.Save_log(ex.ToString());
                    return "success";
                }
            }
            else//不是腾讯发来的post
            {
                return "Do not touch this server,guy!";
            }
        }

        public bool IsFromTencent(string thistoken)
        {
            var signature = Request["signature"];
            var timestamp = Request["timestamp"];
            var nonce = Request["nonce"];
            var token = thistoken;
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序  
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//信息来源是腾讯才会返回true
    }
}