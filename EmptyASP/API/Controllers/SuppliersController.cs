using BussinessLogic.Applications.Interfaces;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly ISupplierApplication _supplierApplication;
        public SuppliersController(ISupplierApplication supplierApplication)
        {
            _supplierApplication = supplierApplication;
        }
        // GET: api/Suppliers
        public HttpResponseMessage Get()
        {
            //message error respon (404, 403, ...)
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data Available");
            List<Supplier> get = _supplierApplication.Get();
            if (get.Count() != 0)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

        // GET: api/Suppliers/5
        public HttpResponseMessage Get(int Id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Such Data Exist");
            var get = _supplierApplication.Get(Id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
            //return "value";
        }

        // POST: api/Suppliers
        public HttpResponseMessage Post([FromBody]SupplierVM supplierVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = _supplierApplication.Insert(supplierVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, supplierVM);
                return message;
            }
            return message;

        }

        // PUT: api/Suppliers/5
        public HttpResponseMessage Put(int Id, [FromBody]SupplierVM supplierVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = _supplierApplication.Update(Id, supplierVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, supplierVM);
                return message;
            }
            return message;
        }

        // DELETE: api/Suppliers/5
        public HttpResponseMessage Delete(int Id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Such Data Exist");
            var get = _supplierApplication.Delete(Id);
            if (get)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data has successfully deleted");
                return message;
            }
            return message;
        }
    }
}
