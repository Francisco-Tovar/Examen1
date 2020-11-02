using System;

namespace Entities_POJO
{
    public class ConsultaG : BaseEntity
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public string palabra { get; set; }
        public string significado{ get; set; }
        public string idioma{ get; set; }

        public ConsultaG() { }

        public ConsultaG(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 6)
            {
                id = int.Parse(infoArray[0]);
                fecha = DateTime.Parse(infoArray[1]);
                usuario = infoArray[2];
                palabra = infoArray[3];
                significado = infoArray[4];
                idioma = infoArray[5];
            }
            else
            {
                throw new Exception("Se requieren todos los datos");
            }

        }

    }
}
