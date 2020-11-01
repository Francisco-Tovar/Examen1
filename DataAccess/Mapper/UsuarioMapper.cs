using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_USUARIOID = "USUARIOID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_USUARIOID, c.usuarioId);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_USUARIOID, c.usuarioId.ToLower());

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
            var user = new Usuario
            {
                usuarioId = GetStringValue(row, DB_COL_USUARIOID),
                nombre = GetStringValue(row, DB_COL_NOMBRE)
            };

            return user;
        }

        SqlOperation ISqlStatements.GetRetriveAllIDStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveAllStatement()
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
