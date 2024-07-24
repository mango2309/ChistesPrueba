using ChistesPrueba.Models;

namespace ChistesPrueba
{
    public partial class App : Application
    {
        public static ChisteDatabase Database { get; private set; }

        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chistes.db3");
            Database = new ChisteDatabase(dbPath);

            MainPage = new AppShell();
        }
    }
}
