using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {

        public bool favoritoExiste(int idArticulo, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("SELECT id from FAVORITOS where idUser = @idUser and idArticulo = @idArticulo");
                datos.setearParametro("@idUser", idUser);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return true;
                else
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
        public bool agregarFavorito(int idArticulo, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (favoritoExiste(idArticulo, idUser))
                    return false;

                datos.setearQuery("insert into FAVORITOS (IdUser, IdArticulo) values (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", idUser);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
