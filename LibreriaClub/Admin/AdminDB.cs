using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibreriaClub.Admin
{
    internal static class AdminDB
    {
        internal static SqlConnection ConectarDB()
        {
            string cadena = LibreriaClub.Properties.Settings.Default.Key;

            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();
            return connection;
        }
    }
}
