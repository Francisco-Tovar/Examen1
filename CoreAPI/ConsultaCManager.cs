using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaCManager : BaseManager
    {
        private ConsultaCCrudFactory crudConsultaC;

        public ConsultaCManager()
        {
            crudConsultaC = new ConsultaCCrudFactory();
        }

        public List<ConsultaC> RetrieveAll()
        {
            return crudConsultaC.RetrieveAll<ConsultaC>();
        }


    }
}
