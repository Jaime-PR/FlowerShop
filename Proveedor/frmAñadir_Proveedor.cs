using System;
using System.Drawing;
using System.Windows.Forms;
using FlowerShop.Utilidades;
using FlowerShop.Modelos;

namespace FlowerShop.Proveedor
{
    public partial class frmAñadir_Proveedor : Form
    {
        public event EventHandler OperacionCompletada;
        private ProveedorDAO dao = new ProveedorDAO();
        private int _idProveedorEdicion = 0;

        public frmAñadir_Proveedor()
        {
            InitializeComponent();
        }

        public frmAñadir_Proveedor(int idProveedor)
        {
            InitializeComponent();
            _idProveedorEdicion = idProveedor;
        }

        private void frmAñadir_Proveedor_Load(object sender, EventArgs e)
        {
            var categorias = dao.ObtenerCategorias();
            if (categorias != null)
            {
                cmbCategoria.DataSource = categorias;
                if (cmbCategoria.Items.Count > 0)
                {
                    cmbCategoria.SelectedIndex = 0;
                }
            }

            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnGuardar, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnCancelar, 15);

            HookValidations();

            if (_idProveedorEdicion > 0)
            {
                lblTitulo.Text = "Actualizar proveedor";
                btnGuardar.Text = "Actualizar proveedor";
                CargarDatosEdicion();
            }
        }

        private void CargarDatosEdicion()
        {
            try
            {
                System.Data.DataRow row = dao.ObtenerProveedorPorId(_idProveedorEdicion);
                if (row != null)
                {
                    txtNombreEmpresa.Text = row["Nombre_Empresa"].ToString();
                    txtNombre.Text = row["Nombre"].ToString();
                    txtApellidoPaterno.Text = row["Apellido_Paterno"].ToString();
                    txtApellidoMaterno.Text = row["Apellido_Materno"].ToString();
                    txtRFC.Text = row["RFC"].ToString();
                    txtTelefono.Text = row["Telefono"].ToString();
                    txtCorreo.Text = row["Correo"].ToString();
                    txtDireccion.Text = row["Direccion"].ToString();
                    txtCiudad.Text = row["Ciudad"].ToString();
                    txtEstado.Text = row["Estado"].ToString();
                    txtCodigoPostal.Text = row["Codigo_Postal"].ToString();
                    
                    string categoria = row["Categoria"].ToString();
                    if (cmbCategoria.Items.Contains(categoria))
                    {
                        cmbCategoria.SelectedItem = categoria;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

                private bool ValidarEmpresa()
        {
            if (!ValidationUtils.EsAlfanumericoConSimbolos(txtNombreEmpresa.Text) || txtNombreEmpresa.Text.Length < 3 || txtNombreEmpresa.Text.Length > 100)
            {
                ValidationUtils.MostrarError(txtNombreEmpresa, "3-100 letras, números y símbolos permitidos.");
                return false;
            }
            ValidationUtils.LimpiarError(txtNombreEmpresa);
            return true;
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

        private bool ValidarRFC()
        {
            if (!ValidationUtils.EsRFCValido(txtRFC.Text))
            {
                ValidationUtils.MostrarError(txtRFC, "RFC inválido (12-13 caracteres).");
                return false;
            }
            ValidationUtils.LimpiarError(txtRFC);
            return true;
        }

        private bool ValidarEstadoCiudad()
        {
            bool okE = ValidationUtils.EsNombreValido(txtEstado.Text);
            bool okC = ValidationUtils.EsNombreValido(txtCiudad.Text);
            if (!okE) ValidationUtils.MostrarError(txtEstado, "Solo letras y espacios."); else ValidationUtils.LimpiarError(txtEstado);
            if (!okC) ValidationUtils.MostrarError(txtCiudad, "Solo letras y espacios."); else ValidationUtils.LimpiarError(txtCiudad);
            return okE && okC;
        }

        private bool ValidarCP()
        {
            if (txtCodigoPostal.Text.Length != 5)
            {
                ValidationUtils.MostrarError(txtCodigoPostal, "Exactamente 5 dígitos.");
                return false;
            }
            ValidationUtils.LimpiarError(txtCodigoPostal);
            return true;
        }

        private bool ValidarDireccion()
        {
            string dir = txtDireccion.Text.Trim();
            if (dir.Length < 10 || dir.Length > 200)
            {
                ValidationUtils.MostrarError(txtDireccion, "10-200 caracteres.");
                return false;
            }
            ValidationUtils.LimpiarError(txtDireccion);
            return true;
        }

        private void HookValidations()
        {
            txtNombreEmpresa.Validating += (s, e) => ValidarEmpresa();
            txtNombre.Validating += (s, e) => ValidarNombres();
            txtApellidoPaterno.Validating += (s, e) => ValidarNombres();
            txtApellidoMaterno.Validating += (s, e) => ValidarNombres();
            txtCorreo.Validating += (s, e) => ValidarCorreo();
            txtTelefono.Validating += (s, e) => ValidarTelefono();
            txtRFC.Validating += (s, e) => ValidarRFC();
            txtEstado.Validating += (s, e) => ValidarEstadoCiudad();
            txtCiudad.Validating += (s, e) => ValidarEstadoCiudad();
            txtCodigoPostal.Validating += (s, e) => ValidarCP();
            txtDireccion.Validating += (s, e) => ValidarDireccion();

            txtNombre.KeyPress += Letras_KeyPress;
            txtApellidoPaterno.KeyPress += Letras_KeyPress;
            txtApellidoMaterno.KeyPress += Letras_KeyPress;
            txtEstado.KeyPress += Letras_KeyPress;
            txtCiudad.KeyPress += Letras_KeyPress;
            txtTelefono.KeyPress += Numeros_KeyPress;
            txtCodigoPostal.KeyPress += Numeros_KeyPress;
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
            if (!ValidarEmpresa() || !ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarRFC() || !ValidarEstadoCiudad() || !ValidarCP() || !ValidarDireccion() || cmbCategoria.SelectedItem == null) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                if (_idProveedorEdicion > 0)
                {
                    dao.ActualizarProveedor(
                        _idProveedorEdicion,
                        txtNombreEmpresa.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellidoPaterno.Text.Trim(),
                        txtApellidoMaterno.Text.Trim(),
                        txtRFC.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtCiudad.Text.Trim(),
                        txtEstado.Text.Trim(),
                        txtCodigoPostal.Text.Trim(),
                        cmbCategoria.SelectedItem.ToString());

                    MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.InsertarProveedor(
                        txtNombreEmpresa.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellidoPaterno.Text.Trim(),
                        txtApellidoMaterno.Text.Trim(),
                        txtRFC.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtCiudad.Text.Trim(),
                        txtEstado.Text.Trim(),
                        txtCodigoPostal.Text.Trim(),
                        cmbCategoria.SelectedItem.ToString());

                    MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                OperacionCompletada?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }
    }
}



