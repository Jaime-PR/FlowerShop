const fs = require('fs');

const files = ['transcript_proveedor.jsonl', 'transcript_cliente.jsonl', 'transcript_producto.jsonl'];

files.forEach(f => {
    try {
        const content = fs.readFileSync(f, 'utf8');
        const lines = content.split('\n');
        lines.forEach(l => {
            if (l.includes('write_to_file')) {
                const doc = JSON.parse(l);
                if (doc.tool_calls) {
                    doc.tool_calls.forEach(tc => {
                        if (tc.name === 'write_to_file' || tc.name === 'default_api:write_to_file') {
                            const args = typeof tc.args === 'string' ? JSON.parse(tc.args) : (tc.args || JSON.parse(tc.arguments));
                            if (args.TargetFile && args.CodeContent && args.TargetFile.includes('DAO.cs')) {
                                fs.writeFileSync(args.TargetFile, args.CodeContent, 'utf8');
                                console.log('Restored ' + args.TargetFile);
                            }
                        }
                    });
                }
            }
        });
    } catch (e) {
        console.error(e.message);
    }
});
