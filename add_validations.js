const fs = require('fs');

function addValidations(filePath, validationsStr, hookStr, guardConditionStr) {
    if (!fs.existsSync(filePath)) return;
    let content = fs.readFileSync(filePath, 'utf8');

    // Fix bad encoding characters if they exist
    content = content.replace(//g, 'ñ');
    content = content.replace(/±/g, 'ñ');
    
    // Add using FlowerShop.Utilidades; if not present
    if (!content.includes('using FlowerShop.Utilidades;')) {
        content = content.replace('using System.Windows.Forms;', 'using System.Windows.Forms;\nusing FlowerShop.Utilidades;');
    }

    // Replace btnGuardar_Click with validationMethods + btnGuardar_Click
    if (!content.includes('Validar')) { // prevent duplicate injection
        content = content.replace(/private void btnGuardar_Click/g, validationsStr + '\n\n        private void btnGuardar_Click');
        
        // Add hookValidations inside Form_Load
        const loadRegex = /private void frmAñadir_.*?_Load\(object sender, EventArgs e\)\s*\{([\s\S]*?)\}/;
        content = content.replace(loadRegex, (match, p1) => {
            return match.replace(p1, p1 + '\n            HookValidations();\n');
        });

        // Add guard condition to btnGuardar_Click
        const guardRegex = /if \(string\.IsNullOrWhiteSpace.*?return;/s;
        if (guardRegex.test(content)) {
            content = content.replace(guardRegex, guardConditionStr);
        } else {
            // fallback, insert at start of btnGuardar_Click
            content = content.replace(/private void btnGuardar_Click\(object sender, EventArgs e\)\s*\{\s*try\s*\{/s, 
                `private void btnGuardar_Click(object sender, EventArgs e)\n        {\n            ` + guardConditionStr + `\n            try\n            {`);
        }
    }

    fs.writeFileSync(filePath, content, 'utf8');
}

// 1. Producto
const prodValidations = `
        private bool ValidarNombre()
        {
            string texto = txtNombreProducto.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto) || texto.Length < 3 || texto.Length > 100 || !System.Text.RegularExpressions.Regex.IsMatch(texto, "^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\\\\s]+$"))
            {
                ValidationUtils.MostrarError(txtNombreProducto, "Nombre inválido (3-100 caracteres, letras y números).");
                return false;
            }
            ValidationUtils.LimpiarError(txtNombreProducto);
            return true;
        }

        private bool ValidarCantidad()
        {
            if (!int.TryParse(txtCantidad.Text, out int cant) || cant < 1 || cant > 100000)
            {
                ValidationUtils.MostrarError(txtCantidad, "Debe ser un número entre 1 y 100,000.");
                return false;
            }
            ValidationUtils.LimpiarError(txtCantidad);
            return true;
        }

        private bool ValidarPrecios()
        {
            bool compraOk = decimal.TryParse(txtPrecioCompra.Text, out decimal compra) && compra > 0;
            bool ventaOk = decimal.TryParse(txtPrecioVenta.Text, out decimal venta) && venta > 0;
            
            if (!compraOk) ValidationUtils.MostrarError(txtPrecioCompra, "Precio de compra inválido (> 0).");
            else ValidationUtils.LimpiarError(txtPrecioCompra);

            if (!ventaOk) ValidationUtils.MostrarError(txtPrecioVenta, "Precio de venta inválido (> 0).");
            else if (compraOk && venta < compra)
            {
                ValidationUtils.MostrarError(txtPrecioVenta, "El precio de venta debe ser mayor o igual al de compra.");
                ventaOk = false;
            }
            else ValidationUtils.LimpiarError(txtPrecioVenta);

            if (compraOk && ventaOk && compra == venta)
            {
                ValidationUtils.MostrarError(txtPrecioVenta, "Advertencia: Precio venta igual a precio compra.");
            }
            return compraOk && (venta >= compra);
        }

        private void HookValidations()
        {
            txtNombreProducto.Validating += (s, e) => ValidarNombre();
            txtCantidad.Validating += (s, e) => ValidarCantidad();
            txtPrecioCompra.Validating += (s, e) => ValidarPrecios();
            txtPrecioVenta.Validating += (s, e) => ValidarPrecios();

            txtCantidad.KeyPress += Numeros_KeyPress;
            txtCantidadInsumo.KeyPress += Numeros_KeyPress;
            txtPrecioCompra.KeyPress += Decimales_KeyPress;
            txtPrecioVenta.KeyPress += Decimales_KeyPress;
        }

        private void Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void Decimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
        }`;
const prodGuard = `if (!ValidarNombre() || !ValidarCantidad() || !ValidarPrecios() || cmbProveedor.SelectedItem == null || cmbCategoria.SelectedItem == null) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }`;

addValidations('Inventario/frmAñadir_Producto.cs', prodValidations, 'HookValidations();', prodGuard);

let p = fs.readFileSync('Inventario/frmAñadir_Producto.cs', 'utf8');
p = p.replace(/private void btnAñadir_Click[\s\S]*?^\s*\}/m, `private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null) return;
            if (!int.TryParse(txtCantidadInsumo.Text, out int cant) || cant < 1)
            {
                ValidationUtils.MostrarError(txtCantidadInsumo, "Cantidad inválida.");
                return;
            }
            ValidationUtils.LimpiarError(txtCantidadInsumo);

            string productoSel = cmbProducto.SelectedItem.ToString();
            foreach (DataGridViewRow row in dgvReceta.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["Producto"].Value?.ToString() == productoSel)
                {
                    MessageBox.Show("El producto ya está en la receta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvReceta.Rows.Add(productoSel, cant);
            txtCantidadInsumo.Clear();
        }`);
fs.writeFileSync('Inventario/frmAñadir_Producto.cs', p, 'utf8');

// 2. Cliente
const cliValidations = `
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
        }`;
const cliGuard = `if (!ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarDireccion()) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }`;

addValidations('Clientes/frmAñadir_Cliente.cs', cliValidations, 'HookValidations();', cliGuard);

// 3. Usuario
const usuValidations = `
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
        }`;
const usuGuard = `if (!ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarUsuario() || !ValidarPassword() || cmbRol.SelectedItem == null) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }`;

addValidations('Usuarios/frmAñadir_Usuario.cs', usuValidations, 'HookValidations();', usuGuard);

// 4. Proveedor
const provValidations = `
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
        }`;
const provGuard = `if (!ValidarEmpresa() || !ValidarNombres() || !ValidarCorreo() || !ValidarTelefono() || !ValidarRFC() || !ValidarEstadoCiudad() || !ValidarCP() || !ValidarDireccion() || cmbCategoria.SelectedItem == null) { MessageBox.Show("Por favor, complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }`;

addValidations('Proveedor/frmAñadir_Proveedor.cs', provValidations, 'HookValidations();', provGuard);
