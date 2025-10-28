using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitPlannerIntegrador.Models
{
    public class userModel
    {
        // Propiedad que contiene el ID, lo mantenemos aunque se obtenga de SessionManager.
        public string IdUser { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }
    }
}
