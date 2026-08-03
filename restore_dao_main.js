const fs = require('fs');

const f = '..\\..\\..\\.gemini\\antigravity\\brain\\b4911687-32eb-4fa8-92e8-04276757df07\\.system_generated\\logs\\transcript_full.jsonl';

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
