using System;

namespace Entities_POJO
{
    public class ConsultaE : BaseEntity
    {
        public string palabra { get; set; }
        public string nombre { get; set; }        

        public ConsultaE() { }

        public ConsultaE(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                palabra = infoArray[0];
                nombre = infoArray[1];                
            }
            else
            {
                throw new Exception("Se requieren todos los datos [palabra,nombre]");
            }

        }

    }
}

