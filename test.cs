using System;
using System.Data;
using MySql.Data.MySqlClient;

class Program {
    static void Main() {
        string cs = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        using (var con = new MySqlConnection(cs)) {
            con.Open();
            var cmd = new MySqlCommand("DESCRIBE USUARIO", con);
            using (var reader = cmd.ExecuteReader()) {
                while(reader.Read()) {
                    Console.WriteLine(reader[0] + " - " + reader[1]);
                }
            }
        }
    }
}

