using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class LogMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_LOGID = "LOGID";
        private const string DB_COL_USUARIOID = "USUARIOID";
        private const string DB_COL_DICCIONARIOID = "DICCIONARIOID";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_FRASE = "FRASE";
        private const string DB_COL_TRADUCCION = "TRADUCCION";
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LOG_PR" };

            var c = (Log)entity;
            operation.AddVarcharParam(DB_COL_USUARIOID, c.usuarioId);
            operation.AddIntParam(DB_COL_DICCIONARIOID, c.diccionarioId);
            operation.AddDatetimeParam(DB_COL_FECHA, c.fecha);
            operation.AddVarcharParam(DB_COL_FRASE, c.frase.ToLower());
            operation.AddVarcharParam(DB_COL_TRADUCCION, c.traduccion.ToLower());
            operation.AddIntParam(DB_COL_POPULARIDAD, c.popularidad);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LOGS" };
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
            var temp = new Log
            {
                logId = GetIntValue(row, DB_COL_LOGID),
                usuarioId= GetStringValue(row, DB_COL_USUARIOID),
                diccionarioId = GetIntValue(row, DB_COL_DICCIONARIOID),
                fecha = GetDateValue(row, DB_COL_FECHA),
                frase = GetStringValue(row, DB_COL_FRASE),
                traduccion = GetStringValue(row, DB_COL_TRADUCCION),
                popularidad = GetIntValue(row, DB_COL_POPULARIDAD)
            };

            return temp;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
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
        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

