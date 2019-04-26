using EmptyASP.Models;
using EmptyASP.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EmptyASP.Controllers
{
    public class ItemController : Controller
    {
        static MyContext myContext = new MyContext();
        Item item= new Item();
        //public ItemController(MyContext _myContext)
        //{
        //    myContext = _myContext;
        //}
        //public ItemController()
        //{ }
        // GET: Item
        public ActionResult Index()
        {
            //return View(myContext.Items.Include("suppliers").ToList());
            //return View(myContext.Items.Where(a => a.IsDelete == false).ToList());
            IEnumerable<ItemVM> itemVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ItemVM>>();
                readTask.Wait();
                itemVM = readTask.Result;
            }
            else
            {
                itemVM = Enumerable.Empty<ItemVM>();
                ModelState.AddModelError(string.Empty, "Server error to try after some time");
            }
            return View(itemVM);
        }
        

        // GET: Item/Details/5
        public ActionResult Details(int Id)
        {
            return View(myContext.Items.SingleOrDefault(a => a.Id == Id));
        }

        //GET: Item/Create
        public ActionResult Create()
        {
            var get = myContext.Suppliers.OrderBy(x => x.Name).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            ViewBag.Suppliers = get;
            return View();
        }

        // POST: Item/Create
        //[HttpPost]
        //public ActionResult Create(ItemVM itemVM)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        //var Supplier = item.suppliers.ToList(); => Ini ditulis pada Get bukan Post
        //        //ViewBag.PayList = new SelectList(PayList, "Id", "Name");
        //        //myContext.Items.Add(item);
        //        //myContext.SaveChanges();
        //        if (ModelState.IsValid)
        //        {
        //            var getSupplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
        //            Item item = new Item()
        //            {
        //                Name = itemVM.Name,
        //                price = itemVM.price,
        //                stock = itemVM.stock,
        //                suppliers = getSupplier
        //            };
        //            myContext.Items.Add(item);
        //            myContext.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(itemVM);
        //    }
        //}

        public void Insert(ItemVM itemVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var myContent = JsonConvert.SerializeObject(itemVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("Items", byteContent).Result;
        }

        // GET: Item/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var get = myContext.Suppliers.OrderBy(x => x.Name).Select(i => new SelectListItem()
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString(),
        //        Selected = false
        //    }).ToArray();
        //    ViewBag.Suppliers = get;
        //    var getSupplier = myContext.Items.Find(id);
        //    ItemVM itemVm = new ItemVM()
        //    {
        //        Name = getSupplier.Name,
        //        price = getSupplier.price,
        //        stock = getSupplier.stock,
        //        Suppliers_Id = getSupplier.suppliers.Id
        //    };
        //    return View(itemVm);
        //}

        // POST: Item/Edit/5

        public string Get(int Id)
        {
            ItemVM itemVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var responseTask = client.GetAsync("Items/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ItemVM>();
                readTask.Wait();
                itemVM = readTask.Result;
            }
            else
            {
                itemVM = null;
                ModelState.AddModelError(string.Empty, "Server error to try after some time");
            }
            return JsonConvert.SerializeObject(itemVM);
        }
        //[HttpPost]
        //public ActionResult Edit(int id, ItemVM itemVM)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        //myContext.SaveChanges();
        //        //return RedirectToAction("Index");
        //        if (ModelState.IsValid)
        //        {
        //            var getSupplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
        //            var get = myContext.Items.Find(id);
        //            get.Name = itemVM.Name;
        //            get.price = itemVM.price;
        //            get.stock = itemVM.stock;
        //            get.suppliers = getSupplier;
        //            myContext.Entry(get).State = EntityState.Modified;
        //            myContext.SaveChanges();
        //        }
        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return View(itemVM);
        //    }
        //}

        // GET: Item/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var get = myContext.Items.Find(id);
        //    return View(get);
        //}

        // POST: Item/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    //try
        //    //{
        //        // TODO: Add delete logic here
        //        var get = myContext.Items.Find(id);
        //        myContext.Entry(get).State = EntityState.Deleted;
        //        myContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    //    }
        //    //    catch
        //    //    {
        //    //        return View(myContext);
        //    //    }
        //}

        public void Edit(ItemVM itemVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var myContent = JsonConvert.SerializeObject(itemVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (itemVM.Id.Equals(0))
            {
                var result = client.PutAsync("Suppliers", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Items/" + itemVM.Id, byteContent).Result;
            }
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:17909/api/");
            var result = client.DeleteAsync("Items/" + id).Result;
        }
    }
}
