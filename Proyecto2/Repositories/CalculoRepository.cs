using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto2.Repositories
{
    public class CalculoRepository : ICalculoRepository
    {
        private readonly string connectionString;

        public CalculoRepository(string connString)
        {
            connectionString = connString;
        }

        public List<CalculoModel> GetTodosLosCalculos()
        {
            List<CalculoModel> calculos = new List<CalculoModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Id, Operacion, Resultado, FechaHora 
                               FROM HistorialCalculos 
                               ORDER BY FechaHora DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            calculos.Add(new CalculoModel
                            {
                                Id = reader.GetInt32(0),
                                Operacion = reader.GetString(1),
                                Resultado = reader.GetDecimal(2),
                                FechaHora = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }

            return calculos;
        }

        public List<CalculoModel> GetSumas()
        {
            return GetCalculosPorOperador("+");
        }

        public List<CalculoModel> GetRestas()
        {
            return GetCalculosPorOperador("-");
        }

        public List<CalculoModel> GetMultiplicaciones()
        {
            return GetCalculosPorOperador("*");
        }

        public List<CalculoModel> GetDivisiones()
        {
            return GetCalculosPorOperador("/");
        }

        private List<CalculoModel> GetCalculosPorOperador(string operador)
        {
            List<CalculoModel> calculos = new List<CalculoModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Id, Operacion, Resultado, FechaHora 
                               FROM HistorialCalculos 
                               WHERE Operacion LIKE '%' + @Operador + '%'
                               ORDER BY FechaHora DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Operador", operador);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            calculos.Add(new CalculoModel
                            {
                                Id = reader.GetInt32(0),
                                Operacion = reader.GetString(1),
                                Resultado = reader.GetDecimal(2),
                                FechaHora = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }

            return calculos;
        }
    }
}