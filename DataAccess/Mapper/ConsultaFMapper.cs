using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ConsultaFMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDIOMA = "idioma";
        private const string DB_COL_PALABRA = "palabra";
        private const string DB_COL_TRADUCCION = "traduccion";
                
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONSULTA_F_PR" };
            var c = (ConsultaF)entity;
            operation.AddVarcharParam(DB_COL_IDIOMA, c.idioma.ToLower());
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
            var user = new ConsultaF
            {
                idioma = GetStringValue(row, DB_COL_IDIOMA),
                palabra = GetStringValue(row, DB_COL_PALABRA),
                traduccion = GetStringValue(row, DB_COL_TRADUCCION)
            };

            return user;
        }

        //--------------------------------------------------------------------------
        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        SqlOperation ISqlStatements.GetRetriveAllIDStatement(BaseEntity entity)
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



