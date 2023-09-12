using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Activ
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Articulo auxArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            Imagen auxImagen = new Imagen();
            ImagenNegocio negocioImagen = new ImagenNegocio();

            try
            {
          
                auxArticulo.codigo = textCodigo.Text;
                auxArticulo.nombre = textNombre.Text;
                auxArticulo.descripcion = textDescripcion.Text;
                auxArticulo.marca = (Marca)cBoxMarca.SelectedItem; 
                auxArticulo.categoria = (Categoria)cBoxCategoria.SelectedItem;
                auxArticulo.precio = decimal.Parse(textPrecio.Text);

                

                //int idArticulo = negocio.UltimoRegistro().
                // entra a la base de datos y obtiene su ID


                // Configura los datos de la imagen y vincúlala al artículo
                int aux1= negocio.UltimoRegistro();
                MessageBox.Show(" Tiene  " + aux1 );
                auxImagen.idArticulo = negocio.UltimoRegistro()+1; // Vincula la imagen al artículo usando su ID
                auxImagen.imagenUrl = textUrl.Text;

                //Agrega la imagen a la base de datos
                negocio.agregar(auxArticulo);
                negocioImagen.agregar(auxImagen);


                
                MessageBox.Show("Agregado Exitosamente...");
                Close();   
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Error : "+ ex.ToString());
            }

        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cBoxMarca.DataSource = marcaNegocio.listar();
                cBoxCategoria.DataSource = categoriaNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
