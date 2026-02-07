using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tugas_Besar_PBO.NET.Database
{
    public class Koneksi
    {
        private static string connString =
            "server=localhost;database=db_tugasbesar;uid=root;pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}
