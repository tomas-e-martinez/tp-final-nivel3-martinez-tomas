using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
	public class UsuarioNegocio
	{
		public bool Loguear(Usuario user)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearQuery("SELECT id, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
				datos.setearParametro("@email", user.Email);
				datos.setearParametro("@pass", user.Pass);

				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					user.Id = (int)datos.Lector["id"];
					user.Admin = (bool)datos.Lector["admin"];
					user.UrlImagenPerfil = datos.Lector["urlImagenPerfil"].ToString();
					user.Nombre = datos.Lector["nombre"].ToString();
					user.Apellido = datos.Lector["apellido"].ToString();
                    return true;
				}
				return false;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
            }
		}

		public bool EmailDisponible(string email)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearQuery("SELECT id from USERS where email = @email");
				datos.setearParametro("@email", email);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
					return false;
				else
					return true;

            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

        public int Registrar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearQuery("INSERT INTO USERS (email, pass, nombre, apellido, admin) OUTPUT inserted.Id VALUES (@email, @pass, @nombre, @apellido, 0)");
				datos.setearParametro("@email", user.Email);
				datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
				return datos.ejecutarScalar();
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
