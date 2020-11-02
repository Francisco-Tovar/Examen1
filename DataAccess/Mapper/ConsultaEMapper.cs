using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ConsultaEMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_PALABRA = "palabra";
        private const string DB_COL_NOMBRE = "nombre";        

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "CONSULTA_E_PR" };
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
            var user = new ConsultaE
            {
                palabra = GetStringValue(row, DB_COL_PALABRA),
                nombre = GetStringValue(row, DB_COL_NOMBRE)
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




