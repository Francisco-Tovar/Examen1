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
    public class ConsultaGController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();


        public IHttpActionResult Get(string palabra)
        {
            try
            {
                var mng = new ConsultaGManager();
                apiResp = new ApiResponse();
                ConsultaG cons = new ConsultaG();
                cons.palabra = palabra;

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

