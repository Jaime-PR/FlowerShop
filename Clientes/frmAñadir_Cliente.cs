using System;
using System.Drawing;
using System.Windows.Forms;
using FlowerShop.Utilidades;
using FlowerShop.Modelos;

namespace FlowerShop.Clientes
{
    public partial class frmAñadir_Cliente : Form
    {
        public event EventHandler OperacionCompletada;
        private int _idClienteEdicion = 0;

        public frmAñadir_Cliente()
        {
            InitializeComponent();
        }

        public frmAñadir_Cliente(int idCliente)
        {
            InitializeComponent();
            _idClienteEdicion = idCliente;
        }

        private void frmAñadir_Cliente_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            var origenes = dao.ObtenerOrigenes();
            cmbOrigen.Items.Clear();
            foreach (var origen in origenes)
            {
                cmbOrigen.Items.Add(origen);
            }
            if (cmbOrigen.Items.Count > 0)
            {
                cmbOrigen.SelectedIndex = 0;
            }

            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnGuardar, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnCancelar, 15);

            HookValidations();

            if (_idClienteEdicion > 0)
            {
                lblTitulo.Text = "Actualizar cliente";
                btnGuardar.Text = "Actualizar cliente";
                CargarDatosEdicion();
            }
        }

        private void CargarDatosEdicion()
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                System.Data.DataRow row = dao.ObtenerClientePorId(_idClienteEdicion);
                if (row != null)
                {
                    txtNombre.Text = row["Nombre"].ToString();
                    txtApellidoPaterno.Text = row["Apellido_Paterno"].ToString();
                    txtApellidoMaterno.Text = row["Apellido_Materno"].ToString();
                    txtTelefono.Text = row["Telefono"].ToString();
                    txtDireccion.Text = row["Direccion"].ToString();
                    txtCorreo.Text = row["Correo"].ToString();
                    
                    string origen = row["Origen"].ToString();
                    if (cmbOrigen.Items.Contains(origen))
                        cmbOrigen.SelectedItem = origen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool ValidarDireccion()
        {
            string dir = txtDireccion.Text.Trim();
            if (!string.IsNullOrEmpty(dir) && (dir.Length < 10 || dir.Length > 200))
            {
                ValidationUtils.MostrarError(txtDireccion, "Si se llena, 10-200 caracteres.");
                return false;
            }
            ValidationUtils.LimpiarError(txtDireccion);
            return true;
        }

        private void HookValidations()
        {
            txtNombre.Validating += (s, e) => ValidarNombres();
            txtApellidoPaterno.Validating += (s, e) => ValidarNombres();
            txtApellidoMaterno.Validating += (s, e) => ValidarNombres();
            txtCorreo.Validating += (s, e) => ValidarCorreo();
            txtTelefono.Validating += (s, e) => ValidarTelefono();
            txtDireccion.Validating += (s, e) => ValidarDireccion();

            txtNombre.KeyPress += Letras_KeyPress;
            txtApellidoPaterno.KeyPress += Letras_KeyPress;
            txtApellidoMaterno.KeyPress += Letras_KeyPress;
            txtTelefono.KeyPress += Numeros_KeyPress;
        }

        private void Letras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í' && e.KeyChar != 'ó' && e.KeyChar != 'ú') e.Handled = true;
        }

        private void Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarDireccion()) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                ClienteDAO dao = new ClienteDAO();
                if (_idClienteEdicion > 0)
                {
                    dao.ActualizarCliente(
                        _idClienteEdicion,
                        txtNombre.Text.Trim(),
                        txtApellidoPaterno.Text.Trim(),
                        txtApellidoMaterno.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        cmbOrigen.SelectedItem?.ToString(),
                        txtDireccion.Text.Trim(),
                        txtCorreo.Text.Trim());
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.InsertarCliente(
                        txtNombre.Text.Trim(),
                        txtApellidoPaterno.Text.Trim(),
                        txtApellidoMaterno.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        cmbOrigen.SelectedItem?.ToString(),
                        txtDireccion.Text.Trim(),
                        txtCorreo.Text.Trim());
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                OperacionCompletada?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }
    }
}




