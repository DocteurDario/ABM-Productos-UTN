using System;
using System.CodeDom;
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
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion,I.Id, I.ImagenUrl, M.Descripcion as Marca, C.Descripcion as Categoria, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.imagen = new Imagen();
                    aux.imagen.id = (int)datos.Lector["Id"];
                    aux.imagen.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    if(!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Categoria")))
                    {
                        aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.categoria.descripcion = "";
                    }
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }             
                return lista;
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
        public void agregar(Articulo nuevo)
        {            
            AccesoADatos dato = new AccesoADatos();
            try
            {
                dato.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values('"+ nuevo.codigo +"', '"+ nuevo.nombre + "', '"+ nuevo.descripcion +"', @idMarca, @idCategoria,'"+nuevo.precio+"')");
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
        public int UltimoRegistro()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("select A.Id from ARTICULOS A");
                datos.ejecutarLectura();
                int auxIdArticulo = new int();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    auxIdArticulo = (int)datos.Lector["Id"];
                }
                return auxIdArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Articulo articulo)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @marca, IdCategoria = @categoria, Precio = @precio where Id =@id");
                datos.setearParametro("@codigo", articulo.codigo);
                datos.setearParametro("@nombre", articulo.nombre);
                datos.setearParametro("@descripcion", articulo.descripcion);
                datos.setearParametro("@marca", articulo.marca.id);
                datos.setearParametro("@categoria", articulo.categoria.id);
                datos.setearParametro("@precio", articulo.precio);
                datos.setearParametro("@id", articulo.id);
                datos.ejecutarAcccion();         
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
    }
}
