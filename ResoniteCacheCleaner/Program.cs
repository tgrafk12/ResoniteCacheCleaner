namespace ResoniteCacheCleaner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application (this gives the app the modern look)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the main form of the application (Form1)
            Application.Run(new Form1());
        }
    }
}
