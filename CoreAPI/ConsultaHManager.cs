using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaHManager : BaseManager
    {
        private ConsultaHCrudFactory crudConsultaH;

        public ConsultaHManager()
        {
            crudConsultaH = new ConsultaHCrudFactory();
        }

        public List<ConsultaH> RetrieveAll()
        {
            return crudConsultaH.RetrieveAll<ConsultaH>();
        }


    }
}

