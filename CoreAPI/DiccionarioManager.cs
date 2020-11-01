using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class DiccionarioManager : BaseManager
    {
        private DiccionarioCrudFactory crudDiccionario;

        public DiccionarioManager()
        {
            crudDiccionario = new DiccionarioCrudFactory();
        }

        public void Create(Diccionario temp)
        {
            try
            {
                var c = crudDiccionario.Retrieve<Diccionario>(temp);

                if (c != null)
                {
                    //Diccionario already exist
                    throw new Exception("Error. Diccionario ya existe");
                }
                else 
                {
                    crudDiccionario.Create(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Diccionario> RetrieveAll()
        {
            return crudDiccionario.RetrieveAll<Diccionario>();
        }

        public Diccionario RetrieveByName(Diccionario temp)
        {
            Diccionario c = null;
            try
            {
                c = crudDiccionario.Retrieve<Diccionario>(temp);
                if (c == null)
                {
                    throw new Exception("Error. Diccionario no existe. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return c;
        }

    }
}



