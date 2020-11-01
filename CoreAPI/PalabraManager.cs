using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class PalabraManager : BaseManager
    {
        private PalabraCrudFactory crudPalabra;
        

        public PalabraManager()
        {
            crudPalabra = new PalabraCrudFactory();
            
        }

        public void Create(Palabra temp)
        {
            try
            {
                var c = crudPalabra.Retrieve<Palabra>(temp);

                if (c != null)
                {
                    //Palabra already exist
                    throw new Exception("Error. Palabra ya existe");
                }
                else
                {
                    crudPalabra.Create(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // todas las palabras del diccionario
        public List<Palabra> RetrieveAllID(Palabra palabra)
        {
            
            try
            {
                return crudPalabra.RetrieveAllID<Palabra>(palabra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        // busca palabra y diccionario
        public Palabra RetrieveByDic(Palabra palabra)
        {
            Palabra c = null;
            try 
            {
                c = crudPalabra.Retrieve<Palabra>(palabra);
                if (c == null) 
                {
                    throw new Exception("Error. Palabra no existe");
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }

    }
}
