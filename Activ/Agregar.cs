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
            try
            {
                auxArticulo.codigo = textCodigo.Text;
                auxArticulo.nombre = textNombre.Text;
                auxArticulo.descripcion = textDescripcion.Text;
                auxArticulo.marca = (Marca)cBoxMarca.SelectedItem; 
                auxArticulo.categoria = (Categoria)cBoxCategoria.SelectedItem;
                //auxArticulo.imagen = (Imagen)textUrl.Text; // vamos a ver que hace Tag....
                auxArticulo.precio = decimal.Parse(textPrecio.Text);

                negocio.agregar(auxArticulo);
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
