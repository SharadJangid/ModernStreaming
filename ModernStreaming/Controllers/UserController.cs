using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModernStreaming.Models;

namespace ModernStreaming.Controllers
{
    [Authenticate]
    public class UserController : Controller
    {
        // GET: User
        
        public ActionResult Index(string searchstr, string status,
            string ddl_user_utype_id)
        {
            Users obj = new Users();
          
            // Set status value
            if (status == "0" || status == "")
            {
                obj.user_status = 0;
            }
            else if (status == null)
            {
                obj.user_status = 1;
            }
            else
            {
                obj.user_status = Convert.ToInt32(status);
            }


            if (ddl_user_utype_id != null && ddl_user_utype_id != "")
            {
                obj.user_utype_id = ddl_user_utype_id;
            }
           
            // Set search string value
            if (searchstr != null && searchstr != "")
                obj.searchstr = searchstr;

            // GET DATA according to the filters passed
            obj._listUsers = obj.GetUserList(obj);

            // Bind status list
            obj._listStatus = Users.BindStatusList(obj);

            // Bind User Type Drop Down 
            obj._DDUserType = UserType.BindUserTypeList();           

            // If ajax request is made then pass partial view
            if (Request.IsAjaxRequest())
                return PartialView("_Index", obj);

            return View(obj);
        }


     
        public ActionResult Add(string aid, string searchstr, int? page, string status)
        {
            Users obj = new Users();
          
            obj._DDUserType = UserType.BindUserTypeList();          

            // Set status value
            if (status == "0" || status == "")
            {
                obj.status = 0;
            }
            else
            {
                obj.status = Convert.ToInt32(status);
            }
         
            return View(obj);
        }

        [HttpPost]     
        public ActionResult Add(Users obj)
        {           

            if (ModelState.IsValid == true)
            {
                obj.user_edited_by = Session[SessionVariables.Id].ToString();
                obj.Mode = "I";
                obj.user_status = 1;


                string Id = obj.InsertUpdateUsers(obj);

                if (Id != null && Id != "")
                    ViewData["reg_id"] = "1";
                else
                    ViewData["reg_id"] = "0";
            }

          
            obj._DDUserType = UserType.BindUserTypeList();         

            return View(obj);
        }


        public ActionResult Edit(string aid, string searchstr, string status)
        {
            Users obj = new Users();
            obj.Id = aid;
            obj = obj.GetUsers(obj);
            obj._DDUserType = UserType.BindUserTypeList();      

            // Set status value
            if (status == "0" || status == "")
            {
                obj.status = 0;
            }
            else
            {
                obj.status = Convert.ToInt32(status);
            }
         
            return View(obj);
        }

        [HttpPost]
        
        public ActionResult Edit(Users obj)
        {
            ModelState.Remove("user_password");
           
            if (ModelState.IsValid == true)
            {
                obj.user_edited_by = Session[SessionVariables.Id].ToString();
                obj.Mode = "U";

                string Id = obj.InsertUpdateUsers(obj);

                if (Id != null && Id != "")
                    ViewData["reg_id"] = "1";
                else
                    ViewData["reg_id"] = "0";
            }

            obj._DDUserType = UserType.BindUserTypeList();          

            return View(obj);
        }

        public ActionResult DeleteUser(string aid,string name)
        {
            Users objApp = new Users();         
            objApp.Id = aid.ToString();
            objApp.user_name = name.ToString();
            return View(objApp);

        }
        [HttpPost]
        public ActionResult DeleteUser(Users objApp)
        {

            objApp.user_edited_by = Session[SessionVariables.Id].ToString();
            objApp.Mode = "D";
            string Id = objApp.InsertUpdateUsers(objApp);

            if (Id != null && Id != "")
                ViewData["reg_id"] = "1";
            else
                ViewData["reg_id"] = "0";

            return View(objApp);

        }

    }
}