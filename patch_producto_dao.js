const fs = require('fs');

const f = '..\\..\\..\\.gemini\\antigravity\\brain\\b4911687-32eb-4fa8-92e8-04276757df07\\.system_generated\\logs\\transcript_full.jsonl';

try {
    const content = fs.readFileSync(f, 'utf8');
    const lines = content.split('\n');
    lines.forEach(l => {
        if (l.includes('replace_file_content') && l.includes('ProductoDAO.cs')) {
            const doc = JSON.parse(l);
            if (doc.tool_calls) {
                doc.tool_calls.forEach(tc => {
                    if (tc.name === 'replace_file_content' || tc.name === 'default_api:replace_file_content') {
                        const args = typeof tc.args === 'string' ? JSON.parse(tc.args) : (tc.args || JSON.parse(tc.arguments));
                        if (args.TargetFile && args.TargetFile.includes('ProductoDAO.cs')) {
                            const original = fs.readFileSync(args.TargetFile, 'utf8');
                            
                            // Normalize newlines
                            const normOriginal = original.replace(/\r\n/g, '\n');
                            const normTarget = args.TargetContent.replace(/\r\n/g, '\n');
                            const normReplacement = args.ReplacementContent.replace(/\r\n/g, '\n');
                            
                            if (normOriginal.includes(normTarget)) {
                                let replaced = normOriginal.replace(normTarget, normReplacement);
                                // Convert back to \r\n for Windows
                                replaced = replaced.replace(/\n/g, '\r\n');
                                fs.writeFileSync(args.TargetFile, replaced, 'utf8');
                                console.log('Patched ' + args.TargetFile);
                            } else {
                                console.log('Target not found for ' + args.TargetFile);
                            }
                        }
                    }
                });
            }
        }
    });
} catch (e) {
    console.error(e.message);
}
