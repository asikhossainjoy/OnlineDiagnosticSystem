using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineDiagnosticSystem.Controllers
{
    public class LabSettingController : Controller
    {
        // GET: LabSetting
        public ActionResult LabAllTest()
        {
            return View();
        }

        public ActionResult AddTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTest(LabTestTable test)
        {
            return View();
        }


        public ActionResult AddTestDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestDetails(LabTestDetailsTable tstDetails)
        {
            return View();
        }


        public ActionResult EditTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditTest(LabTestTable test)
        {
            return View();
        }


        public ActionResult EditTestDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditTestDetails(LabTestDetailsTable tstDetails)
        {
            return View();
        }
    }
}