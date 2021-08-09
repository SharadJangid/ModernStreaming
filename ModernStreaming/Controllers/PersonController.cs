using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModernStreaming.Models;

namespace ModernStreaming.Controllers
{
    [Authenticate]
    public class PersonController : Controller
    {
        // GET: Person

        public ActionResult Index(string searchstr, string status, string ddl_person_gender)
        {
            Persons obj = new Persons();


            // Set status value
            if (status == "0" || status == "")
            {
                obj.person_status = 0;
            }
            else if (status == null)
            {
                obj.person_status = 1;
            }
            else
            {
                obj.person_status = Convert.ToInt32(status);
            }

            if (ddl_person_gender != null && ddl_person_gender != "")
            {
                obj.person_gender = Convert.ToInt32(ddl_person_gender);
            }

            // Set search string value
            if (searchstr != null && searchstr != "")
                obj.searchstr = searchstr;

            // GET DATA according to the filters passed
            obj._listPersons = obj.GetPersonList(obj);

            // Bind status list
            obj._listStatus = Persons.BindStatusList(obj);

            obj._DDGenderType = Persons.BindGenderList();
            // If ajax request is made then pass partial view
            if (Request.IsAjaxRequest())
                return PartialView("_Index", obj);


            return View(obj);
        }



        public ActionResult Add(string aid, string searchstr, string status)
        {
            Persons obj = new Persons();
            obj._DDGenderType = Persons.BindGenderList();
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
        public ActionResult Add(Persons obj)
        {

            if (ModelState.IsValid == true)
            {
                obj.person_edited_by = Session[SessionVariables.Id].ToString();
                obj.Mode = "I";
                obj.person_status = 1;


                string Id = obj.InsertUpdatePersons(obj);

                if (Id != null && Id != "")
                    ViewData["reg_id"] = "1";
                else
                    ViewData["reg_id"] = "0";
            }


            obj._DDGenderType = Persons.BindGenderList();
            return View(obj);
        }


        public ActionResult Edit(string aid, string searchstr, string status)
        {
            Persons obj = new Persons();
            obj.Id = aid;
            obj = obj.GetPersons(obj);

            // Set status value
            if (status == "0" || status == "")
            {
                obj.status = 0;
            }
            else
            {
                obj.status = Convert.ToInt32(status);
            }
            obj._DDGenderType = Persons.BindGenderList();

            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Persons obj)
        {
            if (ModelState.IsValid == true)
            {
                obj.person_edited_by = Session[SessionVariables.Id].ToString();
                obj.Mode = "U";

                string Id = obj.InsertUpdatePersons(obj);

                if (Id != null && Id != "")
                    ViewData["reg_id"] = "1";
                else
                    ViewData["reg_id"] = "0";
            }
            obj._DDGenderType = Persons.BindGenderList();
            return View(obj);
        }

        public ActionResult PersonDetail(string aid)
        {

            Persons obj = new Persons();
            obj.Id = aid;
            obj = obj.GetPersons(obj);

            return View(obj);
        }

        public ActionResult DeletePerson(string aid, string fname, string lname)
        {
            Persons objApp = new Persons();
            objApp.Id = aid.ToString();
            objApp.person_first_name = fname.ToString();
            objApp.person_last_name = lname.ToString();
            return View(objApp);

        }
        [HttpPost]
        public ActionResult DeletePerson(Persons objApp)
        {

            objApp.person_edited_by = Session[SessionVariables.Id].ToString();
            objApp.Mode = "D";
            string Id = objApp.InsertUpdatePersons(objApp);

            if (Id != null && Id != "")
                ViewData["reg_id"] = "1";
            else
                ViewData["reg_id"] = "0";

            return View(objApp);

        }

    }
}