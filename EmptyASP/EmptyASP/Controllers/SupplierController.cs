using EmptyASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyASP.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EmptyASP.Controllers
{
    public class SupplierController : Controller
    {
        MyContext myContext = new MyContext();
        Supplier supplier = new Supplier();
        // GET: Supplier

        public ActionResult LoadData()
        {
            try
            {
                //Creating instance of DatabaseContext class  
                {
        var draw = Request.Form.GetValues("draw").FirstOrDefault();
        var start = Request.Form.GetValues("start").FirstOrDefault();
        var length = Request.Form.GetValues("length").FirstOrDefault();
        var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


        //Paging Size (10,20,50,100)    
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        // Getting all Customer data    
        var getsupplier = (from Supplier in myContext.Suppliers select Supplier);

                    //Sorting    
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        getsupplier = getsupplier.OrderBy(sortColumn + " " + sortColumnDir);
                    }
                    //Search    
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        getsupplier = getsupplier.Where(m => m.Name == searchValue);
                    }

            //total number of rows count     
                recordsTotal = getsupplier.Count();
                    //Paging     
                    var data = getsupplier.Skip(skip).Take(pageSize).ToList();
                    //Returning Json Data    
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Index()
        {
            //return View(myContext.Suppliers.Where(a => a.IsDelete == false).ToList());
            IEnumerable<SupplierVM> supplierVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var responseTask = client.GetAsync("Suppliers");
            responseTask.Wait();
            var result = responseTask.Result;
            if( result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierVM>>();
                readTask.Wait();
                supplierVM = readTask.Result;
            }
            else
            {
                supplierVM = Enumerable.Empty<SupplierVM>();
                ModelState.AddModelError(string.Empty, "Server error to try after some time");
            }
            return View(supplierVM);
        }

        // GET: Supplier/Details/5
        //public ActionResult Details(int Id)
        //{
        //    return View(myContext.Suppliers.SingleOrDefault(a => a.Id == Id));
        //}
        

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        //[HttpPost]
        //public ActionResult Create(SupplierVM supplierVM)
        //   {
        //        ModelState.AddModelError("Name", "Name is Empty");
        //   {
        //    if (string.IsNullOrWhiteSpace(supplierVM.Name))
        //      return View();
        //    }
        //    else
        //    {
        //        var client = new HttpClient();
        //        client.BaseAddress = new Uri("http://localhost:17909/api/");
        //        var postTask = client.PostAsJsonAsync("Suppliers", supplierVM);
        //        postTask.Wait();
        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError(string.Empty, "Server Eror. Pllease Input Name");
        //        return View(supplierVM);
        //    }
        //    //try
        //    //{
        //    //    // TODO: Add insert logic here
        //    //    if (supplier.Name == null)
        //    //    {
        //    //        ModelState.AddModelError("Name", "Please Input Name Supplier");

        //    //    }
        //    //    else
        //    //    {
        //    //        myContext.Suppliers.Add(supplier);
        //    //        myContext.SaveChanges();
        //    //        ViewBag.Message = "Insert Supplier Succesfully";
        //    //    }
        //    //    return RedirectToAction("Index");
        //    //}
        //    //catch
        //    //{
        //    //    return View(myContext);
        //    //}
        //}

        public void Insert(SupplierVM supplierVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var myContent = JsonConvert.SerializeObject(supplierVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("Suppliers", byteContent).Result;
        }

        //public JsonResult Insert(SupplierVM supplierVM)
        //{
        //    if (string.IsNullOrWhiteSpace(supplierVM.Name))
        //    {
        //        ModelState.AddModelError("Name", "Name Is Empty");
        //        return Json(new { success = true, JsonRequestBehavior.AllowGet });
        //    }
        //    else
        //    {
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:17909/api/");
        //    var response = client.PostAsJsonAsync("Suppliers", supplierVM);
        //    response.Wait();
        //            var result = response.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                TempData["message"] = "Supplier data added";
        //                return Json(new { success = true, JsonRequestBehavior.AllowGet
        //});
        //            }
        //            else
        //            {
        //                return Json(new { success = true, JsonRequestBehavior.AllowGet });
        //            }
        //    }
        //}

        // GET: Supplier/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var get = myContext.Suppliers.Find(id);
        //    return View(get);
        //}

        public string Get(int Id)
        {
            SupplierVM supplierVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var responseTask = client.GetAsync("Suppliers/" +Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<SupplierVM>();
                readTask.Wait();
                supplierVM = readTask.Result;
            }
            else
            {
                supplierVM = null;
                ModelState.AddModelError(string.Empty, "Server error to try after some time");
            }
            return JsonConvert.SerializeObject(supplierVM);
        }

        public void Edit(SupplierVM supplierVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var myContent = JsonConvert.SerializeObject(supplierVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (supplierVM.Id.Equals(0))
            {
                var result = client.PutAsync("Suppliers", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Suppliers/" + supplierVM.Id, byteContent).Result;
            }
        }


        // POST: Supplier/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, Supplier supplier)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        var get = myContext.Suppliers.Find(id);
        //        get.Name = supplier.Name;
        //        myContext.Entry(get).State = EntityState.Modified;
        //        myContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(myContext);
        //    }
        //}


        //// GET: Supplier/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var get = myContext.Suppliers.Find(id);
        //    return View(get);
        //}

        //POST: Supplier/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    //try
        //    //{
        //    // TODO: Add delete logic here
        //    var get = myContext.Suppliers.Find(id);
        //    get.IsDelete = true;
        //    myContext.Entry(get).State = EntityState.Modified;
        //    myContext.SaveChanges();
        //    return RedirectToAction("Index");
        //    //}
        //    //catch
        //    //{
        //    //    return View(myContext);
        //    //}
        //}

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var result = client.DeleteAsync("Suppliers/" + id).Result;
        }

        public JsonResult LoadSupplier()
        {
            IEnumerable<SupplierVM> supplierVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var responseTask = client.GetAsync("Suppliers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierVM>>();
                readTask.Wait();
                supplierVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(supplierVM, JsonRequestBehavior.AllowGet);
        }

    }
}
