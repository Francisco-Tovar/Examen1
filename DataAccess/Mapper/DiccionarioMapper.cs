using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class DiccionarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_DICCIONARIOID = "DICCIONARIOID";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DICCIONARIO_PR" };

            var c = (Diccionario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre.ToLower());
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DICCIONARIO_PR" };

            var c = (Diccionario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre.ToLower());

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DICCIONARIOS_PR" };
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var dicc = BuildObject(row);
                lstResults.Add(dicc);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var dicc = new Diccionario
            {
                diccionarioId = GetIntValue(row, DB_COL_DICCIONARIOID),
                nombre = GetStringValue(row, DB_COL_NOMBRE)
            };

            return dicc;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
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
    }
}
