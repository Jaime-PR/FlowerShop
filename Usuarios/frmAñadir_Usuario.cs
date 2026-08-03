using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Modelos;

namespace FlowerShop.Usuarios
{
    public partial class frmAñadir_Usuario : Form
    {
        // Evento para notificar al padre que la operación se canceló o completó con éxito
        public event EventHandler OperacionCompletada;

        public frmAñadir_Usuario()
        {
            InitializeComponent();
            this.Load += FrmAñadir_Usuario_Load;
        }

        private void FrmAñadir_Usuario_Load(object sender, EventArgs e)
        {
            // Solo opción Vendedor por el momento
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Vendedor");
            cmbRol.SelectedIndex = 0;
            
            // Aplicar bordes al formulario si es necesario y dar estilo a botones
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnGuardar, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnCancelar, 15);
            
            // Bordes a los textbox usando un helper si existe, si no, se deja nativo.
            // La configuración se hará desde el designer.
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Avisar al formulario padre para que cierre el panel
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDAO dao = new UsuarioDAO();
            bool exito = dao.InsertarUsuario(
                txtNombre.Text.Trim(),
                txtApellidoPaterno.Text.Trim(),
                txtApellidoMaterno.Text.Trim(),
                txtCorreo.Text.Trim(),
                txtTelefono.Text.Trim(),
                cmbRol.SelectedItem.ToString(),
                txtUsuario.Text.Trim(),
                txtContrasena.Text
            );

            if (exito)
            {
                MessageBox.Show("Empleado guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OperacionCompletada?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
