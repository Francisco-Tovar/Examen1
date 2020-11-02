using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ConsultaGMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "id";
        private const string DB_COL_FECHA = "fecha";
        private const string DB_COL_USUARIO = "usuario";
        private const string DB_COL_PALABRA = "palabra";
        private const string DB_COL_SIGNIFICADO = "significado";
        private const string DB_COL_IDIOMA = "idioma";

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONSULTA_G_PR" };
            var c = (ConsultaG)entity;
            operation.AddVarcharParam(DB_COL_PALABRA, c.palabra.ToLower());
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
            var user = new ConsultaG
            {
                id = GetIntValue(row, DB_COL_ID),
                fecha = GetDateValue(row, DB_COL_FECHA),
                usuario = GetStringValue(row, DB_COL_USUARIO),
                palabra= GetStringValue(row, DB_COL_PALABRA),
                significado= GetStringValue(row, DB_COL_SIGNIFICADO),
                idioma = GetStringValue(row, DB_COL_IDIOMA)
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



