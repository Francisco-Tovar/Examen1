using System;

namespace Entities_POJO
{
    public class ConsultaF : BaseEntity
    {
        public string idioma { get; set; }
        public string palabra { get; set; }
        public string traduccion { get; set; }

        public ConsultaF() { }

        public ConsultaF(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                idioma = infoArray[0];
                palabra = infoArray[1];
                traduccion = infoArray[2];
            }
            else
            {
                throw new Exception("Se requieren todos los datos");
            }

        }

    }
}
