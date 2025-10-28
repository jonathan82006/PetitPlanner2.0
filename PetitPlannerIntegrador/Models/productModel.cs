using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitPlannerIntegrador.Models
{
    public class productModel
    {
        // Propiedad que contiene el ID, lo mantenemos aunque se obtenga de SessionManager.

        public string IdInventario { get; set; }
        public string IdProducto { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
