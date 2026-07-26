using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowerShop.Utilidades
{
    public static class UIHelper
    {
        public static void FormatoDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Habilitar estilos personalizados de encabezado
            dgv.EnableHeadersVisualStyles = false;

            // Estilo de encabezado de columna
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(250, 250, 250); // Gris muy claro
            headerStyle.ForeColor = Color.FromArgb(51, 51, 51); // Gris oscuro
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Azul por si seleccionan columna
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(5, 8, 5, 8);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Estilo de celdas por defecto
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            cellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cellStyle.SelectionBackColor = Color.FromArgb(253, 239, 178); // Amarillo/Beige pastel como en la foto
            cellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            cellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle = cellStyle;

            // Opciones generales
            dgv.GridColor = Color.FromArgb(230, 230, 230); // Gris claro para las lineas divisorias
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;
            
            // Solo lectura y sin agregar filas si no está configurado de otra forma
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
        }

        public static void ConfigurarAccesibilidad(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // Asignar rol y nombre según el tipo de control
                if (ctrl is TextBox txt)
                {
                    txt.AccessibleRole = AccessibleRole.Text;
                    if (string.IsNullOrEmpty(txt.AccessibleName))
                    {
                        // Intentar deducir el nombre basándose en el Name (ej. txtNombre -> Nombre)
                        string name = txt.Name.Replace("txt", "");
                        txt.AccessibleName = name;
                    }
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.AccessibleRole = AccessibleRole.ComboBox;
                    if (string.IsNullOrEmpty(cmb.AccessibleName))
                    {
                        string name = cmb.Name.Replace("cmb", "");
                        cmb.AccessibleName = name;
                    }
                }
                else if (ctrl is Button btn)
                {
                    btn.AccessibleRole = AccessibleRole.PushButton;
                    if (string.IsNullOrEmpty(btn.AccessibleName))
                    {
                        btn.AccessibleName = string.IsNullOrEmpty(btn.Text) ? btn.Name.Replace("btn", "") : btn.Text;
                    }
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.AccessibleRole = AccessibleRole.Table;
                    if (string.IsNullOrEmpty(dgv.AccessibleName))
                    {
                        dgv.AccessibleName = "Tabla de datos";
                    }
                    if (string.IsNullOrEmpty(dgv.AccessibleDescription))
                    {
                        dgv.AccessibleDescription = "Tabla de datos de " + dgv.Name.Replace("dgv", "").Replace("dataGridView", "");
                    }
                }
                else if (ctrl is Label lbl)
                {
                    lbl.AccessibleRole = AccessibleRole.StaticText;
                    if (string.IsNullOrEmpty(lbl.AccessibleName))
                    {
                        lbl.AccessibleName = lbl.Text;
                    }
                }
                else if (ctrl is PictureBox pic)
                {
                    pic.AccessibleRole = AccessibleRole.Graphic;
                }

                // Recursión para controles anidados (paneles, groupboxes, etc.)
                if (ctrl.HasChildren)
                {
                    ConfigurarAccesibilidad(ctrl);
                }
            }
        }
    }
}
