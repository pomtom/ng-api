using ng_api.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;

namespace ng_api.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                using (Entities context = new Entities())
                {
                    var message = context.ngEmployees.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, message);
                }
            }
            catch (System.Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage EmpById(string id)
        {
            try
            {
                int s = Convert.ToInt32(id);
                using (Entities context = new Entities())
                {
                    
                    var message = context.ngEmployees.FirstOrDefault(a => a.Id ==  s);
                    return Request.CreateResponse(HttpStatusCode.OK, message);
                }
            }
            catch (System.Exception ex)
            {
                string msg = string.Empty;
                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }
                else
                {
                    msg = ex.Message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
