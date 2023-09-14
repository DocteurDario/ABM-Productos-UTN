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
            Text = "Modificar";
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Imagen img = new Imagen();
            ImagenNegocio negocioImagen = new ImagenNegocio();           

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
                if (articulo == null)
                {
                    articulo = new Articulo();
                    articulo.codigo = textCodigo.Text;
                    articulo.nombre = textNombre.Text;
                    articulo.descripcion = textDescripcion.Text;                   
                    articulo.marca = (Marca)cBoxMarca.SelectedItem;
                    articulo.categoria = (Categoria)cBoxCategoria.SelectedItem;
                    articulo.precio = decimal.Parse(textPrecio.Text);

                    if (articulo.id != 0)
                    {
                        negocio.Modificar(articulo);
                        img.id = articulo.imagen.id;
                        img.idArticulo = articulo.id;
                        img.imagenUrl = txtUrlImagen.Text;
                        negocioImagen.Modificar(img);
                        MessageBox.Show("Modificado Exitosamente...");
                    }
                    else
                    {
                        negocio.agregar(articulo);
                        int idArticulo = negocio.UltimoRegistro();               
                        img.idArticulo = idArticulo;
                        img.imagenUrl = txtUrlImagen.Text;
                        negocioImagen.agregar(img);              
                        MessageBox.Show("Agregado Exitosamente...");
                    }
                }
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
                cBoxMarca.ValueMember = "Id";
                cBoxMarca.DisplayMember = "Descripcion";
                cBoxCategoria.DataSource = categoriaNegocio.listar();
                cBoxCategoria.ValueMember = "Id";
                cBoxCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    textCodigo.Text = articulo.codigo;
                    textNombre.Text = articulo.nombre;
                    textDescripcion.Text = articulo.descripcion;
                    txtUrlImagen.Text = articulo.imagen.imagenUrl;
                    textPrecio.Text = articulo.precio.ToString();
                    cargarImagen(articulo.imagen.imagenUrl);
                    cBoxMarca.SelectedValue = articulo.marca.id;
                    cBoxCategoria.SelectedValue = articulo.categoria.id;
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
