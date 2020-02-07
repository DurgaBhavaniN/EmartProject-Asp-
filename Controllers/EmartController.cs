using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmartProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EmartProject.Controllers
{
    public class EmartController : Controller
    {
        public readonly SellerContext _context;
        public readonly BuyerContext _context1;
        public readonly ProductContext _context2;
        
        private readonly IWebHostEnvironment hostingEnvironment;
        public EmartController(SellerContext context,BuyerContext context1,ProductContext context2,IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
               _context1= context1;
            _context2 = context2;
            this.hostingEnvironment = hostingEnvironment;

        }
        [HttpGet]
        public ActionResult S_SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult S_SignUp(SellerCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photpath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photpath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photpath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Seller newseller = new Seller
                {
                    s_name = model.s_name,
                    s_pwd=model.s_pwd,
                    s_emailid = model.s_emailid,
                    gstin = model.gstin,
                    bank_details=model.bank_details,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Photpath = uniqueFileName
                };

                _context.Add(newseller);
                _context.SaveChanges();
                return RedirectToAction("S_Login", new { id = newseller.s_id });
            }

            return View();
        }
        //public ActionResult S_SignUp(Seller s)
        //{
        //    try
        //    {
        //        _context.Add(s);
        //        _context.SaveChanges();
        //        ViewBag.message = s.s_name + " Has got successfully Registered";
        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.message = s.s_name + " Registration Failed";
        //        return View();
        //    }
        //}
        [HttpGet]
        public ActionResult B_SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult B_SignUp(Buyer b)
        {
            try
            {
                _context1.Add(b);
                _context1.SaveChanges();
                ViewBag.message = b.b_name + " Has got successfully Registered";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message = b.b_name + " Registration Failed";
                return View();
            }
        }
        [HttpGet]
        public ActionResult S_Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult S_Login(Seller s)
        {
            var logUser = _context.Sellers.Where(e => e.s_id ==s.s_id && e.s_pwd == s.s_pwd).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "InValid Credientials";
                return View();
            }
            else
            {
                //HttpContext.Session.SetInt32("SID", s.s_id);
                ViewBag.message = "Login Successfull";
                return RedirectToAction("SellerDashBoard");
            }
        }
        [HttpGet]
        public ActionResult B_Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult B_Login(Buyer s)
        {
            var logUser = _context1.Buyers.Where(e => e.b_id == s.b_id && e.b_pwd == s.b_pwd).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "InValid Credientials";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("SName", s.b_id);
                return RedirectToAction("BuyerDashBoard");
            }
        }

        // GET: Emart
        public ActionResult S_Index()
        {
            return View();
        }
        public ActionResult B_Index()
        {
            return View();
        }
        public ActionResult SellerDashBoard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddItems()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItems(ProductCreateViewModel model)
            {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.ItemPhoto!= null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ItemPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.ItemPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newitem = new Product
                {
                    c_id = model.c_id,
                    c_name = model.c_name,
                    sub_id = model.sub_id,
                    sub_name = model.sub_name,
                    i_name = model.i_name,
                    price = model.price,
                    gst = model.gst,
                    stk_num = model.stk_num,
                    
                    
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                   ItemPhoto = uniqueFileName
                };

                _context2.Add(newitem);
                _context2.SaveChanges();
                return RedirectToAction("SellerDashBoard", new { id = newitem.i_id });
            }

            return View();
        }
        public ActionResult DisplayS_Items(int id)
        {
            Seller seller = _context.Sellers.FirstOrDefault(e => e.s_id == id);

            return View(seller);
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("S_Login");
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Emart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Emart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}