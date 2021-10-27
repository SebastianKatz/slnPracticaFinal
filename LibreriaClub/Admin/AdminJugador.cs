using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibreriaClub.Models;
using System.Data;

namespace LibreriaClub.Admin
{
    public static class AdminJugador
    {
        public static List<Jugador> Listar()
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string consulta = "SELECT Id,Nombre,Apellido,FechaNacimiento,Puesto FROM dbo.Jugador";
            SqlCommand comando = new SqlCommand(consulta, connection);
            SqlDataReader reader = comando.ExecuteReader();
            List<Jugador> list = new List<Jugador>();
            while (reader.Read())
            {
                list.Add
                  (
                    new Jugador
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Puesto = reader["Puesto"].ToString()
                    }
                    );
            }
            connection.Close();
            reader.Close();
            return list;
        }
        public static int Insertar(Jugador jugador)
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string insertSQL = "INSERT dbo.Jugador (Nombre,Apellido,FechaNacimiento,Puesto) VALUES(@Nombre, @Apellido, @FechaNacimiento, @Puesto)";
            SqlCommand command = new SqlCommand(insertSQL, connection);
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            command.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;
            int filasAfectadas = command.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;
        }
        public static DataTable ListarPuestos()
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string querySql = "SELECT DISTINCT Puesto FROM dbo.Jugador";
            SqlDataAdapter adapter = new SqlDataAdapter(querySql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Puesto");
            return ds.Tables["Puesto"];
        }

        public static DataTable Listar(string puesto)
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string querySql = "SELECT Id,Nombre,Apellido,FechaNacimiento,Puesto FROM dbo.Jugador WHERE Puesto = @Puesto";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, connection);
            adapter.SelectCommand.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = puesto;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Jugadores");
            return ds.Tables["Jugadores"];
        }

        public static int Modificar(Jugador jugador)
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string querySql = "UPDATE dbo.Jugador SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Puesto = @Puesto WHERE Id = @Id";
            SqlDataAdapter adapter = new SqlDataAdapter(querySql, connection);
            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            adapter.SelectCommand.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            adapter.SelectCommand.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = jugador.Id;
            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;
        }

        public static int Eliminar(int idJugador)
        {
            SqlConnection connection = AdminDB.ConectarDB();
            string querySql = "DELETE FROM dbo.Jugador WHERE Id = @Id";
            SqlDataAdapter adapter = new SqlDataAdapter(querySql, connection);
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = idJugador;
            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;
        }


    }

}
