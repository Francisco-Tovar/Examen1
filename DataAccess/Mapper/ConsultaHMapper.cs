using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ConsultaHMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_USUARIO = "usuario";
        private const string DB_COL_TRADUCCIONES = "traducciones";

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "CONSULTA_H_PR" };
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new ConsultaH
            {
                usuario = GetStringValue(row, DB_COL_USUARIO),
                traducciones = GetIntValue(row, DB_COL_TRADUCCIONES)
            };

            return user;
        }

        //--------------------------------------------------------------------------
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        SqlOperation ISqlStatements.GetRetriveAllIDStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        SqlOperation ISqlStatements.GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        SqlOperation ISqlStatements.GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}



