using ng_api.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ng_api.Controllers
{
    public class StudentController : ApiController
    {
        public StudentController()
        {

        }

        [HttpPost]
        public void Create(ngStudent student)
        {
            try
            {
                using (Entities context = new Entities())
                {
                    context.ngStudents.Add(student);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                using (Entities context = new Entities())
                {
                    var message = context.ngStudents.ToList();
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
