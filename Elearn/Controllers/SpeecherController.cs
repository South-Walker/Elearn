using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Baidu.Aip.Speech;

namespace Elearn.Controllers
{
    public class SpeecherController : Controller
    {
        private static readonly Asr _asrClient = new Asr("b7hQ5TUml3xZhXDxWUkLndGw", "67ccf7b94063388ceec7ed0dd6f4e963");
        private static readonly Tts _ttsClient = new Tts("b7hQ5TUml3xZhXDxWUkLndGw", "67ccf7b94063388ceec7ed0dd6f4e963");
        // 识别本地文件
        public void AsrData()
        {
            var data = System.IO.File.ReadAllBytes("语音pcm文件地址");
            var result = _asrClient.Recognize(data, "pcm", 16000);
            Console.Write(result);
        }

        // 识别URL中的语音文件
        public void AsrUrl()
        {
            var result = _asrClient.Recoginze(
                "http://xxx.com/待识别的pcm文件地址",
                "http://xxx.com/识别结果回调地址",
                "pcm",
                16000);
            Console.WriteLine(result);
        }

        // 合成
        public void Tts()
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 2}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis("众里寻他千百度", option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                System.IO.File.WriteAllBytes(@"C:\Users\Administrator\Desktop\Speech\合成的语音文件本地存储地址.mp3", result.Data);
            }
        }
        public static void mytts(string content, string path)
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 2}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(content, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                System.IO.File.WriteAllBytes(path, result.Data);
            }
        }
        public static Stream mytts(string content)
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 2}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(content, option);
            if (result.Success)
            {
                var stream = new MemoryStream(result.Data);
                return stream;
            }
            return null;
        }
    }
}