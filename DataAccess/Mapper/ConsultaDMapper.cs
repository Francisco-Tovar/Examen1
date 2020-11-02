using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ConsultaDMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_FECHA = "fecha";
        private const string DB_COL_POPULARIDAD = "popularidad";
        private const string DB_COL_PALABRA = "palabra";
        private const string DB_COL_IDIOMA = "idioma";
        private const string DB_COL_DIA = "dia";

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONSULTA_D_PR" };
            var c = (ConsultaD)entity;
            operation.AddVarcharParam(DB_COL_DIA, c.dia.ToLower());
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
            var user = new ConsultaD
            {
                idioma = GetStringValue(row, DB_COL_IDIOMA),
                palabra = GetStringValue(row, DB_COL_PALABRA),
                popularidad = GetIntValue(row, DB_COL_POPULARIDAD),
                fecha = GetDateValue(row, DB_COL_FECHA).ToString("dd-MM-yyyy / dddd")
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



