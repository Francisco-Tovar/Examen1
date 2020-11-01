using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class TraduccionManager : BaseManager
    {
        private TraduccionCrudFactory crudTraduccion;
        
        public TraduccionManager()
        {
            crudTraduccion = new TraduccionCrudFactory();
            
        }

        public void Create(Traduccion temp)
        {
            try
            {
                crudTraduccion.Create(temp);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // todas las traduccions por palabraid
        public List<Traduccion> RetrieveAllID(Traduccion traduccion)
        {

            try
            {
                return crudTraduccion.RetrieveAllID<Traduccion>(traduccion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
       
    }
}
