using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class LogCrudFactory : CrudFactory
    {
        LogMapper mapper;

        public LogCrudFactory() : base()
        {
            mapper = new LogMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Log)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }


        //---------------------------------------------------------------------------------
        public override List<T> RetrieveAllID<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}




