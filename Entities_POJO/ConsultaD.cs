using System;

namespace Entities_POJO
{
    public class ConsultaD : BaseEntity
    {
        public string fecha { get; set; }
        public int popularidad { get; set; }
        public string palabra { get; set; }
        public string idioma { get; set; }
        public string dia{ get; set; }

        public ConsultaD() { }

        public ConsultaD(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                fecha = infoArray[0];
                popularidad = int.Parse(infoArray[1]);
                palabra = infoArray[2];
                idioma = infoArray[3];
                dia = infoArray[4];
            }
            else
            {
                throw new Exception("Se requieren todos los datos");
            }

        }

    }
}
