using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaBManager : BaseManager
    {
        private ConsultaBCrudFactory crudConsultaB;

        public ConsultaBManager()
        {
            crudConsultaB = new ConsultaBCrudFactory();
        }

        public List<ConsultaB> RetrieveAll()
        {
            return crudConsultaB.RetrieveAll<ConsultaB>();
        }


    }
}
