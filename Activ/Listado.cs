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
    public partial class Listado : Form
    {
        private List<Articulo> listaArticulo;
        public Listado()
        {
            InitializeComponent();
        }
        private void Listado_Load_1(object sender, EventArgs e)
        {
            Negocio negocio = new Negocio();
            listaArticulo = negocio.listar();
            dgvLista.DataSource = listaArticulo;
            pbImagen.Load(listaArticulo[0].imagen.imagenUrl);
        }
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
            pbImagen.Load(seleccionado.imagen.imagenUrl);
        }      
    }
}
