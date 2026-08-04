using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowerShop.Utilidades
{
    public static class UIHelper
    {
        // Paleta de colores "Black and Gold Elegance"
        public static readonly Color ColorFondoPrincipal = Color.FromArgb(255, 255, 255); // Blanco
        public static readonly Color ColorFondoSecundario = Color.FromArgb(229, 229, 229); // Gris Claro (#E5E5E5)
        public static readonly Color ColorAcentoDorado = Color.FromArgb(252, 163, 17); // Dorado (#FCA311)
        public static readonly Color ColorAzulOscuro = Color.FromArgb(20, 33, 61); // Azul oscuro (#14213D)
        public static readonly Color ColorTextoSecundario = Color.FromArgb(0, 0, 0); // Negro (#000000)

        public static void FormatoDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorFondoPrincipal;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Habilitar estilos personalizados de encabezado
            dgv.EnableHeadersVisualStyles = false;

            // Estilo de encabezado de columna
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = ColorFondoSecundario; // Gris claro
            headerStyle.ForeColor = ColorAzulOscuro; // Azul oscuro
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.SelectionBackColor = ColorFondoSecundario;
            headerStyle.SelectionForeColor = ColorAzulOscuro;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(5, 8, 5, 8);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Estilo de celdas por defecto
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = ColorFondoPrincipal;
            cellStyle.ForeColor = ColorTextoSecundario; // Negro
            cellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cellStyle.SelectionBackColor = ColorFondoSecundario; // Gris claro
            cellStyle.SelectionForeColor = ColorTextoSecundario; // Negro (para que contraste bien)
            cellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle = cellStyle;

            // Opciones generales
            dgv.GridColor = Color.FromArgb(210, 210, 210); // Gris claro para bordes
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;
            
            // Solo lectura y sin agregar filas
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
        }

        public static void AplicarBordesRedondeados(Control control, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            int d = radio * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);

            control.Resize += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
                Rectangle r = new Rectangle(0, 0, control.Width, control.Height);
                int dd = radio * 2;
                if(r.Width <= 0 || r.Height <= 0) return;
                p.AddArc(r.X, r.Y, dd, dd, 180, 90);
                p.AddArc(r.Right - dd, r.Y, dd, dd, 270, 90);
                p.AddArc(r.Right - dd, r.Bottom - dd, dd, dd, 0, 90);
                p.AddArc(r.X, r.Bottom - dd, dd, dd, 90, 90);
                p.CloseFigure();
                control.Region = new Region(p);
            };
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

