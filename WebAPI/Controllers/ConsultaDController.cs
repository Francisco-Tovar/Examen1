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
    public class ConsultaDController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        
        public IHttpActionResult Get(string dia)
        {
            try
            {
                var mng = new ConsultaDManager();
                apiResp = new ApiResponse();
                ConsultaD cons = new ConsultaD();
                cons.dia = dia;

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

