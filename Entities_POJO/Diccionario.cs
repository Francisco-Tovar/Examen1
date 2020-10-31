using System;

namespace Entities_POJO
{
    class Diccionario : BaseEntity
    {
        public int diccionarioId { get; set; }
        public string nombre { get; set; }

        public Diccionario() { }

        public Diccionario(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                var x = 0;
                if (Int32.TryParse(infoArray[0], out x))
                    diccionarioId = x;
                else
                    throw new Exception("El id del diccionario debe ser un número.");
                
                nombre = infoArray[1];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [DiccionarioId,nombre]");
            }

        }

    }
}
