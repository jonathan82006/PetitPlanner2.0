namespace PetitPlannerIntegrador
{
    public static class SessionManager
    {
        // Ambos IDs definidos como STRING para evitar conversiones
        public static string CurrentUserId { get; private set; }
        public static string CurrentIdBusiness { get; private set; } 
        public static string CurrentIdInventory { get; private set; } 
        public static string CurrentIdCalender { get; private set; }
        public static string CurrentIdEvent { get; private set; }


        // Inicia la sesión con el ID de usuario
        public static void StartSession(string userId)
        {
            CurrentUserId = userId;
        }

        // Asigna el ID del negocio (sin necesidad de TryParse/Parse)
        public static void setIdBussines(string idBussines)
        {
            // Simplemente asigna el string al string
            CurrentIdBusiness = idBussines;

        }

        public static void setIdInventory(string idInventory)
        {
            CurrentIdInventory = idInventory;

        }


        public static void setIdCalender(string IdCalender)
        {
            CurrentIdCalender = IdCalender;

        }

        public static void setIdEvent(string IdEvent)
        {
            CurrentIdEvent = IdEvent;

        }

        // Cierra la sesión
        public static void EndSession()
        {
            CurrentUserId = null;
            CurrentIdBusiness = null;
        }
    }
}