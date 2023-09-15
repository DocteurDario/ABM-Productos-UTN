using dominio;
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
    public partial class CargarImagen : Form
    {
        private Articulo articulo = null;

        public CargarImagen()
        {
            InitializeComponent();
        }
        public CargarImagen( Articulo articulo)
        {
           InitializeComponent();
           this.articulo = articulo;
        }



        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
