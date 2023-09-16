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

        private Imagen imagen = null;
        public CargarImagen()
        {
            InitializeComponent();
        }
        public CargarImagen(Imagen imagen)
        {
            InitializeComponent();
            this.imagen = imagen;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
