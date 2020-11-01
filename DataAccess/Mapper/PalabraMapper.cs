using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class PalabraMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_PALABRAID = "PALABRAID";
        private const string DB_COL_DICCIONARIOID = "DICCIONARIOID";
        private const string DB_COL_PALABRA = "PALABRA";
        private const string DB_COL_SIGNIFICADO = "SIGNIFICADO";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PALABRA_PR" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_DICCIONARIOID, c.diccionarioId);
            operation.AddVarcharParam(DB_COL_PALABRA, c.palabra.ToLower());
            operation.AddVarcharParam(DB_COL_SIGNIFICADO, c.significado.ToLower());
            return operation;
        }
        // recupera la palabra por diccionario
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PALABRA_DIC_PR" };

            var c = (Palabra)entity;
            operation.AddVarcharParam(DB_COL_PALABRA, c.palabra.ToLower());
            operation.AddIntParam(DB_COL_DICCIONARIOID, c.diccionarioId);

            return operation;
        }
        //recupera todas las palabras del diccionario
        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PALABRAS_ID_PR" };
            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_DICCIONARIOID, c.diccionarioId);
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
            var temp = new Palabra
            {
                palabraId = GetIntValue(row, DB_COL_PALABRAID),
                diccionarioId = GetIntValue(row, DB_COL_DICCIONARIOID),
                palabra = GetStringValue(row, DB_COL_PALABRA),
                significado = GetStringValue(row, DB_COL_SIGNIFICADO)
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
    }
}

