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