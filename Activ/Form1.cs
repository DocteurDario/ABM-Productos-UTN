﻿using System;
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
                if(item.GetType()== typeof(Buscar))
                {
                    return;
                }
            }

            Buscar ventana = new Buscar();
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
    }
}
