using System;

namespace Entities_POJO
{
    public class ConsultaB : BaseEntity
    {
        public string idioma { get; set; }
        public int traducciones { get; set; }

        public ConsultaB() { }

        public ConsultaB(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                idioma = infoArray[0];
                traducciones = int.Parse(infoArray[1]);
            }
            else
            {
                throw new Exception("Se requieren todos los datos [nombre, traducciones]");
            }

        }

    }
}