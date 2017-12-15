using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;

namespace Elearn.Controllers
{
    public class DataBaseController : Controller
    {
        public static void AddIntoWechatIds(string wechatid)
        {
            using (var db = new ElearnDBDataContext())
            {
                _addintowechatids(db, wechatid);
            }
        }
        public static int tryGetUserId(string wechatid)
        {
            int result = 0;
            using (var db = new ElearnDBDataContext())
            {
                result = _trygetuserid(db, wechatid);
            }
            return result;
        }
        public static void UpdateStudents(string wechatid, string studentnum, string jwcpassword)
        {
            using (var db = new ElearnDBDataContext())
            {
                int userid = _trygetuserid(db, wechatid);
                _updatestudents(db, userid, studentnum, jwcpassword);
            }
        }
        public static string GetStudentNum(string wechatid)
        {
            using (var db = new ElearnDBDataContext())
            {
                int userid = _trygetuserid(db, wechatid);
                return _getstudentnum(db, userid);
            }
        }
        public static bool HaveBinding(string wechatid)
        {
            using (var db = new ElearnDBDataContext()) 
            {
                int userid = _trygetuserid(db, wechatid);
                return _havebinding(db, userid);
            }
        }
        public static bool tryUpdateProcesses(string wechatid, string partcode)
        {
            using (var db = new ElearnDBDataContext())
            {
                int userid = _trygetuserid(db, wechatid);
                if (!_havebinding(db, userid))
                {
                    return false;
                }
                int wordid = _getfirstwordofpart(db, partcode);
                if (wordid == int.MinValue)
                {
                    return false;
                }
                else
                {
                    _updateprocesses(db, userid, partcode, wordid);
                    return true;
                }
            }
        }
        /// <summary>
        /// 如果partcode错误，返回魔值:int.Minvalue
        /// </summary>
        /// <param name="partcode"></param>
        /// <returns></returns>
        public static int GetFirstWordOfPart(string partcode)
        {
            using (var db = new ElearnDBDataContext())
            {
                return _getfirstwordofpart(db, partcode);
            }
        }
        public static bool HaveProcess(string wechatid)
        {
            using (var db = new ElearnDBDataContext()) 
            {
                int userid = _trygetuserid(db, wechatid);
                return _haveprocess(db, userid);
            }
        }
        public static string GetNextWord(int userid, string partcode, int? wordid)
        {
            using (var db = new ElearnDBDataContext())
            {
                ewords nextword = null;
                if (_haveprocess(db, userid))
                {
                    nextword = _getnextword(db, partcode, wordid);
                    if (nextword == null)
                        return null;
                    else
                    {
                        _updateprocesses(db, userid, partcode, nextword.eword_id);
                        return nextword.eword;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public static string GetNextWord(string wechatid)
        {
            using (var db = new ElearnDBDataContext())
            {
                int userid = _trygetuserid(db, wechatid);
                var process = _getaprocess(db, userid);
                if (process == null)
                {
                    return null;
                }
                else
                {
                    return GetNextWord(userid, process.part_code, process.eword_id.Value);
                }
            }
        }
        private static processes _getaprocess(ElearnDBDataContext db, int userid)
        {
            return db.processes.SingleOrDefault(thisprocess => thisprocess.user_id == userid);
        }
        private static ewords _getnextword(ElearnDBDataContext db, string partcode, int? wordid)
        {
            var words = db.ewords.Where(word => string.Equals(word.part_code, partcode));
            bool isgetnow = false;
            foreach (var item in words)
            {
                if (isgetnow)
                    return item;
                if (item.eword_id == wordid)
                    isgetnow = true;
            }
            return null;
        }
        private static bool _haveprocess(ElearnDBDataContext db, int userid)
        {
            var process = db.processes.SingleOrDefault(user => user.user_id == userid);
            if (process != null && process.eword_id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 如果partcode错误，返回魔值:int.Minvalue
        /// </summary>
        /// <param name="partcode"></param>
        /// <returns></returns>
        private static int _getfirstwordofpart(ElearnDBDataContext db, string partcode)
        {
            var firstwords = db.ewords.Where(word => string.Equals(word.part_code, partcode));
            foreach (var item in firstwords)
            {
                return item.eword_id;
            }
            return int.MinValue;
        }
        private static void _updateprocesses(ElearnDBDataContext db, int userid, string partcode, int wordid)
        {
            var hasexistid = db.processes.SingleOrDefault(user => user.user_id == userid);
            if (hasexistid == null) 
            {
                processes insertone = new processes
                {
                    user_id = userid,
                    part_code = partcode,
                    eword_id = wordid
                };
                db.processes.InsertOnSubmit(insertone);
            }
            else
            {
                hasexistid.part_code = partcode;
                hasexistid.eword_id = wordid;
            }
            db.SubmitChanges();
        }
        private static bool _havebinding(ElearnDBDataContext db, int userid)
        {
            var student = db.students.Single(studentnow => studentnow.user_id == userid);
            if (string.IsNullOrEmpty(student.jwcpassword)) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static string _getstudentnum(ElearnDBDataContext db, int userid)
        {
            var student = db.students.Single(studentnow => studentnow.user_id == userid);
            return student.studentnum;
        }
        private static void _updatestudents(ElearnDBDataContext db, int userid, string studentnum, string jwcpassword)
        {
            var student = db.students.Single(studentnow => studentnow.user_id == userid);
            if (studentnum != null)
            {
                student.studentnum = studentnum;
                student.jwcpassword = null;
            }
            if (jwcpassword != null)
            {
                student.jwcpassword = HttpUtility.UrlEncode(jwcpassword);
            }
            db.SubmitChanges();
        }
        private static int _trygetuserid(ElearnDBDataContext db, string wechatid)
        {
            var hasexistid = db.wechatids.SingleOrDefault(wc => wc.wechat_id == wechatid);
            if (hasexistid == null) 
            {
                wechatids insertone = new wechatids
                {
                    wechat_id = wechatid
                };
                db.wechatids.InsertOnSubmit(insertone);
                db.SubmitChanges();
                return _trygetuserid(db, wechatid);
            }
            else
            {
                return hasexistid.user_id;
            }
        }
        private static void _addintowechatids(ElearnDBDataContext db, string wechatid)
        {
            var hasexistid = db.wechatids.SingleOrDefault(wc => wc.wechat_id == wechatid);
            if (hasexistid == null)
            {
                wechatids insertone = new wechatids
                {
                    wechat_id = wechatid
                };
                db.wechatids.InsertOnSubmit(insertone);
                db.SubmitChanges();
            }
        }
    }
}