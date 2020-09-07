using JigneshPractical.Model;
using JigneshPractical.Repository;
using JigneshPractical.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JigneshPractical.Controllers
{
    public class HomeController : Controller
    {
        IUser_Repository User_Repository = new User_Repository(new JigneshPracticalEntities());

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.CityList = User_Repository.GetCityList();
            ViewBag.UserCode = User_Repository.GetUserCode();
            return View();
        }

        [HttpPost]
        public JsonResult MST_User_Register(MST_User _model)
        {
            List<MST_User_Register_Result> Data = new List<MST_User_Register_Result>();
            int ReturnValue = 0;
            string RetuenMsg = "";
            try
            {
                Data = User_Repository.MST_User_Register(_model.User_Name, _model.Email_ID, _model.Password, _model.City_ID, out ReturnValue, out RetuenMsg);
                if (Data.Count > 0)
                {
                    string stEmailAddress = _model.Email_ID;

                    string stSubject = "Registration Mail";
                    string strbodytext = MailBody.SetRegistrationBody(_model.User_Name);
                    try
                    {
                        MailUstils.SendMail(stSubject, strbodytext, stEmailAddress);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ReturnValue = 0;
                RetuenMsg = ex.Message.ToString();
            }
            finally
            {
                User_Repository.Dispose();
            }
            return Json(new { ReturnValue = ReturnValue, RetuenMsg = RetuenMsg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult User_Login(MST_User _model)
        {
            List<User_Login_Result> Data = new List<User_Login_Result>();
            int ReturnValue = 0;
            string RetuenMsg = "";
            try
            {
                Data = User_Repository.User_Login(_model.User_Name, _model.Password, out ReturnValue, out RetuenMsg);
                if (Data.Count == 1)
                {
                    SessionUtils.UserSession = Data[0];
                }
                else
                {
                    ReturnValue = 0;
                    RetuenMsg = "Invalid User Name OR Password";
                }
            }
            catch (Exception ex)
            {
                ReturnValue = 0;
                RetuenMsg = ex.Message.ToString();
            }
            finally
            {
                User_Repository.Dispose();
            }
            return Json(new { ReturnValue = ReturnValue, RetuenMsg = RetuenMsg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult User_Logout()
        {
            SessionUtils.UserSession = null;
            return Json(new { ReturnValue = 1, RetuenMsg = "Logout Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}