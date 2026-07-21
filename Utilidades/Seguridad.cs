using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; 


namespace TuProyectoFloreria.Utilidades 
{
    public static class Seguridad
    {
        public static string EncriptarSHA256(string textoPlano)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
                StringBuilder constructorString = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    constructorString.Append(bytes[i].ToString("x2"));
                }
                return constructorString.ToString();
            }
        }
    }
}