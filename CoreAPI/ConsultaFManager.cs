using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaFManager : BaseManager
    {
        private ConsultaFCrudFactory crudConsultaF;

        public ConsultaFManager()
        {
            crudConsultaF = new ConsultaFCrudFactory();
        }

        public List<ConsultaF> RetrieveAllID(ConsultaF temp)
        {
            return crudConsultaF.RetrieveAllID<ConsultaF>(temp);
        }


    }
}

