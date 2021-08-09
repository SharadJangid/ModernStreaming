using ModernStreaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModernStreaming.Controllers
{
    public class UserLoginController : Controller
    {
        public ActionResult Login(string logout_parameter, string user, string pass, string forgot)
        {

            UserLogin _objUserLogin = new UserLogin();
            _objUserLogin.login_msg = "";

            ViewData["forgot"] = forgot;

            if (!string.IsNullOrEmpty(logout_parameter))
            {
                //l--- for Log out by user;
                //s--- for Session Expired
                switch (logout_parameter)
                {
                    case "l":
                        _objUserLogin.login_msg = "Logout Successful!";
                        break;

                    case "s":
                        _objUserLogin.login_msg = "Session Expired!";
                        break;

                }
            }

            if (user != null && pass != null)
            {
                List<UserLogin> _listUser = new List<Models.UserLogin>();
              
                _objUserLogin.user_email = user;
                _objUserLogin.user_password = pass;
                _objUserLogin.Authenticate_AdminUser(ref _listUser);

                if (_listUser.Count > 0)
                {                                       
                    return RedirectToAction("Index", "Home");                   
                }
                else
                {
                    _objUserLogin.login_msg = "Invalid User Login Credentials!";
                }
            }


            return View(_objUserLogin);
        }

        [HttpPost]
        public ActionResult Login(UserLogin obj)
        {
           
            if (obj.user_email != "" && obj.user_password != "")
            {
                List<UserLogin> _listUser = new List<Models.UserLogin>();
                obj.Authenticate_AdminUser(ref _listUser);
                if (_listUser.Count > 0)
                {
                    Session[SessionVariables.Id] = _listUser[0].Id;               
                    Session[SessionVariables.user_name] = _listUser[0].user_name;
                    Session[SessionVariables.user_usertype_id] = _listUser[0].user_utype_id;               
                    Session[SessionVariables.user_email] = _listUser[0].user_email;
                    Session[SessionVariables.usertype_name] = _listUser[0].user_type_name;
                    Session["user_usertype_id"] = _listUser[0].user_utype_id;
                    if (_listUser[0].user_utype_id == "92811529-3336-40D4-BADF-1315A1F56381")
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else {
                        return RedirectToAction("Index", "Person");
                    }
                   

                }
                else
                {
                    obj.login_msg = "Invalid User Login Credentials!";
                }
            }

            return View(obj);
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "UserLogin", new { logout_parameter = "l" });
        }

    }
}