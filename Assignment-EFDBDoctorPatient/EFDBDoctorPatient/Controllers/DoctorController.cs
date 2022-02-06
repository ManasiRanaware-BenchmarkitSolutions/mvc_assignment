using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBDoctorPatient.Models;

namespace EFDBDoctorPatient.Controllers
{
    public class DoctorController : Controller
    {
        EFDBDDoctorPatientEntities db = new EFDBDDoctorPatientEntities();
        // GET: Doctor/Index
        public ActionResult Index(string DoctorName="",string Address="",string Specialization="",string search = "", string SortColumn = "DoctorName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
                
                //List<Doctor> doctors = db.Doctors.ToList();
                //return View(doctors);

            // GET: Doctors/Index

            //displaying all rows
            //List<Doctor> Doctors = db.Doctors.ToList();

            //multiple rows using conditional statements
            // List<Doctor> Doctors = db.Doctors.Where(temp=>temp.CategoryID==1 && temp.Price>=50000).ToList();

            //invoking stored procedure
            //SqlParameter[] sqlParameters = new SqlParameter[]
            //{
            //    new SqlParameter("@BrandID", 2)
            //    //you can add more parameters here
            //};
            //List<Doctor> Doctors = db.Database.SqlQuery<Doctor>("exec getDoctorsByBrandID @BrandID", sqlParameters).ToList();


            //search query
            ViewBag.Search = search;
                List<Doctor> doctors = db.Doctors.Where(temp => temp.DoctorName.Contains(search)).ToList();
           

            //Sorting
            ViewBag.SortColumn = SortColumn;
                ViewBag.IconClass = IconClass;
                if (ViewBag.SortColumn == "DoctorID")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.DoctorID).ToList();
                    else
                    doctors = doctors.OrderByDescending(temp => temp.DoctorID).ToList();
                }

                if (ViewBag.SortColumn == "DoctorName")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                    doctors = doctors.OrderBy(temp => temp.DoctorName).ToList();
                    else
                    doctors = doctors.OrderByDescending(temp => temp.DoctorName).ToList();
                }

                if (ViewBag.SortColumn == "Specialization")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                    doctors = doctors.OrderBy(temp => temp.Specialization).ToList();
                    else
                    doctors = doctors.OrderByDescending(temp => temp.Specialization).ToList();
                }

                if (ViewBag.SortColumn == "Address")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                    doctors = doctors.OrderBy(temp => temp.Address).ToList();
                    else
                    doctors = doctors.OrderByDescending(temp => temp.Address).ToList();
                }

                if (ViewBag.SortColumn == "Contact")
                {
                    if (ViewBag.IconClass == "fa-sort-asc")
                    doctors = doctors.OrderBy(temp => temp.Contact).ToList();
                    else
                    doctors = doctors.OrderByDescending(temp => temp.Contact).ToList();
                }
                

                //paging
                int NoOfRecordsPerPage = 5;
                int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(doctors.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
                int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
                ViewBag.PageNo = PageNo;
                ViewBag.NoOfPages = NoOfPages;
            doctors = doctors.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            if (DoctorName != "" && Address != "" && Specialization != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.DoctorName.Contains(DoctorName) && temp.Address.Contains(Address) && temp.Specialization.Contains(Specialization)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.DoctorName = DoctorName;
                ViewBag.Address = Address;
                ViewBag.Specialization = Specialization;
                return View(dlist);
            }
            else if (DoctorName != "" && Address != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.DoctorName.Contains(DoctorName) && temp.Address.Contains(Address)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.DoctorName = DoctorName;
                ViewBag.Address = Address;
                return View(dlist);
            }
            else if (DoctorName != "" && Specialization != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.DoctorName.Contains(DoctorName) && temp.Specialization.Contains(Specialization)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.DoctorName = DoctorName;
                ViewBag.Specialization = Specialization;
                return View(dlist);
            }
            else if (Address != "" && Specialization != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.Address.Contains(Address) && temp.Specialization.Contains(Specialization)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.Address = Address;
                ViewBag.Specialization = Specialization;
                return View(dlist);
            }
            else if (Address != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.Address.Contains(Address)).ToList();
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
                List<Doctor> dlist = db.Doctors.Where(temp => temp.DoctorName.Contains(DoctorName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.DoctorName = DoctorName;
                return View(dlist);
            }
            else if (Specialization != "")
            {
                List<Doctor> dlist = db.Doctors.Where(temp => temp.Specialization.Contains(Specialization)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.Specialization = Specialization;
                return View(dlist);
            }

            return View(doctors);
            }

            public ActionResult Details(long id)
            {
                Doctor d = db.Doctors.Where(TempData => TempData.DoctorID == id).FirstOrDefault();
                return View(d);
            }

            public ActionResult Create()
            {
                ViewBag.Doctors = db.Doctors.ToList();
                return View();
            }

        [HttpPost]
        public ActionResult Create([Bind(Include = "DoctorID, DoctorName,Specialization,Address,Contact,Photo")] Doctor d)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    d.Photo = base64String;
                }
                db.Doctors.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
            public ActionResult Edit(long id)
            {
                Doctor existingDoctor = db.Doctors.Where(temp => temp.DoctorID == id).FirstOrDefault();
                ViewBag.Doctors = db.Doctors.ToList();
                return View(existingDoctor);
            }

            [HttpPost]
            public ActionResult Edit(Doctor d)
            {
                Doctor existingDoctor = db.Doctors.Where(temp => temp.DoctorID == d.DoctorID).FirstOrDefault();
                existingDoctor.DoctorName = d.DoctorName;
                existingDoctor.Specialization = d.Specialization;
                existingDoctor.Address = d.Address;
                existingDoctor.Contact = d.Contact;
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    d.Photo = base64String;
                    existingDoctor.Photo = d.Photo;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                return View();
            }
            }

        public JsonResult Delete(int did)
        {
            bool result = false;
            Doctor doc = db.Doctors.Where(temp => temp.DoctorID == did).FirstOrDefault();
            db.Doctors.Remove(doc);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
    }
    }



