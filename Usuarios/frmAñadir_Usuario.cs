using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Utilidades;
using FlowerShop.Modelos;

namespace FlowerShop.Usuarios
{
    public partial class frmAñadir_Usuario : Form
    {
        // Evento para notificar al padre que la operaciÃ³n se cancelÃ³ o completÃ³ con Ã©xito
        public event EventHandler OperacionCompletada;

        public frmAñadir_Usuario()
        {
            InitializeComponent();
            this.Load += frmAñadir_Usuario_Load;
        }

        private void frmAñadir_Usuario_Load(object sender, EventArgs e)
        {
            // Solo opciÃ³n Vendedor por el momento
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Vendedor");
            cmbRol.SelectedIndex = 0;
            
            // Aplicar bordes al formulario si es necesario y dar estilo a botones
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnGuardar, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnCancelar, 15);
            
            // Bordes a los textbox usando un helper si existe, si no, se deja nativo.
            // La configuraciÃ³n se harÃ¡ desde el designer.
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Avisar al formulario padre para que cierre el panel
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }

                private bool ValidarNombres()
        {
            bool okNombre = ValidationUtils.EsNombreValido(txtNombre.Text) && txtNombre.Text.Length >= 3 && txtNombre.Text.Length <= 50;
            bool okPat = ValidationUtils.EsNombreValido(txtApellidoPaterno.Text) && txtApellidoPaterno.Text.Length >= 3 && txtApellidoPaterno.Text.Length <= 50;
            bool okMat = string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) || (ValidationUtils.EsNombreValido(txtApellidoMaterno.Text) && txtApellidoMaterno.Text.Length >= 3 && txtApellidoMaterno.Text.Length <= 50);

            if (!okNombre) ValidationUtils.MostrarError(txtNombre, "3-50 letras y espacios."); else ValidationUtils.LimpiarError(txtNombre);
            if (!okPat) ValidationUtils.MostrarError(txtApellidoPaterno, "3-50 letras y espacios."); else ValidationUtils.LimpiarError(txtApellidoPaterno);
            if (!okMat) ValidationUtils.MostrarError(txtApellidoMaterno, "3-50 letras y espacios (opcional)."); else ValidationUtils.LimpiarError(txtApellidoMaterno);

            return okNombre && okPat && okMat;
        }

        private bool ValidarCorreo()
        {
            if (!ValidationUtils.EsEmailValido(txtCorreo.Text))
            {
                ValidationUtils.MostrarError(txtCorreo, "Correo inválido.");
                return false;
            }
            if (new FlowerShop.Modelos.UsuarioDAO().ExisteCorreo(txtCorreo.Text))
            {
                ValidationUtils.MostrarError(txtCorreo, "El correo ya está registrado.");
                return false;
            }
            ValidationUtils.LimpiarError(txtCorreo);
            return true;
        }

        private bool ValidarTelefono()
        {
            if (txtTelefono.Text.Length != 10)
            {
                ValidationUtils.MostrarError(txtTelefono, "Debe tener exactamente 10 dígitos.");
                return false;
            }
            ValidationUtils.LimpiarError(txtTelefono);
            return true;
        }

        private bool ValidarUsuario()
        {
            if (txtUsuario.Text.Length < 4 || txtUsuario.Text.Length > 20 || !ValidationUtils.EsUsuarioValido(txtUsuario.Text))
            {
                ValidationUtils.MostrarError(txtUsuario, "4-20 letras y números, sin espacios.");
                return false;
            }
            if (new FlowerShop.Modelos.UsuarioDAO().ExisteUsuario(txtUsuario.Text))
            {
                ValidationUtils.MostrarError(txtUsuario, "El usuario ya existe.");
                return false;
            }
            ValidationUtils.LimpiarError(txtUsuario);
            return true;
        }

        private bool ValidarPassword()
        {
            if (!ValidationUtils.EsPasswordSegura(txtContrasena.Text))
            {
                ValidationUtils.MostrarError(txtContrasena, "Mín 8 caracteres, 1 mayúscula, 1 número.");
                return false;
            }
            ValidationUtils.LimpiarError(txtContrasena);
            return true;
        }

        private void HookValidations()
        {
            txtNombre.Validating += (s, e) => ValidarNombres();
            txtApellidoPaterno.Validating += (s, e) => ValidarNombres();
            txtApellidoMaterno.Validating += (s, e) => ValidarNombres();
            txtCorreo.Validating += (s, e) => ValidarCorreo();
            txtTelefono.Validating += (s, e) => ValidarTelefono();
            txtUsuario.Validating += (s, e) => ValidarUsuario();
            txtContrasena.Validating += (s, e) => ValidarPassword();

            txtNombre.KeyPress += Letras_KeyPress;
            txtApellidoPaterno.KeyPress += Letras_KeyPress;
            txtApellidoMaterno.KeyPress += Letras_KeyPress;
            txtTelefono.KeyPress += Numeros_KeyPress;
            txtUsuario.KeyPress += Alfanumerico_KeyPress;
        }

        private void Letras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í' && e.KeyChar != 'ó' && e.KeyChar != 'ú') e.Handled = true;
        }

        private void Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void Alfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos vacÃ­os
            if (!ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarUsuario() || !ValidarPassword() || cmbRol.SelectedItem == null) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


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
                MessageBox.Show("Empleado guardado con Ã©xito.", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OperacionCompletada?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("OcurriÃ³ un error al intentar guardar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}





