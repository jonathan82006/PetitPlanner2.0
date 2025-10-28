using PetitPlannerIntegrador;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());  // ← Asegúrate que dice MainForm
    }
}