using System;

namespace Entities_POJO
{
    public class Log : BaseEntity
    {
        public int logId { get; set; }
        public int usuarioId { get; set; }
        public int diccionarioId { get; set; }
        public DateTime fecha { get; set; }
        public string frase { get; set; }
        public string traduccion { get; set; }
        public int popularidad { get; set; }

        public Log() { }

        public Log(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                var x = 0;
                if (Int32.TryParse(infoArray[0], out x))
                    logId = x;
                else
                    throw new Exception("El id del log debe ser un número.");
                                
                x = 0;
                if (Int32.TryParse(infoArray[1], out x))
                    usuarioId = x;
                else
                    throw new Exception("El id del usuario debe ser un número.");

                x = 0;
                if (Int32.TryParse(infoArray[2], out x))
                    diccionarioId = x;
                else
                    throw new Exception("El id del diccionario debe ser un número.");

                var bate = DateTime.Now;
                if (DateTime.TryParse(infoArray[3], out bate))
                    fecha = bate;
                else
                    throw new Exception("Fecha no válida.");

                frase = infoArray[4];
                traduccion = infoArray[5];

                x = 0;
                if (Int32.TryParse(infoArray[6], out x))
                    popularidad = x;
                else
                    throw new Exception("El conteo de popularidad debe ser un número.");


            }
            else
            {
                throw new Exception("Se requieren todos los datos [logId, usuarioId, diccionarioId, fecha, frase, traduccion, popularidad]");
            }

        }
    }
}


