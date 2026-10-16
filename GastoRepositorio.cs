using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RepositorioGastos
{
    public class GastoRepositorio
    {
        private const string CadenaConexion =
    @"Server=(localdb)\ProjectModels;" +
    @"Database=GastosDB;" +
    @"Trusted_Connection=True;" +
    @"TrustServerCertificate=True;";

        public void Insertar(Gasto g)
        {
            string sql = @"INSERT INTO Gastos (Descripcion, Monto, Categoria)
                           VALUES (@descripcion, @monto, @categoria)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@descripcion", g.Descripcion);
                comando.Parameters.AddWithValue("@monto", g.Monto);
                comando.Parameters.AddWithValue("@categoria", g.Categoria);

                conexion.Open();
                int filas = comando.ExecuteNonQuery();

                if (filas == 1)
                    Console.WriteLine("El gasto se registró correctamente");
                else
                    Console.WriteLine("No se pudo guardar el gasto.");
            }
        }

        public List<Gasto> ListarTodos()
        {
            List<Gasto> lista = new List<Gasto>();

            string sql = @"SELECT Id, Descripcion, Monto, Categoria
                           FROM Gastos
                           ORDER BY Id";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Gasto
                        {
                            Id = lector.GetInt32(0),
                            Descripcion = lector.GetString(1),
                            Monto = lector.GetDecimal(2),
                            Categoria = lector.GetString(3)
                        });
                    }
                }
            }

            return lista;
        }
    }
}