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
                //auxArticulo.marca = (Marca)cBoxMarca.SelectedItem; 
                //auxArticulo.categoria = (Categoria)cBoxCategoria.SelectedItem;
                //auxArticulo.imagen = (Imagen)textUrl.Tag; // vamos a ver que hace Tag....
                //decimal precio;

                negocio.agregar(auxArticulo);
                MessageBox.Show("Agregado Exitosamente...");
                Close();   
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Error : "+ ex.ToString());
            }

        }
    }
}
