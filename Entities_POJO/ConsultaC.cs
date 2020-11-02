using System;

namespace Entities_POJO
{
    public class ConsultaC : BaseEntity
    {
        public string palabra { get; set; }
        public string idioma { get; set; }
        public int traducciones { get; set; }

        public ConsultaC() { }

        public ConsultaC(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                palabra = infoArray[0];
                idioma = infoArray[1];
                traducciones = int.Parse(infoArray[2]);
            }
            else
            {
                throw new Exception("Se requieren todos los datos [palabra,idioma, traducciones]");
            }

        }

    }
}
