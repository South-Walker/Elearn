using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using Newtonsoft;
using System.Xml;
using System.IO;

namespace databasescript
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataClassesDataContext db = new DataClassesDataContext()) 
            {
                var wordslist = _DBGetNewWords(db);
                foreach (var word in wordslist)
                {
                    string wordid = Get_Wordid(word.eword);
                    if (wordid == null)
                        continue;
                    var exampleslist = Get_Sentences(wordid);
                    foreach (var example in exampleslist)
                    {
                        _DBInsertSentences(db, example, word);
                    }
                    Console.WriteLine(word.eword);
                }
                db.SubmitChanges();
            }
            Console.Read();
        }
        static List<ewords> _DBGetNewWords(DataClassesDataContext db)
        {
            int? maxwordid = db.sentences.Max(sen => sen.eword_id);
            if (maxwordid.HasValue)
            {
                var words = db.ewords.Where(word => word.eword_id > maxwordid.Value);
                return words.ToList();
            }
            else
            {
                return _DBGetAllWords(db);
            }
        }
        static List<ewords> _DBGetAllWords(DataClassesDataContext db)
        {
            var words = db.ewords.Select(word => word);
            return words.ToList();
        }
        static void _DBInsertSentences(DataClassesDataContext db, ExampleSentence es, ewords word)
        {
            sentences insertone = new sentences
            {
                eword_id = word.eword_id,
                sentence = es.Sentence,
                chinese = es.Chinese
            };
            db.sentences.InsertOnSubmit(insertone);
        }
        static string Get_Wordid(string word)
        {
            string path = "https://api.shanbay.com/bdc/search/?word={0}";
            path = string.Format(path, word);
            HttpWebRequest hwr = WebRequest.CreateHttp(path);
            HttpWebResponse hwro = (HttpWebResponse)hwr.GetResponse();
            StreamReader sr = new StreamReader(hwro.GetResponseStream());
            JObject jobject = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
            try
            {
                return jobject["data"]["id"].ToString();
            }
            catch
            {
                return null;
            }
        }
        static List<ExampleSentence> Get_Sentences(string wordid)
        {
            string path = "https://api.shanbay.com/bdc/example/?vocabulary_id={0}";
            path = string.Format(path, wordid);
            HttpWebRequest hwr = WebRequest.CreateHttp(path);
            HttpWebResponse hwro = (HttpWebResponse)hwr.GetResponse();
            StreamReader sr = new StreamReader(hwro.GetResponseStream());
            JObject jobject = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
            JToken token = jobject["data"];
            var result = new List<ExampleSentence>();
            foreach (var item in token)
            {
                ExampleSentence now = new ExampleSentence(item["translation"].ToString(), item["annotation"].ToString());
                result.Add(now);
            }
            return result;
        }
    }
    struct ExampleSentence
    {
        public string Chinese;
        public string Sentence;
        public ExampleSentence(string chinese,string sentence)
        {
            Chinese = chinese;
            Sentence = sentence;
        }
    }
}
