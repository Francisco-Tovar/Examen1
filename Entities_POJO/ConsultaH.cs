using System;

namespace Entities_POJO
{
    public class ConsultaH : BaseEntity
    {        
        public string usuario { get; set; }
        public int traducciones { get; set; }

        public ConsultaH() { }

        public ConsultaH(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {                
                usuario = infoArray[0];
                traducciones = int.Parse(infoArray[1]);
            }
            else
            {
                throw new Exception("Se requieren todos los datos [usuario, traducciones]");
            }

        }

    }
}

