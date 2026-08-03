using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlowerShop.Utilidades
{
    public static class Validaciones
    {
        // Evento KeyPress: Solo permite letras, control (borrar) y espacio
        public static void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter
            }
        }

        // Evento KeyPress: Solo permite números y control
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento KeyPress: Solo permite letras, números y espacio
        public static void LetrasYNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento KeyPress: Solo números y un punto decimal
        public static void SoloNumerosYDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            TextBox txt = sender as TextBox;
            if (txt != null && e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Validar formato de Correo Electrónico
        public static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                // Usar expresión regular estándar para emails
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Validar RFC genérico (Alfanumérico entre 12 y 13 caracteres, sin espacios)
        public static bool EsRFCValido(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc)) return false;
            // Normalmente el RFC es de 12 (empresa) o 13 (física) caracteres
            return Regex.IsMatch(rfc, @"^[A-Z0-9]{12,13}$", RegexOptions.IgnoreCase);
        }
    }
}
