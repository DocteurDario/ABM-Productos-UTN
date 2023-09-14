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
        }
        private void cargarListaDataGriedView()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dgvLista.DataSource = listaArticulo;
                dgvLista.Columns["imagen"].Visible = false;
                //dgvLista.Columns["id"].Visible = false;
                pbImagen.Load(listaArticulo[0].imagen.imagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.imagen.imagenUrl);
        }
        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem; // devuelve un obj, se casteo
            cargarImagen(seleccionado.imagen.imagenUrl);
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
            Articulo seleccionado;
            seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
            Agregar modificar = new Agregar(seleccionado);
            modificar.ShowDialog();
            cargarListaDataGriedView();
        }
    }
}