using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBDoctorPatient.Models;
using System.Data.Entity;

namespace EFDBDoctorPatient.Controllers
{
    public class MedicineController : Controller
    {
        EFDBDDoctorPatientEntities db = new EFDBDDoctorPatientEntities(); 
        // GET: Medicine
        public ActionResult Index()
        {
            
                List<Medicine> data = db.Medicines.Select(m => m).ToList();
            
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Medicine med)
        {
            try
            {
                ModelState.Remove("MedicineID");
                if (ModelState.IsValid)
                {
                    db.Medicines.Add(med);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            Medicine med= db.Medicines.Where(m=>m.MedicineID==id).FirstOrDefault();
            return View("Create",med);
        }

        [HttpPost]
        public ActionResult Edit(Medicine med)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(med).State = System.Data.Entity.EntityState.Modified;
                    Medicine data = db.Medicines.Find(med.MedicineID);
                    data.MedicineName= med.MedicineName;
                    data.Description= med.Description;
                    data.ExpiryDate = med.ExpiryDate;
                    data.RequestedDate = med.RequestedDate;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Medicine med = db.Medicines.Find(id);
            if(med!=null)
            {
                db.Medicines.Remove(med);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}