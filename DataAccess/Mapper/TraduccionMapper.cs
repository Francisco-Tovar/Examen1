using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class TraduccionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_TRADUCCIONID = "TRADUCCIONID";
        private const string DB_COL_PALABRAID = "PALABRAID";
        private const string DB_COL_USUARIOID = "USUARIOID";
        private const string DB_COL_DICCIONARIOID = "DICCIONARIOID";
        private const string DB_COL_FECHA = "FECHA";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRADUCCION_PR" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_PALABRAID, c.palabraId);
            operation.AddVarcharParam(DB_COL_USUARIOID, c.usuarioId);
            operation.AddIntParam(DB_COL_DICCIONARIOID, c.diccionarioId);
            operation.AddDatetimeParam(DB_COL_FECHA, c.fecha);            
            return operation;
        }
        //retrieve all traducciones por palabraid
        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRADUCCIONES_PALABRA_PR" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_PALABRAID, c.palabraId);

            return operation;

        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var temp = BuildObject(row);
                lstResults.Add(temp);
            }

            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var temp = new Traduccion
            {
                traduccionId = GetIntValue(row, DB_COL_TRADUCCIONID),
                palabraId = GetIntValue(row, DB_COL_PALABRAID),
                usuarioId = GetStringValue(row, DB_COL_USUARIOID),
                diccionarioId = GetIntValue(row, DB_COL_DICCIONARIOID),
                fecha = GetDateValue(row, DB_COL_FECHA)
            };

            return temp;
        }
        
        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
