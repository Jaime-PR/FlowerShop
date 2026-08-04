using System;
using System.Data;
using MySql.Data.MySqlClient;

class Program {
    static void Main() {
        string cs = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        using(var con = new MySqlConnection(cs)) {
            con.Open();
            string[] tables = { "cliente", "producto", "venta" };
            foreach(var t in tables) {
                Console.WriteLine("--- Table: " + t + " ---");
                var cmd = new MySqlCommand("DESCRIBE " + t, con);
                using(var rdr = cmd.ExecuteReader()) {
                    while(rdr.Read()) {
                        Console.WriteLine(rdr["Field"] + " - " + rdr["Type"]);
                    }
                }
            }
        }
    }
}


