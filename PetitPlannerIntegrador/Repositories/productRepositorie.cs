using MySqlConnector;
using PetitPlannerIntegrador;
using PetitPlannerIntegrador.Models;

public class ProductRepositorie
{
    private readonly string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

    // Cambiar para devolver LISTA de productos
    public List<productModel> GetProductsByInventoryId(string inventoryId)
    {
        string query = "SELECT id_product AS IdProducto, name AS Name, price AS Price, description AS Description " +
                       "FROM product WHERE id_inventory = @id";

        List<productModel> productos = new List<productModel>();

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", inventoryId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // ← Cambiar a WHILE para múltiples registros
                        {
                            productModel product = new productModel
                            {
                                IdInventario = inventoryId,
                                IdProducto = reader["IdProducto"].ToString()!,
                                Name = reader["Name"].ToString()!,
                                Description = reader["Description"].ToString()!,
                                Price = reader["Price"].ToString()!
                            };
                            productos.Add(product);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en ProductRepositorie: {ex.Message}");
            return new List<productModel>();
        }

        return productos;
    }

    // Mantener el método original por compatibilidad
    public productModel UserInformation()
    {
        string idInventory = SessionManager.CurrentIdInventory;
        var productos = GetProductsByInventoryId(idInventory);
        return productos.FirstOrDefault(); // ← Devuelve el primero o null
    }
}