import json

for fname in ['transcript_proveedor.jsonl', 'transcript_cliente.jsonl', 'transcript_producto.jsonl']:
    try:
        with open(fname, 'r', encoding='utf-8') as f:
            for line in f:
                d = json.loads(line)
                if 'tool_calls' in d:
                    for tc in d['tool_calls']:
                        if tc['name'] == 'default_api:write_to_file':
                            args = json.loads(tc['arguments'])
                            if 'TargetFile' in args and 'CodeContent' in args:
                                with open(args['TargetFile'], 'w', encoding='utf-8') as out:
                                    out.write(args['CodeContent'])
                                print(f"Restored {args['TargetFile']}")
    except Exception as e:
        print(f"Error in {fname}: {e}")
