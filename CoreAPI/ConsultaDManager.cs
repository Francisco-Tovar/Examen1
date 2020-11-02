using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaDManager : BaseManager
    {
        private ConsultaDCrudFactory crudConsultaD;

        public ConsultaDManager()
        {
            crudConsultaD = new ConsultaDCrudFactory();
        }

        public List<ConsultaD> RetrieveAllID(ConsultaD temp)
        {
            return crudConsultaD.RetrieveAllID<ConsultaD>(temp);
        }


    }
}


