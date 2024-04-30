using jgarrido_s5.Modelos;

namespace jgarrido_s5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		statusMessage.Text = "";

		App.personRepo.addNewPerson(txtPersona.Text);
		statusMessage.Text = App.personRepo.StatusMessage;
    }

	private void btnObtener_Clicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";

		List<Persona> people = App.personRepo.GetAllPeople();
		listaPersona.ItemsSource = people;

	}
}