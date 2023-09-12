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

              // datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, I.ImagenUrl, A.Precio from ARTICULOS A, IMAGENES I where I.IdArticulo = A.Id");
               datos.setearConsulta("SELECT A.Id,  A.Codigo, A.Nombre, A.Descripcion,M.Descripcion AS Marca, C.Descripcion as Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON I.Id = I.IdArticulo");

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
                    aux.marca = new Marca();
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                   // aux.categoria = new Categoria();
                   // aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    
                    


                   /* if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Categoria"))))
                        aux.categoria.descripcion = (string)datos.Lector["Categoria"];*/
                    aux.categoria = new Categoria();
                    /* if(!(datos.Lector["Categoria"] is DBNull))
                             aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    */
                    if (!Convert.IsDBNull(datos.Lector["Categoria"])) aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    else aux.categoria.descripcion = "";

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
                dato.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values('"+ nuevo.codigo +"', '"+ nuevo.nombre + "', '"+ nuevo.descripcion +"', @idMarca, @idCategoria,"+nuevo.precio+" )");
                dato.setearParametro("@idMarca", nuevo.marca.id);
                dato.setearParametro("@idCategoria", nuevo.categoria.id);
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
