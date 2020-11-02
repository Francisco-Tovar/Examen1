using System;

namespace Entities_POJO
{
    public class ConsultaA : BaseEntity
    {        
        public string nombre { get; set; }

        public ConsultaA() { }

        public ConsultaA(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 1)
            {                
                nombre = infoArray[0];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [nombre]");
            }

        }

    }
}
