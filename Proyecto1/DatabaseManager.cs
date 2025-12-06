using System;
using System.Data.SqlClient;

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string server, string database)
    {
        connectionString = $"Server={server};Database={database};Integrated Security=true;";
    }

    public void SaveCalculation(string operation, decimal result)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO HistorialCalculos (Operacion, Resultado, FechaHora) 
                                VALUES (@Operacion, @Resultado, @FechaHora)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Operacion", operation);
                    cmd.Parameters.AddWithValue("@Resultado", result);
                    cmd.Parameters.AddWithValue("@FechaHora", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al guardar en la base de datos: {ex.Message}");
        }
    }

    public bool TestConnection()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}