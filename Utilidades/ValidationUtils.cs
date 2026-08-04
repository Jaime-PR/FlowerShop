using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlowerShop.Utilidades
{
    public static class ValidationUtils
    {
        // Expresiones regulares
        public static readonly string RegexNombres = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";
        public static readonly string RegexEmail = @"^[^\s@]+@[^\s@]+\.[a-zA-Z]{2,}$";
        public static readonly string RegexRFC = @"^[A-ZÑ&]{3,4}\d{6}[A-Z0-9]{3}$";
        public static readonly string RegexUsuario = @"^[a-zA-Z0-9]+$";
        public static readonly string RegexPassword = @"^(?=.*[A-Z])(?=.*\d)[a-zA-Z\d\w\W]{8,}$";
        public static readonly string RegexAlfanumericoSimbolos = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\&\.\,\-]+$";

        public static bool EsNombreValido(string texto)
        {
            return Regex.IsMatch(texto, RegexNombres);
        }

        public static bool EsEmailValido(string email)
        {
            return Regex.IsMatch(email, RegexEmail);
        }

        public static bool EsRFCValido(string rfc)
        {
            return Regex.IsMatch(rfc.ToUpper(), RegexRFC);
        }

        public static bool EsUsuarioValido(string usuario)
        {
            return Regex.IsMatch(usuario, RegexUsuario);
        }

        public static bool EsPasswordSegura(string password)
        {
            return Regex.IsMatch(password, RegexPassword);
        }

        public static bool EsAlfanumericoConSimbolos(string texto)
        {
            return Regex.IsMatch(texto, RegexAlfanumericoSimbolos);
        }

        // Manejo de UI de Errores
        public static void MostrarError(Control control, string mensaje)
        {
            if (control.Parent == null) return;

            string labelName = "lblError_" + control.Name;
            Label lblError = control.Parent.Controls[labelName] as Label;

            if (lblError == null)
            {
                lblError = new Label();
                lblError.Name = labelName;
                lblError.ForeColor = ColorTranslator.FromHtml("#FCA311");
                lblError.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
                lblError.AutoSize = true;
                lblError.MaximumSize = new Size(control.Width, 0); // Envolver texto si es muy largo
                control.Parent.Controls.Add(lblError);
            }

            lblError.Text = mensaje;
            lblError.Location = new Point(control.Left, control.Bottom + 2);
            lblError.Visible = true;
            lblError.BringToFront();
        }

        public static void LimpiarError(Control control)
        {
            if (control.Parent == null) return;
            string labelName = "lblError_" + control.Name;
            Label lblError = control.Parent.Controls[labelName] as Label;
            if (lblError != null)
            {
                lblError.Visible = false;
                lblError.Text = "";
            }
        }
    }
}

