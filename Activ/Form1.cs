using System;
using System.Windows.Forms;
using dominio;

namespace Activ
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsbtBuscar_Click(object sender, EventArgs e)
        {
            foreach(var item in Application.OpenForms)
            {
                if(item.GetType()== typeof(Agregar))
                {
                    return;
                }
            }

            Agregar ventana = new Agregar();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void tsbtListar_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Listado))
                {
                    return;
                }
            }

            Listado ventana = new Listado();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void AgregarArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Agregar))
                {
                    return;
                }
            }

            Agregar ventana = new Agregar();
            ventana.MdiParent = this;
            ventana.Show();

        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Listado))
                {
                    return;
                }
            }

            Listado ventana = new Listado();
            ventana.MdiParent = this;
            ventana.Show();
        }
    }
}
