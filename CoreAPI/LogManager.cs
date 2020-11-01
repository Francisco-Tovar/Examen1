using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class LogManager : BaseManager
    {
        private LogCrudFactory crudLog;

        public LogManager()
        {
            crudLog = new LogCrudFactory();

        }

        public void Create(Log temp)
        {
            try
            {
                crudLog.Create(temp);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // todas los logs 
        public List<Log> RetrieveAll()
        {
            return crudLog.RetrieveAll<Log>();
            
        }

    }
}
