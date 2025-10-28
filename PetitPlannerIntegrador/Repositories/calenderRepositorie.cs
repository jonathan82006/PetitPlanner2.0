using MySqlConnector;
using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador;
using System;

namespace PetitPlannerIntegrador.Repositories
{
    public class CalenderRepositorie
    {
        private readonly string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

        public CalenderModel UserInformation() 
        {
            string bussinesId = SessionManager.CurrentIdBusiness;

            if (string.IsNullOrEmpty(bussinesId))
            {
                return null;
            }

            string query = "SELECT id_calender AS IdCalender, id_bussines AS IdBussines FROM calender WHERE id_bussines = @id";
            CalenderModel usuario = null; 

            try
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
                                usuario = new CalenderModel 
                                {
                                    idBussines = bussinesId,
                                    idCalender = reader["IdCalender"].ToString()!,
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuario;
        }
    }
}