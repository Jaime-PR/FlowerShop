const fs = require('fs');
const files = [
    'Proveedor/frmAñadir_Proveedor.cs', 'Proveedor/frmAñadir_Proveedor.Designer.cs',
    'Clientes/frmAñadir_Cliente.cs', 'Clientes/frmAñadir_Cliente.Designer.cs',
    'Inventario/frmAñadir_Producto.cs', 'Inventario/frmAñadir_Producto.Designer.cs'
];

files.forEach(f => {
    let content = fs.readFileSync(f, 'utf8');
    // the character is U+FFFD
    content = content.replace(/\uFFFD/g, 'ñ');
    
    // Also, ensure AutoScroll is set
    if (f.endsWith('Designer.cs')) {
        content = content.replace(/this\.Name = "frmAñadir_[A-Za-z]+";/g, match => match + '\n            this.AutoScroll = true;');
    }
    
    fs.writeFileSync(f, content, 'utf8');
});
