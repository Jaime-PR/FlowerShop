using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop.Login
{
    public partial class frmCrear_Cuenta : Form
    {
        public frmCrear_Cuenta()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lklblIniciarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInicio_Sesion inicioSesionForm = new frmInicio_Sesion();
            inicioSesionForm.Show();
            this.Hide();
        }
    }
}


