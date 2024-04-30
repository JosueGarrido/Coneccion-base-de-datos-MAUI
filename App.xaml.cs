using jgarrido_s5.Views;

namespace jgarrido_s5
{
    public partial class App : Application
    {
        public static PersonRespository personRepo {  get; set; }
        public App(PersonRespository personRespository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new vPersona());
            personRepo = personRespository;
        }
    }
}
