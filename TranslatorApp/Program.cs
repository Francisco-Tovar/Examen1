using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI;
using Entities_POJO;

namespace TranslatorApp
{
    class Program
    {
        public static UsuarioManager userMng = new UsuarioManager();
        public static DiccionarioManager dicMng = new DiccionarioManager();
        public static PalabraManager palaMng = new PalabraManager();
        public static TraduccionManager traducMng = new TraduccionManager();
        public static LogManager logMng = new LogManager();

        public static Usuario tUser = new Usuario();
        public static Diccionario tDic = new Diccionario();
        public static bool logedIn;

        static void Main(string[] args)
        {
            logedIn = false;
            login();
            if (logedIn) 
            {
                selectIdioma();
                iterar();
            }
        }

        public static void login()
        {
            string leer = "";
            int opcion = 0;
            do
            {
                opcion = 0;
                Console.Clear();
                Console.WriteLine("   ------------------ ");
                Console.WriteLine("   - Translator Bot - ");
                Console.WriteLine("   ------------------ ");
                Console.WriteLine("   1 - Iniciar sesión ");
                Console.WriteLine("   2 - Crear usuario  ");
                Console.WriteLine("   3 - Ver registros  ");
                Console.WriteLine("   -------------------");
                Console.WriteLine("   100 - SALIR");
                Console.Write("   Opcion: ");
                leer = Console.ReadLine();

                if (int.TryParse(leer, out opcion))
                    opcion = int.Parse(leer);
                else
                    opcion = -1;
                switch (opcion)
                {
                    case 1:
                        {
                            Console.Write(" Por favor ingrese su usuario: ");
                            var user = Console.ReadLine();
                            tUser = new Usuario();
                            tUser.usuarioId = user;
                            tUser = userMng.RetrieveById(tUser);
                            if (tUser == null)
                            {
                                Console.WriteLine(" Usuario inválido.");
                                Console.ReadKey();
                            }
                            else 
                            {
                                Console.Clear();
                                Console.WriteLine(" Bienvenido "+tUser.nombre+"!");
                                Console.ReadKey();
                                logedIn = true;
                                opcion = 100;
                            }
                            break;
                        }
                    case 2: 
                        {
                            Console.WriteLine(" Ingrese su usuario deseado: ");
                            var user = Console.ReadLine();
                            Console.WriteLine(" Ingrese su nombre: ");
                            var name = Console.ReadLine();
                            tUser = new Usuario();
                            tUser.nombre = name;
                            tUser.usuarioId = user;
                            userMng.Create(tUser);
                            Console.WriteLine(" Por favor inicie sesión con estos credenciales:");
                            Console.WriteLine(" Usuario creado: Nombre - "+tUser.nombre+", ID - "+tUser.usuarioId);
                            tUser = new Usuario();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            listarLogs();
                            break;
                        }
                    case 100:
                        {
                            Console.WriteLine(" - Gracias por usar Translator Bot.");
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine(" - Opción inválida, intente de nuevo.");
                            Console.ReadKey();
                            break;
                        }
                }
            }
            while (opcion != 100);
        }

        public static void selectIdioma()
        {
            tDic = new Diccionario();
            Console.Write("A que idioma desea traducir?: ");
            var idioma = Console.ReadLine();
            tDic.nombre = idioma;            
            tDic = dicMng.RetrieveByName(tDic);

            if (tDic == null)
            {
                Console.Write("Ese idioma no existe, desea crearlo? (s/n): ");
                var opcion = "";
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("s")) 
                {
                    tDic = new Diccionario();
                    tDic.nombre = idioma.ToLower();                    
                    dicMng.Create(tDic);
                    Console.WriteLine(idioma+" ha sido agregado.");
                    Console.ReadKey();
                    tDic = dicMng.RetrieveByName(tDic);
                    Console.WriteLine("El idioma seleccionado es: " + tDic.nombre);
                    Console.ReadKey();
                } else 
                {
                    selectIdioma();
                }
            }
            else 
            {
                Console.WriteLine("El idioma seleccionado es: "+tDic.nombre);
                Console.ReadKey();
            
            }
        
        }

        public static void capturar()
        {
            Console.Write("Que frase desea traducir al " + tDic.nombre + "?: ");
            var frase = Console.ReadLine().ToLower();
            string traduccion = "";
            string[] infoArray = frase.Split(' ');
            foreach (var palabra in infoArray)
            {                
                traduccion = traduccion +" "+ traducir(palabra);               
            }
            Console.WriteLine("Frase en español: " +frase);
            Console.WriteLine("Frase en " + tDic.nombre+": "+traduccion);
            registrarLog(frase, traduccion);
            Console.ReadKey();
        }

