const fs = require('fs');

const f = 'Proveedor/frmProveedores.Designer.cs';
let content = fs.readFileSync(f, 'utf8');

const target = 'this.button1.Click += new System.EventHandler(this.button1_Click);';
content = content.replace(target, '');
fs.writeFileSync(f, content, 'utf8');
