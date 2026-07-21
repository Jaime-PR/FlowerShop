using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop
{
    public partial class frmMenu : Form
    {
           
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     
            int nTopRect,      
            int nRightRect,    
            int nBottomRect,   
            int nWidthEllipse,  
            int nHeightEllipse 
        );
        public frmMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));
        }
        private void frmMenu_Deactivate(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas cerrar la sesión actual?", 
                "Cerrar Sesión",                                        
                MessageBoxButtons.YesNo,                                
                MessageBoxIcon.Question                                 
            );

            
            if (confirmacion == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
