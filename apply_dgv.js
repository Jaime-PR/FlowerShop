const fs = require('fs');

const dgvSettings = `
            this.REPLACE_DGV_NAME.ReadOnly = true;
            this.REPLACE_DGV_NAME.AllowUserToAddRows = false;
            this.REPLACE_DGV_NAME.AllowUserToDeleteRows = false;
            this.REPLACE_DGV_NAME.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.REPLACE_DGV_NAME.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.REPLACE_DGV_NAME.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
`;

const files = [
    { file: 'Proveedor/frmProveedores.Designer.cs', dgv: 'dgvProveedor' },
    { file: 'Clientes/frmClientes.Designer.cs', dgv: 'dgvClientes' },
    { file: 'Inventario/frmInventario.Designer.cs', dgv: 'dgvInventario' },
    { file: 'Usuarios/frmUsuarios.Designer.cs', dgv: 'dgvUsuarios' }
];

files.forEach(f => {
    try {
        let content = fs.readFileSync(f.file, 'utf8');
        if (!content.includes('SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect')) {
            const anchor = `this.${f.dgv}.Name = "${f.dgv}";`;
            const injection = dgvSettings.replace(/REPLACE_DGV_NAME/g, f.dgv);
            content = content.replace(anchor, anchor + injection);
            fs.writeFileSync(f.file, content, 'utf8');
        }
    } catch(e) {}
});

// Check frmMenu.cs
let menu = fs.readFileSync('frmMenu.cs', 'utf8');
if (!menu.includes('this.Load +=')) {
    // find public frmMenu() { InitializeComponent(); ... }
    menu = menu.replace('InitializeComponent();', 'InitializeComponent();\n            this.Load += (s, e) => { btnInicio_Click(this, EventArgs.Empty); };');
    fs.writeFileSync('frmMenu.cs', menu, 'utf8');
}
