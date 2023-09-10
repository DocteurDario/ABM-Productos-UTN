using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class Negocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            
            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, I.ImagenUrl, A.Precio from ARTICULOS A, IMAGENES I where I.IdArticulo = A.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["Id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descripcion = (string)lector["Descripcion"];
                    aux.imagen = new Imagen();
                    aux.imagen.imagenUrl = (string)lector["ImagenUrl"];
                    aux.precio = (decimal)lector["Precio"];
                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
    

