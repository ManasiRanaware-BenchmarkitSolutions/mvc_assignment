using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBDoctorPatient.Models;

namespace EFDBDoctorPatient.Controllers
{
    public class PatientController : Controller
    {
        EFDBDDoctorPatientEntities db = new EFDBDDoctorPatientEntities();
        // GET: Patient
        public ActionResult Index(string PatientName="", string Address = "", string DoctorName = "", string search = "", string SortColumn = "PatientID", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
           //List<Patient>patients=db.Patients.ToList();
            //return View(patients);
                // GET: Patients/Index

                //displaying all rows
                //List<Patient> Patients = db.Patients.ToList();

                //multiple rows using conditional statements
                // List<Patient> Patients = db.Patients.Where(temp=>temp.CategoryID==1 && temp.Price>=50000).ToList();

                //invoking stored procedure
                //SqlParameter[] sqlParameters = new SqlParameter[]
                //{
                //    new SqlParameter("@BrandID", 2)
                //    //you can add more parameters here
                //};
                //List<Patient> Patients = db.Database.SqlQuery<Patient>("exec getPatientsByBrandID @BrandID", sqlParameters).ToList();


                //search query
                ViewBag.Search = search;
                List<Patient> patients = db.Patients.Where(temp => temp.PatientName.Contains(search)).ToList();


                //Sorting
                ViewBag.SortColumn = SortColumn;
                ViewBag.IconClass = IconClass;
                if (ViewBag.SortColumn == "PatientID")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.PatientID).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.PatientID).ToList();
                }

                if (ViewBag.SortColumn == "PatientName")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.PatientName).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.PatientName).ToList();
                }

                if (ViewBag.SortColumn == "Age")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.Age).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.Age).ToList();
                }

                if (ViewBag.SortColumn == "Gender")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.Gender).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.Gender).ToList();
                }

                if (ViewBag.SortColumn == "DOA")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.DOA).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.DOA).ToList();
                }
                if (ViewBag.SortColumn == "DoctorID")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        patients = patients.OrderBy(temp => temp.Doctor.DoctorName).ToList();
                    else
                        patients = patients.OrderByDescending(temp => temp.DoctorID).ToList();
                }
          
                //paging
                int NoOfRecordsPerPage = 5;
                int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(patients.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
                int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
                ViewBag.PageNo = PageNo;
                ViewBag.NoOfPages = NoOfPages;
                patients = patients.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            
            if (PatientName != "" && Address != "" && DoctorName != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.PatientName.Contains(PatientName) && temp.Address.Contains(Address) && temp.Doctor.DoctorName.Contains(DoctorName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PatientName = PatientName;
                ViewBag.Address = Address;
                ViewBag.DoctorName = DoctorName;
                return View(dlist);
            }
            else if (PatientName != "" && Address != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.PatientName.Contains(PatientName) && temp.Address.Contains(Address)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PatientName = PatientName;
                ViewBag.Address = Address;
                return View(dlist);
            }
            else if (PatientName != "" && DoctorName != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.PatientName.Contains(PatientName) && temp.Doctor.DoctorName.Contains(DoctorName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PatientName = PatientName;
                ViewBag.DoctorName = DoctorName;
                return View(dlist);
            }
            else if (Address != "" && DoctorName != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.Address.Contains(Address) && temp.Doctor.DoctorName.Contains(DoctorName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.Address = Address;
                ViewBag.DoctorName = DoctorName;
                return View(dlist);
            }
            else if (Address != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.Address.Contains(Address)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.Address = Address;
                return View(dlist);
            }
            else if (DoctorName != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.Doctor.DoctorName.Contains(DoctorName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.DoctorName = DoctorName;
                return View(dlist);
            }
            else if (PatientName != "")
            {
                List<Patient> dlist = db.Patients.Where(temp => temp.PatientName.Contains(PatientName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.PatientName = PatientName;
                return View(dlist);
            }
            return View(patients);
            }

            public ActionResult Details(long id)
            {
                Patient p = db.Patients.Where(TempData => TempData.PatientID == id).FirstOrDefault();
                return View(p);
            }

            public ActionResult Create()
            {
                ViewBag.Doctors = db.Doctors.ToList();
                return View();
            }

        [HttpPost]
        public ActionResult Create([Bind(Include = "PatientID, PatientName,Age,DOA,Gender,Address,Contact,Photo,DoctorID")] Patient p)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.Patients.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Doctors = db.Doctors.ToList();
                return View();
            }
        }
            public ActionResult Edit(long id)
            {
                EFDBDDoctorPatientEntities db = new EFDBDDoctorPatientEntities();
                Patient existingPatient = db.Patients.Where(temp => temp.PatientID == id).FirstOrDefault();
                ViewBag.Doctors = db.Doctors.ToList();
                return View(existingPatient);
            }

        [HttpPost]
        public ActionResult Edit(Patient p)
        {
            EFDBDDoctorPatientEntities db = new EFDBDDoctorPatientEntities();

            Patient existingPatient = db.Patients.Where(temp => temp.PatientID == p.PatientID).FirstOrDefault();
            existingPatient.PatientName = p.PatientName;
            existingPatient.Age = p.Age;
            existingPatient.DOA = p.DOA;
            existingPatient.Gender = p.Gender;
            existingPatient.Address = p.Address;
            existingPatient.Contact = p.Contact;
            existingPatient.DoctorID = p.DoctorID;
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                    existingPatient.Photo = p.Photo;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Patient");
            }
            else
            {
                ViewBag.Doctors = db.Doctors.ToList();
                return View();
            }
            } 

        public JsonResult Delete(int did)
        {
            bool result = false;
            Patient doc = db.Patients.Where(temp => temp.PatientID == did).FirstOrDefault();
            db.Patients.Remove(doc);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Delete(long id)
        //{
        //    Patient existingPatient = db.Patients.Where(temp => temp.PatientID == id).FirstOrDefault();
        //    return View(existingPatient);
        //}

        //[HttpDelete]
        //public ActionResult Delete(long id, Patient p)
        //{
        //    Patient existingPatient = db.Patients.Where(temp => temp.PatientID == id).FirstOrDefault();
        //    db.Patients.Remove(existingPatient);
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Patient");
        //}

    }
    }



