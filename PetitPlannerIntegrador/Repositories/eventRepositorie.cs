using MySqlConnector;
using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador;
using System;

namespace PetitPlannerIntegrador.Repositories
{
    public class EventRepositorie
    {
        private readonly string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

        public EventModel UserInformation()
        {
            // Obtener el ID del usuario directamente desde el SessionManager.
            string IdCalender = SessionManager.CurrentIdCalender;

            if (string.IsNullOrEmpty(IdCalender))
            {
                return null;
            }

            // Consulta: Usamos alias para asegurar que los nombres de las columnas coincidan con el modelo si es necesario.
            string query = "SELECT id_event AS IdEvent, id_calender AS IdCalender, name AS Name, date AS Date, eventhour AS Eventhour, description AS Description FROM event WHERE id_calender = @id";
            EventModel usuario = null;

            try // Añadir un bloque try-catch es crucial para manejo de errores de DB
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", IdCalender);
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenamos el modelo con los datos de la DB.
                                usuario = new EventModel
                                {
                                    IdCalender= IdCalender, // Asignamos el ID de la sesión.

                                    // 🔑 CORRECCIÓN: Los nombres de columna deben ir como cadenas (strings)
                                    // en el lector, o usar el nombre exacto de la columna de la DB.
                                    IdEvent = reader["IdEvent"].ToString()!,
                                    Name = reader["Name"].ToString()!,
                                    Eventhour = reader["EventHour"].ToString()!,
                                    Description = reader["Description"].ToString()!,
                                    Date = reader["Date"].ToString()!
                                    ,// <-- Debe coincidir con el alias 'Name' del SELECT
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