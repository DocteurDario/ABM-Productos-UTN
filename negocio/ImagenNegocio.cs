using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select Id, IdArticulo, ImagenUrl from IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                   Imagen aux = new Imagen();
                    aux.id = (int)datos.Lector["Id"];
                    aux.idArticulo = (int)datos.Lector["idArticulo"];
                    aux.imagenUrl = (string)datos.Lector["imagenUrl"];



                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }
        public void agregar(Imagen nuevo)
        {

            AccesoADatos dato = new AccesoADatos();

            try
            {
                dato.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl)values(" + nuevo.idArticulo + ", '" + nuevo.imagenUrl + "')");
                dato.ejecutarAcccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }


        }
    }
}
