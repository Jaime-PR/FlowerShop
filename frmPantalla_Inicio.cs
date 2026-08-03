using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using FlowerShop.Inventario;

namespace FlowerShop
{
    public partial class frmPantalla_Inicio : Form
    {
        // 1. Variable global privada para guardar el rol
        private string rolDelUsuarioLogueado;
        private SpeechSynthesizer synth = new SpeechSynthesizer();
        private bool isTTSActive = false;
        private bool isHighContrast = false;
        private Dictionary<Control, Tuple<Color, Color>> originalColors = new Dictionary<Control, Tuple<Color, Color>>();

        // Constructor sin parÃ¡metros requerido por el DiseÃ±ador de Visual Studio
        public frmPantalla_Inicio()
        {
            InitializeComponent();
            RedimensionarIconos();
            this.Load += FrmPantalla_Inicio_Load;
        }

        // 2. Ãšnico constructor unificado que recibe el rol
        public frmPantalla_Inicio(string rolUsuario)
        {
            InitializeComponent();
            RedimensionarIconos();
            this.Load += FrmPantalla_Inicio_Load;

            // Guardamos el rol que viene del Login en nuestra variable
            rolDelUsuarioLogueado = rolUsuario;

            if (rolDelUsuarioLogueado != "Administrador")
            {
                btnReportes.Visible = false;
                btnProveedor.Visible = false;
                btnInventario.Visible = false;
                btnUsuarios.Visible = false;
            }
        }

        private void FrmPantalla_Inicio_Load(object sender, EventArgs e)
        {
            AbrirFormulario<frmPrincipal>();
        }

        private void RedimensionarIconos()
        {
            Button[] botones = { btnInicio, bntProductos, btnVentas, btnPedidos, btnClientes, btnUsuarios, btnInventario, btnProveedor, btnCerrarSesion };
            int nuevoTamano = 24;

            foreach (Button btn in botones)
            {
                if (btn.Image != null)
                {
                    Bitmap original = new Bitmap(btn.Image);
                    Bitmap resized = new Bitmap(nuevoTamano, nuevoTamano);
                    using (Graphics g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, nuevoTamano, nuevoTamano);
                    }
                    btn.Image = resized;
                }
            }
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formularioViejo = pnlContenedor.Controls.OfType<MiForm>().FirstOrDefault();

            if (formularioViejo != null)
            {
                formularioViejo.Close(); // Destruir la instancia vieja para asegurar que los datos se recarguen de BD
            }

            Form formulario = new MiForm();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            if (isHighContrast)
            {
                InvertColors(formulario, true);
            }

            pnlContenedor.Controls.Add(formulario);
            pnlContenedor.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmInventario>();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Ventas.frmVentas>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Clientes.frmClientes>();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuarios.frmUsuarios>();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proveedor.frmProveedores>();
        }

        private void bntCategotia_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmCategorias>();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmPrincipal>();
        }

        // Manejador para Cerrar SesiÃ³n (agregado para el botÃ³n inferior)
                private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Reportes.frmReportes>();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnTTS_Click(object sender, EventArgs e)
        {
            isTTSActive = !isTTSActive;
            if (isTTSActive)
            {
                btnTTS.Text = "  Desactivar Texto a Voz";
                btnTTS.BackColor = Color.FromArgb(252, 163, 17);
                btnTTS.ForeColor = Color.Black;
                AttachTTSEvents(pnlSidebar);
            }
            else
            {
                btnTTS.Text = "  Activar Texto a Voz";
                btnTTS.BackColor = pnlSidebar.BackColor;
                btnTTS.ForeColor = Color.FromArgb(229, 229, 229);
                synth.SpeakAsyncCancelAll();
            }
        }

        private void AttachTTSEvents(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && btn != btnTTS)
                {
                    btn.MouseEnter -= Btn_MouseEnterTTS;
                    btn.MouseEnter += Btn_MouseEnterTTS;
                }
                AttachTTSEvents(c);
            }
        }

        private void Btn_MouseEnterTTS(object sender, EventArgs e)
        {
            if (isTTSActive && sender is Button btn)
            {
                synth.SpeakAsyncCancelAll();
                synth.SpeakAsync(btn.Text.Trim());
            }
        }

        private void btnInvertirColores_Click(object sender, EventArgs e)
        {
            if (!isHighContrast)
            {
                isHighContrast = true;
                InvertColors(this, true);
            }
        }

        private void btnRestaurarColores_Click(object sender, EventArgs e)
        {
            if (isHighContrast)
            {
                isHighContrast = false;
                
                // Restore main form background
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                
                // Hardcode original colors for pnlSidebar and its components
                pnlSidebar.BackColor = Color.FromArgb(20, 33, 61);
                
                foreach (Control c in pnlSidebar.Controls)
                {
                    if (c is Button btn)
                    {
                        // Some buttons might have had special backcolors, but in designer they are all transparent or match sidebar
                        btn.BackColor = Color.FromArgb(20, 33, 61); 
                        btn.ForeColor = Color.FromArgb(229, 229, 229);
                    }
                    else if (c is Label lbl)
                    {
                        if (lbl.Name == "lblLogo")
                        {
                            lbl.ForeColor = Color.FromArgb(252, 163, 17);
                        }
                        else
                        {
                            lbl.ForeColor = Color.FromArgb(229, 229, 229);
                        }
                        lbl.BackColor = Color.Transparent;
                    }
                }
                
                // Active button logic (if any) could be overridden here, but currently none exists.
                // We'll reset btnTTS specifically if TTS is active
                if (isTTSActive)
                {
                    btnTTS.BackColor = Color.FromArgb(252, 163, 17);
                    btnTTS.ForeColor = Color.Black;
                }
                
                // Restore original colors for pnlTopBar
                if (pnlTopBar != null) pnlTopBar.BackColor = Color.White;
                if (lblTituloSeccion != null) lblTituloSeccion.ForeColor = Color.Black;

                // Close and recreate the active child form to fully load native VS designer colors
                Form activeForm = pnlContenedor.Controls.OfType<Form>().FirstOrDefault();
                if (activeForm != null)
                {
                    Type formType = activeForm.GetType();
                    activeForm.Close();
                    
                    var method = this.GetType().GetMethod("AbrirFormulario", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (method != null)
                    {
                        var genericMethod = method.MakeGenericMethod(formType);
                        genericMethod.Invoke(this, null);
                    }
                }
            }
        }

        private void InvertColors(Control parent, bool applyHighContrast)
        {
            if (applyHighContrast)
            {
                // Save original colors if not saved
                if (!originalColors.ContainsKey(parent))
                {
                    originalColors[parent] = new Tuple<Color, Color>(parent.BackColor, parent.ForeColor);
                }

                // Invert colors if not fully transparent
                if (parent.BackColor.A > 0)
                {
                    parent.BackColor = Color.FromArgb(parent.BackColor.A, 255 - parent.BackColor.R, 255 - parent.BackColor.G, 255 - parent.BackColor.B);
                }
                if (parent.ForeColor.A > 0)
                {
                    parent.ForeColor = Color.FromArgb(parent.ForeColor.A, 255 - parent.ForeColor.R, 255 - parent.ForeColor.G, 255 - parent.ForeColor.B);
                }
            }
            else
            {
                // Restore original colors
                if (originalColors.ContainsKey(parent))
                {
                    parent.BackColor = originalColors[parent].Item1;
                    parent.ForeColor = originalColors[parent].Item2;
                }
            }
            
            foreach (Control c in parent.Controls)
            {
                InvertColors(c, applyHighContrast);
            }
        }
    }
}
