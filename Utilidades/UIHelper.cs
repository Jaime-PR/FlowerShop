using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowerShop.Utilidades
{
    public static class UIHelper
    {
        public static readonly Color ColorFondoPrincipal = Color.FromArgb(255, 255, 255); 
        public static readonly Color ColorFondoSecundario = Color.FromArgb(229, 229, 229); 
        public static readonly Color ColorAcentoDorado = Color.FromArgb(252, 163, 17); 
        public static readonly Color ColorAzulOscuro = Color.FromArgb(20, 33, 61); 
        public static readonly Color ColorTextoSecundario = Color.FromArgb(0, 0, 0); 

        public static void FormatoDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorFondoPrincipal;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = ColorFondoSecundario; 
            headerStyle.ForeColor = ColorAzulOscuro; 
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.SelectionBackColor = ColorFondoSecundario;
            headerStyle.SelectionForeColor = ColorAzulOscuro;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(5, 8, 5, 8);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = ColorFondoPrincipal;
            cellStyle.ForeColor = ColorTextoSecundario; 
            cellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cellStyle.SelectionBackColor = ColorFondoSecundario; 
            cellStyle.SelectionForeColor = ColorTextoSecundario; 
            cellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle = cellStyle;
            dgv.GridColor = Color.FromArgb(210, 210, 210); 
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;
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
                if (ctrl is TextBox txt)
                {
                    txt.AccessibleRole = AccessibleRole.Text;
                    if (string.IsNullOrEmpty(txt.AccessibleName))
                    {
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
                if (ctrl.HasChildren)
                {
                    ConfigurarAccesibilidad(ctrl);
                }
            }
        }
    }
}


