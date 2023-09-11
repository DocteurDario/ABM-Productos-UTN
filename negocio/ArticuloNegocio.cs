using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, I.ImagenUrl, A.Precio from ARTICULOS A, IMAGENES I where I.IdArticulo = A.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.imagen = new Imagen();
                    aux.imagen.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar( Articulo nuevo)
        {
            AccesoADatos dato = new AccesoADatos();

            try
            {
                dato.setearConsulta("insert into ARTICULOS values (Codigo, Nombre, Descripcuion)Values('"+ nuevo.codigo +"', '"+ nuevo.nombre + "', '"+ nuevo.descripcion +"')");
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
