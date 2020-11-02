using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ConsultaGManager : BaseManager
    {
        private ConsultaGCrudFactory crudConsultaG;

        public ConsultaGManager()
        {
            crudConsultaG = new ConsultaGCrudFactory();
        }

        public List<ConsultaG> RetrieveAllID(ConsultaG temp)
        {
            return crudConsultaG.RetrieveAllID<ConsultaG>(temp);
        }


    }
}


