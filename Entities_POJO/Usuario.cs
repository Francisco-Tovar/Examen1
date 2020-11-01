using System;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string usuarioId { get; set; }
        public string nombre { get; set; }

        public Usuario() { }

        public Usuario(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                usuarioId = infoArray[0];
                nombre = infoArray[1];              
            }
            else
            {
                throw new Exception("Se requieren todos los datos [UsuarioId,nombre]");
            }

        }

    }
}
