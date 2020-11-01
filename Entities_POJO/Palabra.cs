using System;

namespace Entities_POJO
{
    public class Palabra : BaseEntity
    {
        public int palabraId { get; set; }
        public int diccionarioId { get; set; }
        public string palabra { get; set; }
        public string significado { get; set; }

        public Palabra() { }

        public Palabra(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                var x = 0;
                if (Int32.TryParse(infoArray[0], out x))
                    palabraId = x;
                else
                    throw new Exception("El id de la palabra debe ser un número.");

                x = 0;
                if (Int32.TryParse(infoArray[1], out x))
                    diccionarioId = x;
                else
                    throw new Exception("El id del diccionario debe ser un número.");

                palabra = infoArray[2];
                significado= infoArray[3];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [PalabraId,DiccionarioId,Palabra,Significado]");
            }

        }
    }
}
