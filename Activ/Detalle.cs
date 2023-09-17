using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activ
{
    public partial class Detalle : Form
    {
        private Articulo articulo = null;
        private List<Imagen> imagenes;
        private int posicion = 0;

        public Detalle()
        {
            InitializeComponent();
        }
        public Detalle(Articulo articulo, List<Imagen> artImg)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.imagenes = artImg;
        }

        private void Detalle_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {

                cBoxMarca.DataSource = marcaNegocio.listar();
                cBoxMarca.ValueMember = "Id";
                cBoxMarca.DisplayMember = "Descripcion";
                cBoxCategoria.DataSource = categoriaNegocio.listar();
                cBoxCategoria.ValueMember = "Id";
                cBoxCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    // Carga los datos del artículo en los controles de la interfaz de usuario
                    textCodigo.Text = articulo.codigo;
                    textNombre.Text = articulo.nombre;
                    textDescripcion.Text = articulo.descripcion;
                    txtUrlImagen.Text = articulo.imagen.imagenUrl;
                    textPrecio.Text = articulo.precio.ToString();
                    cBoxMarca.SelectedValue = articulo.marca.id;
                    cBoxCategoria.SelectedValue = articulo.categoria.id;
                }

                // Cargar la primera imagen (si hay alguna)
                if (imagenes.Count > 0)
                {
                    cargarImagen(imagenes[0].imagenUrl);
                }
                BloquearControles();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Imagen_Click(object sender, EventArgs e)
        {
            // Verificar si hay más imágenes para mostrar
            if (posicion < imagenes.Count - 1)
            {
                posicion++;
                string url = imagenes[posicion].imagenUrl;
                cargarImagen(url);
            }
            else
            {
                MessageBox.Show("No hay más imágenes disponibles.");
            }
        }
        private void BloquearControles()
        {
            // Deshabilitar todos los controles 
            textCodigo.Enabled = false;
            textNombre.Enabled = false;
            textDescripcion.Enabled = false;
            txtUrlImagen.Enabled = false;
            textPrecio.Enabled = false;
            cBoxMarca.Enabled = false;
            cBoxCategoria.Enabled = false;
            pbImagen.Enabled = false;

        }
    }
}
