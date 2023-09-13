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
        private Articulo articulo = null;
        public Agregar()
        {
            InitializeComponent();
        }
        public Agregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Articulo auxArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            Imagen img = new Imagen();
            ImagenNegocio negocioImagen = new ImagenNegocio();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                if(string.IsNullOrEmpty(textCodigo.Text) ||
                    string.IsNullOrEmpty(textNombre.Text) ||
                    string.IsNullOrEmpty(textDescripcion.Text) ||
                    string.IsNullOrEmpty(txtUrlImagen.Text) ||
                    string.IsNullOrEmpty(textPrecio.Text))
                {               
                    MessageBox.Show("Hay campos sin completar");
                    Close();
                }
                
                auxArticulo.codigo = textCodigo.Text;
                auxArticulo.nombre = textNombre.Text;
                auxArticulo.descripcion = textDescripcion.Text;
                auxArticulo.marca = (Marca)cBoxMarca.SelectedItem; 
                auxArticulo.categoria = (Categoria)cBoxCategoria.SelectedItem;
                auxArticulo.precio = decimal.Parse(textPrecio.Text);

                negocio.agregar(auxArticulo);               

                int idArticulo = negocio.UltimoRegistro();
                
                img.idArticulo = idArticulo;
                img.imagenUrl = txtUrlImagen.Text;

                negocioImagen.agregar(img);
               
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

                if(articulo != null)
                {
                    textCodigo.Text = articulo.codigo;
                    textNombre.Text = articulo.nombre;
                    textDescripcion.Text = articulo.descripcion;
                    txtUrlImagen.Text = articulo.imagen.imagenUrl;
                    textPrecio.Text = articulo.precio.ToString();
                    cargarImagen(articulo.imagen.imagenUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                PicBoxAdd.Load(imagen);
            }
            catch (Exception ex)
            {
                PicBoxAdd.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSogz_Eq26YoRE8mV0mmH4cP762p-zz6TidQg&usqp=CAU");
            }
        }
    }
}
