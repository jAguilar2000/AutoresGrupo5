namespace AutoresGrupo5
{
    public partial class App : Application
    {
        static Controllers.PaisesController? dbpaises;
        static Controllers.AutoresController? dbautor;
        public static Controllers.PaisesController DataBase
        {
            get
            {
                if (dbpaises == null)
                {
                    dbpaises = new Controllers.PaisesController();
                }
                return dbpaises;
            }
        }

        public static Controllers.AutoresController DataBaseAutor
        {
            get
            {
                if (dbautor == null)
                {
                    dbautor = new Controllers.AutoresController();
                }
                return dbautor;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            MainPage = new NavigationPage(new Views.PageAutorList());
        }
    }
}
