﻿
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Activ
{
    public partial class Listado : Form
    {
        private List<Articulo> listaArticulo;
        
        public Listado()
        {
            InitializeComponent();
        }
        private void Listado_Load_1(object sender, EventArgs e)
        {
            cargarListaDataGriedView();
            if (listaArticulo.Count > 0)
            {
                cargarImagen(listaArticulo[0].imagen.imagenUrl);
            }
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
        }
        private void cargarListaDataGriedView()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dgvLista.DataSource = listaArticulo;
                ocultarColumnas();
                dgvLista.Focus();
                pbImagen.Load(listaArticulo[0].imagen.imagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.imagen.imagenUrl);
            }
        }       
        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvLista.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem; // devuelve un obj, se casteo
                cargarImagen(seleccionado.imagen.imagenUrl);
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
                pbImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSogz_Eq26YoRE8mV0mmH4cP762p-zz6TidQg&usqp=CAU");
            }
        }       
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar alta = new Agregar();
            alta.ShowDialog();
            cargarListaDataGriedView();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                Agregar modificar = new Agregar(seleccionado);
                modificar.ShowDialog();
                cargarListaDataGriedView();
            }
            else
            {
                MessageBox.Show("No se puede modificar un articulo si la lista esta vacia");
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ArticuloNegocio nego = new ArticuloNegocio();
            ImagenNegocio imgNegocio = new ImagenNegocio();
                    
            try
            {
                if (dgvLista.Rows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar este articulo?..", "Eliminar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                    if (respuesta == DialogResult.Yes)
                    {
                        Articulo articulo = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                        nego.Eliminar(articulo.id);
                        imgNegocio.Eliminar(articulo.id);
                        cargarListaDataGriedView();
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar un articulo si la lista esta vacia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = textBoxBuscar.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper())
               || x.descripcion.ToUpper().Contains(filtro.ToUpper())
               || x.codigo.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvLista.DataSource = null;
            dgvLista.DataSource = listaFiltrada;
            ocultarColumnas();
        }
        private bool validarFiltro()
        {
            if(cboCampo.SelectedIndex <0)
            {
                MessageBox.Show("Seleccione el campo para filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el campo para filtrar");
                return true;
            }
            if (cboCampo.SelectedIndex.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    MessageBox.Show("cargar numero");
                    return true;
                }
                if (!(soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("El filtro elegido requiere números");
                    return true;
                }               
            }
            return false;
        }
        private bool soloNumeros(string cadena)
        {
            foreach(char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio nego = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dgvLista.DataSource = nego.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void  ocultarColumnas()
        {
            dgvLista.Columns["imagen"].Visible = false;
            dgvLista.Columns["id"].Visible = false;
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else if (opcion == "Nombre")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            else if (opcion == "Descripcion")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

       
        private void btDetalle_Click(object sender, EventArgs e)
        {
            if(dgvLista.Rows.Count > 0)
            {
                Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                ImagenNegocio datoImg = new ImagenNegocio();
                List<Imagen> imgArt = datoImg.listarImagenes(seleccionado.id);
                Detalle detalle = new Detalle(seleccionado, imgArt);
                detalle.ShowDialog();
                cargarListaDataGriedView();
            }
            else
            {
                MessageBox.Show("No se puede mostrar los detalle si la lista esta vacia");
            }          
        }

        private void DatosGrid()
        {


        }
    }
}