        public static string traducir(string palabra)
        {
            string frase = "";
            Palabra temp = new Palabra();
            temp.palabra = palabra;
            temp.diccionarioId = tDic.diccionarioId;
            temp = palaMng.RetrieveByDic(temp);
            if (temp == null)
            {
                Console.Clear();
                Console.WriteLine("La palabra " + palabra + " no existe en el diccionario " + tDic.nombre);
                Console.WriteLine("Conoce el significado para agregarla? (s/n)");
                var opcion = "";
                opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("s"))
                {
                    Console.WriteLine("Cual es el significado de " + palabra + " en " + tDic.nombre + " ?: ");
                    temp = new Palabra();
                    temp.significado = Console.ReadLine();
                    temp.diccionarioId = tDic.diccionarioId;
                    temp.palabra = palabra;
                    palaMng.Create(temp);
                    frase = temp.significado;
                    
                    Console.WriteLine("El significado de " + palabra + " en " + tDic.nombre + " es "+temp.significado);
                    Console.ReadKey();
                }
                else
                {
                    frase = "???";
                }
            }
            else 
            {
                frase = temp.significado;
            }
            registrarTraduccion(temp,tUser,tDic);
            return frase;
        }

        public static void iterar()
        {
            bool token = false;
            do 
            {
                Console.Clear();
                capturar();

                Console.WriteLine("Desea traducir otra frase al "+tDic.nombre+"? (s/n): ");
                var respuesta = Console.ReadLine().ToLower();
                if (!respuesta.Equals("s")) 
                {
                    token = true;
                    Console.WriteLine("Muchas gracias por utilizar Translator Bot!");
                    Console.ReadKey();
                }
            } 
            while (token == false);
        }

        public static void registrarTraduccion(Palabra palabra, Usuario user, Diccionario dicc)
        {
            Traduccion tTraduc = new Traduccion();
            tTraduc.palabraId = palabra.palabraId;
            tTraduc.diccionarioId = dicc.diccionarioId;
            tTraduc.usuarioId = user.usuarioId;            
            tTraduc.fecha = DateTime.Now;
            traducMng.Create(tTraduc);                    
        }

        public static int calcularPopularidad(string frase)
        {
            int popularidad = 0;
            List<Traduccion> traducArray = new List<Traduccion>();
            string[] infoArray = frase.Split(' ');
            foreach (var palabra in infoArray)
            {
                Palabra temp = new Palabra();
                temp.palabra = palabra;
                temp.diccionarioId = tDic.diccionarioId;
                temp = palaMng.RetrieveByDic(temp);
                Traduccion tempT = new Traduccion();
                tempT.palabraId = temp.palabraId;
                traducArray = traducMng.RetrieveAllID(tempT);
                if (traducArray != null) 
                {
                    popularidad += traducArray.Count;
                }
                
            }

            return popularidad;
        }

        public static void registrarLog(string frase, string traduccion)
        {
            Log log = new Log();
            log.usuarioId = tUser.usuarioId;
            log.diccionarioId = tDic.diccionarioId;
            log.fecha = DateTime.Now;
            log.frase = frase;
            log.traduccion = traduccion;
            log.popularidad = calcularPopularidad(frase);

            logMng.Create(log);
        
        }

        public static void listarLogs()
        {
            List <Log> lista = new List<Log>();
            lista = logMng.RetrieveAll();
            Console.Clear();
            string linea = string.Format("{0,-15}{1,-8}{2,-15}{3,-30}{4,-30}{5,-5} \n",
                "Usuario" , "Idioma" , "Fecha" , "Frase", "Traduccion", "Popularidad");
            Console.WriteLine(linea);
            foreach (Log item in lista)
            {
                Usuario user = new Usuario();
                user.usuarioId = item.usuarioId;
                user = userMng.RetrieveById(user);

                linea = string.Format("{0,-15}{1,-8}{2,-15}{3,-30}{4,-30}{5,-5} \n", 
                    user.nombre , item.diccionarioId , item.fecha.ToString("MM/dd/yyyy"), item.frase , 
                                  item.traduccion , item.popularidad);
                Console.WriteLine(linea);
            }
            Console.ReadKey();
        
        }

    }
}
