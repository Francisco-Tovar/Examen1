using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaAManager : BaseManager
    {
        private ConsultaACrudFactory crudConsultaA;

        public ConsultaAManager()
        {
            crudConsultaA = new ConsultaACrudFactory();
        }

        public List<ConsultaA> RetrieveAll()
        {
            return crudConsultaA.RetrieveAll<ConsultaA>();
        }
        

    }
}

