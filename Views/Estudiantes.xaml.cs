using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace jgarrido_s5.Views;

public partial class Estudiantes : ContentPage
{
	private const string url = "http://10.2.12.7:8888/moviles/post.php";
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
}
