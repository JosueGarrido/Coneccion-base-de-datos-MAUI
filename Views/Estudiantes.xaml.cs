using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace jgarrido_s5.Views;

public partial class Estudiantes : ContentPage
{
	private const string url = "http://192.168.1.6:8888/moviles/post.php";
	private readonly HttpClient client = new HttpClient();
	private ObservableCollection<Estudiante> estud;

	public Estudiantes()
	{
		InitializeComponent();
		Obtener();

	}

	public async void Obtener()
	{
		var content = await client.GetStringAsync(url);
		List<Estudiante> mostradEst = JsonConvert.DeserializeObject < List < Estudiante >>(content);
		estud = new ObservableCollection<Estudiante>(mostradEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewStudent());
    }

	private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var objetoestudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new EditStudent(objetoestudiante));
	}
}
