using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaEManager : BaseManager
    {
        private ConsultaECrudFactory crudConsultaE;

        public ConsultaEManager()
        {
            crudConsultaE = new ConsultaECrudFactory();
        }

        public List<ConsultaE> RetrieveAll()
        {
            return crudConsultaE.RetrieveAll<ConsultaE>();
        }


    }
}
