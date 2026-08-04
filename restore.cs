using System;
using System.IO;
using System.Text.Json;

class Program {
    static void Main() {
        string[] files = { "transcript_proveedor.jsonl", "transcript_cliente.jsonl", "transcript_producto.jsonl" };
        foreach(var f in files) {
            try {
                var lines = File.ReadAllLines(f);
                foreach(var l in lines) {
                    if(l.Contains("default_api:write_to_file")) {
                        using (JsonDocument doc = JsonDocument.Parse(l)) {
                            if (doc.RootElement.TryGetProperty("tool_calls", out JsonElement tcList)) {
                                foreach(var tc in tcList.EnumerateArray()) {
                                    if(tc.GetProperty("name").GetString() == "default_api:write_to_file") {
                                        string argsStr = tc.GetProperty("arguments").GetString();
                                        using (JsonDocument argsDoc = JsonDocument.Parse(argsStr)) {
                                            string file = argsDoc.RootElement.GetProperty("TargetFile").GetString();
                                            string code = argsDoc.RootElement.GetProperty("CodeContent").GetString();
                                            File.WriteAllText(file, code);
                                            Console.WriteLine("Restored " + file);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

