﻿using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        

        //---------------------------------------------------------------------------------
        public override List<T> RetrieveAllID<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

