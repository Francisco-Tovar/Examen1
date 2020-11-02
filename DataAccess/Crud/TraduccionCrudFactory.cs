using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class TraduccionCrudFactory : CrudFactory
    {
        TraduccionMapper mapper;

        public TraduccionCrudFactory() : base()
        {
            mapper = new TraduccionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Traduccion)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAllID<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveAllIDStatement(entity);
            var lstCustomers = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
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
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override List<T> RetrieveAll<T>()
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



