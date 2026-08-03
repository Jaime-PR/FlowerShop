const fs = require('fs');
const files = [
    {
        designer: 'Proveedor/frmProveedores.Designer.cs',
        code: 'Proveedor/frmProveedores.cs',
        formToAdd: 'frmAñadir_Proveedor'
    },
    {
        designer: 'Clientes/frmClientes.Designer.cs',
        code: 'Clientes/frmClientes.cs',
        formToAdd: 'frmAñadir_Cliente'
    },
    {
        designer: 'Inventario/frmInventario.Designer.cs',
        code: 'Inventario/frmInventario.cs',
        formToAdd: 'frmAñadir_Producto'
    }
];

files.forEach(f => {
    let des = fs.readFileSync(f.designer, 'utf8');
    
    // add panel definition if not exists
    if (!des.includes('pnlSidebarDerecho')) {
        des = des.replace('private System.Windows.Forms.Panel pnlContenedorPrincipal;', 
                          'private System.Windows.Forms.Panel pnlSidebarDerecho;\n        private System.Windows.Forms.Panel pnlContenedorPrincipal;');
                          
        des = des.replace('this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();', 
                          'this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();\n            this.pnlSidebarDerecho = new System.Windows.Forms.Panel();');
                          
        let panelCode = 
            // pnlSidebarDerecho
            this.pnlSidebarDerecho.BackColor = System.Drawing.Color.White;
            this.pnlSidebarDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebarDerecho.Location = new System.Drawing.Point(600, 0);
            this.pnlSidebarDerecho.Name = "pnlSidebarDerecho";
            this.pnlSidebarDerecho.Size = new System.Drawing.Size(515, 560);
            this.pnlSidebarDerecho.TabIndex = 6;
            this.pnlSidebarDerecho.AutoScroll = true;
            this.pnlSidebarDerecho.Visible = false;
;
        des = des.replace('// pnlContenedorPrincipal', panelCode + '\n            // pnlContenedorPrincipal');
        
        des = des.replace('this.Controls.Add(this.pnlContenedorPrincipal);', 'this.Controls.Add(this.pnlSidebarDerecho);\n            this.Controls.Add(this.pnlContenedorPrincipal);');
        
        fs.writeFileSync(f.designer, des, 'utf8');
    }
    
    let cs = fs.readFileSync(f.code, 'utf8');
    if (!cs.includes('pnlSidebarDerecho.Visible = true;')) {
        let replacement = 
        private void btnAñadir_Click_Sidebar(object sender, EventArgs e) {
            pnlSidebarDerecho.Controls.Clear();
            var frm = new FlowerShop..();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlSidebarDerecho.Controls.Add(frm);
            pnlSidebarDerecho.Visible = true;
            frm.Show();
        }
;
        cs = cs.replace('public partial class', replacement + '\n    public partial class');
        fs.writeFileSync(f.code, cs, 'utf8');
    }
});
