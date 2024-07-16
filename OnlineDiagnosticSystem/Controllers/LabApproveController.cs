using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineDiagnosticSystem.Controllers
{
    public class LabApproveController : Controller
    {
        private OnlineDiagnosticLabSystemDbEntities db = new OnlineDiagnosticLabSystemDbEntities();
        public ActionResult PendingAppoint()
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var lab = (LabTable)Session["Lab"];
            var pendingappointment = db.LabAppointTables.Where(d => d.LabID == lab.LabID && d.IsFeeSubmit == false && d.IsFeeSubmit == false );
            return View(pendingappointment);


        }

        public ActionResult CompleteAppointment()
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var lab = (LabTable)Session["Lab"];
            var Completeappointment = db.LabAppointTables.Where(d => d.LabID == lab.LabID && d.IsComplete == true && d.IsFeeSubmit == true);
            return View(Completeappointment);


        }
        public ActionResult CurrentAppoint()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var lab = (LabTable)Session["Lab"];
            var Completeappointment = db.LabAppointTables.Where(d => d.LabID == lab.LabID && d.IsComplete == false && d.IsFeeSubmit == true);
            return View(Completeappointment);


        }

        public ActionResult AllAppoint()
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var lab = (LabTable)Session["Lab"];
            var allappointment = db.LabAppointTables.Where(d => d.LabID == lab.LabID );
            return View(allappointment);


        }


        public ActionResult ChangeStatus(int? id)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var appoint = db.LabAppointTables.Find(id);
            ViewBag.LabTimeSlotID = new SelectList(db.LabTimeSlotTables.Where(d => d.LabID == appoint.LabID), "LabTimeSlotID", "Name", appoint.LabTimeSlotID);

            return View(appoint);
        }

        [HttpPost]
        public ActionResult ChangeStatus(LabAppointTable app)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {

                db.Entry(app).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PendingAppoint");

            }
            ViewBag.LabTimeSlotID = new SelectList(db.LabTimeSlotTables.Where(d => d.LabID == app.LabID), "LabTimeSlotID", "Name", app.LabTimeSlotID);

            return View(app);

        }
        public ActionResult ProcessAppointment(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var appoint = db.LabAppointTables.Find(id);
            ViewBag.LabTimeSlotID = new SelectList(db.LabTimeSlotTables.Where(d => d.LabID == appoint.LabID), "LabTimeSlotID", "Name", appoint.LabTimeSlotID);

            return View(appoint);
        }


    }
}