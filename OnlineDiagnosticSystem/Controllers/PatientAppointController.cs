﻿using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineDiagnosticSystem.Controllers
{
    public class PatientAppointController : Controller
    {
        private OnlineDiagnosticLabSystemDbEntities db = new OnlineDiagnosticLabSystemDbEntities();
        public ActionResult GetAllDoctors()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var doclist = db.DoctorTables.Where(d => d.UserTable.isVerified == true);

            return View(doclist);
        }

        public ActionResult GetAlllabs()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var lablist = db.LabTables.Where(d => d.UserTable.isVerified == true);

            return View(lablist);
        }

        public ActionResult DoctorAppointment(int? id) 
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.DoctorTimeSlotID =new SelectList(db.DoctorTimeSlotTables.Where(d => d.DoctorID == id && d.IsActive == true ), "DoctorTimeSlotID", "Name","0");
            ViewBag.Doctor = db.DoctorTables.Find(id);

            return View();

        }
        [HttpPost]
        public ActionResult DoctorAppointment(DoctorAppointTable appointment)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            appointment.DoctorComment = string.Empty;
            appointment.IsChecked = false;
            appointment.IsFeeSubmit = false;
            if(ModelState.IsValid) 
            {
                var checktransectiono = db.DoctorAppointTables.Where(c => c.TransectionNo == appointment.TransectionNo).FirstOrDefault();
                if (checktransectiono == null) 
                {
                    var find = db.DoctorAppointTables.Where(p => p.DoctorTimeSlotID == appointment.DoctorTimeSlotID && p.DoctorID == appointment.DoctorID && p.AppointDate == appointment.AppointDate).FirstOrDefault();
                    if (find == null)
                    {
                        db.DoctorAppointTables.Add(appointment);
                        db.SaveChanges();
                        return RedirectToAction("DoctorPendingApoint");

                    }
                    else 
                    {
                        ViewBag.Message = "Time Slot is Already Assign! (another patient)";
                    }

                }else 
                {
                    ViewBag.Message = "Transaction No is Already Used! for another transaction!";
                }   
            }
            ViewBag.DoctorTimeSlotID = new SelectList(db.DoctorTimeSlotTables.Where(d => d.DoctorID == appointment.DoctorID && d.IsActive == true), "DoctorTimeSlotID", "Name", "0");
            return View();

        }


        public ActionResult DoctorProfile(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var doc = db.DoctorTables.Find(id);
            return View(doc);
        }

        public ActionResult DoctorPendingApoint(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int patientid = db.PatientTables.Where(p => p.UserID == userid).FirstOrDefault().PatientID;
            var appointmentlist = db.DoctorAppointTables.Where(p => p.PatientID == patientid && p.IsFeeSubmit == false && p.IsChecked == false);
            return View(appointmentlist);
        }

    }
}