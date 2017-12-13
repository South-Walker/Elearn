using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace Elearn.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public static string MD5Encrypter(string input, string state)
        {
            string token = "E58D8EE79086E9809AE5BEAEE4BFA1";
            DateTime now = DateTime.Now;
            string date = now.Year.ToString() + now.Month.ToString() + now.Day.ToString();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytesinput = Encoding.UTF8.GetBytes(input + token + date + state);
            byte[] bytesoutput = md5.ComputeHash(bytesinput);

            string output = "";
            for (int i = 0; i < bytesoutput.Length; i++)
            {
                output += bytesoutput[i].ToString("x2");
            }
            return output;
        } //通用MD5加密
        public string Welcome()
        {
            return "Don't touch this server,guy";
        }
    }
}