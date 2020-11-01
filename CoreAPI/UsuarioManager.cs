using DataAcess.Crud;
using Entities_POJO;
using System;

namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Usuario user)
        {
            try
            {
                var c = crudUsuario.Retrieve<Usuario>(user);

                if (c != null)
                {
                    //Usuario already exist
                    throw new Exception("Error. Usuario ya existe");
                }
                else 
                {
                    crudUsuario.Create(user);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Usuario RetrieveById(Usuario user)
        {
            Usuario c = null;
            try
            {
                c = crudUsuario.Retrieve<Usuario>(user);
                if (c == null)
                {
                    throw new Exception("Error. Usuario no existe. ");
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


