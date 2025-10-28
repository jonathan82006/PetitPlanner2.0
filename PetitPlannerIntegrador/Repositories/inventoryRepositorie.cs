using MySqlConnector;
using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador;
using System;

namespace PetitPlannerIntegrador.Repositories
{
    public class InventoryRepositorie
    {
        private readonly string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

        public inventoryModel UserInformation()
        {
            // Obtener el ID del usuario directamente desde el SessionManager.
            string bussinesId = SessionManager.CurrentIdBusiness;

            if (string.IsNullOrEmpty(bussinesId))
            {
                return null;
            }

            // Consulta: Usamos alias para asegurar que los nombres de las columnas coincidan con el modelo si es necesario.
            string query = "SELECT id_inventory AS IdInventory, id_bussines AS IdBussines FROM inventory WHERE id_bussines = @id LIMIT 1"; 
            inventoryModel usuario = null;

            try // Añadir un bloque try-catch es crucial para manejo de errores de DB
            {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", bussinesId);
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenamos el modelo con los datos de la DB.
                                usuario = new inventoryModel
                                {
                                    idBussines = bussinesId, // Asignamos el ID de la sesión.
                                    idInventory = reader["IdInventory"].ToString()!, 

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