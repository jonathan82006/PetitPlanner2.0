using MySqlConnector;
using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador;
using System;

namespace PetitPlannerIntegrador.Repositories
{
    public class BussinesRepositorie
    {
        private readonly string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

        public bussinesModel UserInformation()
        {
            // Obtener el ID del usuario directamente desde el SessionManager.
            string userId = SessionManager.CurrentUserId;

            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            // Consulta: Usamos alias para asegurar que los nombres de las columnas coincidan con el modelo si es necesario.
            string query = "SELECT name AS Name, id_bussines AS idBussines FROM bussines WHERE id_user = @id";
            bussinesModel usuario = null;

            try // Añadir un bloque try-catch es crucial para manejo de errores de DB
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", userId);
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenamos el modelo con los datos de la DB.
                                usuario = new bussinesModel
                                {
                                    IdUser = userId, // Asignamos el ID de la sesión.

                                    // 🔑 CORRECCIÓN: Los nombres de columna deben ir como cadenas (strings)
                                    // en el lector, o usar el nombre exacto de la columna de la DB.
                                    name = reader["Name"].ToString()!,
                                    idBussines = reader["idBussines"].ToString()!,// <-- Debe coincidir con el alias 'Name' del SELECT
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de error si la conexión falla (opcional, pero recomendado)
                // System.Windows.Forms.MessageBox.Show($"Error de base de datos: {ex.Message}");
                return null;
            }

            return usuario;
        }
    }
}