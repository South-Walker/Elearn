using System;
using System.Web.Security;
using Elearn.Controllers;
using Elearn.Models;
using System.Text.RegularExpressions;

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
                #region wechatpost
                WechatRequest = new WechatRequest(Request.InputStream);
                if (WechatRequest.IsClick())
                {
                    #region ButtonEvent
                    switch (WechatRequest.EventKey)
                    {
                        case "elearning_wordlearn":
                            return WechatRequest.Get_Reply(WechatRequest.elearning_wordlearn);
                        case "elearning_textlearn":
                            return WechatRequest.Get_Reply(WechatRequest.elearning_textlearn);
                        case "elearning_nextword":
                            string nextword = DataBaseController.GetNextWord(WechatRequest.FromUserName);
                            if (nextword != null)
                                return WechatRequest.Get_Reply(nextword);
                            else
                                return WechatRequest.Get_Reply("当前未设立测试范围或已经学习完全部内容");
                        default:
                            return WechatRequest.Get_Reply("功能还在开发中，敬请期待");
                    }
                    #endregion
                }
                else if (WechatRequest.IsSubscribe())
                {
                    #region FollowEvent
                    DataBaseController.AddIntoWechatIds(WechatRequest.FromUserName);
                    return WechatRequest.Get_Reply(WechatRequest.elearn_welcome);
                    #endregion
                }
                else
                {
                    #region MessageEvent
                    string message = WechatRequest.Content;
                    if (Regex.IsMatch(message, "^xh.+"))
                    {
                        DataBaseController.UpdateStudents(WechatRequest.FromUserName, message.Substring(2), null);
                        return WechatRequest.Get_Reply("学号已修改，现在您绑定的学号为：" + message.Substring(2) + "请输入jwc + 您的教务处密码来绑定，如jwc123456");
                    }
                    else if (Regex.IsMatch(message, "^jwc.+"))
                    {
                        string studentnum = DataBaseController.GetStudentNum(WechatRequest.FromUserName);
                        string jwcpassword = message.Substring(3);
                        if (JWCHttpHelper.isPasswordTrue(studentnum, jwcpassword))
                        {
                            DataBaseController.UpdateStudents(WechatRequest.FromUserName, studentnum, jwcpassword);
                            return WechatRequest.Get_Reply("验证成功！");
                        }
                        else
                        {
                            return WechatRequest.Get_Reply($"输入的密码{ jwcpassword }不正确");
                        }
                    }
                    else
                    {
                        if (Regex.IsMatch(message, "\\d{5,5}"))
                        {
                            if (DataBaseController.tryUpdateProcesses(WechatRequest.FromUserName, message))
                            {
                                return WechatRequest.Get_Reply("选择成功！按next开始学习");
                            }
                            else
                            {
                                return WechatRequest.Get_Reply("选择失败，请确认是否绑定学号及输入代码是否正确");
                            }
                        }
                        if (!DataBaseController.HaveBinding(WechatRequest.FromUserName)) 
                        {
                            return WechatRequest.Get_Reply(WechatRequest.elearn_welcome);
                        }
                        switch (message)
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
                #endregion
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