using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class ConsultaFController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/distrito/ - Retrieve by IdCanton
        public IHttpActionResult Get(string idioma)
        {
            try
            {
                var mng = new ConsultaFManager();
                apiResp = new ApiResponse();
                ConsultaF cons = new ConsultaF();
                cons.idioma = idioma;
                
                apiResp.Data = mng.RetrieveAllID(cons);
                return Ok(apiResp);


            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}

