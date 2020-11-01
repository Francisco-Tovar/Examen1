using System;

namespace Entities_POJO
{
    public class Traduccion : BaseEntity
    {
        public int traduccionId { get; set; }
        public int palabraId { get; set; }
        public int usuarioId { get; set; }
        public int diccionarioId { get; set; }
        public DateTime fecha { get; set; }
     
        public Traduccion() { }

        public Traduccion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                var x = 0;
                if (Int32.TryParse(infoArray[0], out x))
                    traduccionId = x;
                else
                    throw new Exception("El id de la traduccion debe ser un número.");

                x = 0;
                if (Int32.TryParse(infoArray[1], out x))
                    palabraId = x;
                else
                    throw new Exception("El id de la palabra debe ser un número.");
                x = 0;
                if (Int32.TryParse(infoArray[2], out x))
                    usuarioId = x;
                else
                    throw new Exception("El id del usuario debe ser un número.");

                x = 0;
                if (Int32.TryParse(infoArray[3], out x))
                    diccionarioId = x;
                else
                    throw new Exception("El id del diccionario debe ser un número.");

                var bate = DateTime.Now;
                if (DateTime.TryParse(infoArray[4], out bate))
                    fecha = bate;
                else
                    throw new Exception("Fecha no válida.");
            }
            else
            {
                throw new Exception("Se requieren todos los datos [TraduccionId,PalabraId,UsuarioId,DiccionarioId,Fecha]");
            }

        }
    }
}

