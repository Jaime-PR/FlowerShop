const fs = require('fs');
const files = [
    'Inventario/frmAñadir_Producto.cs', 'Inventario/frmAñadir_Producto.Designer.cs',
    'Clientes/frmAñadir_Cliente.cs', 'Clientes/frmAñadir_Cliente.Designer.cs',
    'Proveedor/frmAñadir_Proveedor.cs', 'Proveedor/frmAñadir_Proveedor.Designer.cs',
    'Usuarios/frmAñadir_Usuario.cs', 'Usuarios/frmAñadir_Usuario.Designer.cs'
];

files.forEach(f => {
    if (!fs.existsSync(f)) return;
    let buf = fs.readFileSync(f);
    // If it doesn't have BOM, add it
    if (buf.length >= 3 && buf[0] === 0xEF && buf[1] === 0xBB && buf[2] === 0xBF) {
        // has BOM
    } else {
        const bom = Buffer.from([0xEF, 0xBB, 0xBF]);
        buf = Buffer.concat([bom, buf]);
        fs.writeFileSync(f, buf);
    }
});
