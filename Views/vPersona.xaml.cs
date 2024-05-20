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

    
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        
        var selectedItem = (Persona)listaPersona.SelectedItem;
        var result = await DisplayAlert("Confirmar", "Estas seguro que quieres eliminar esta persona?", "Si", "No");

        if (result)
        {
            
            App.personRepo.DeletePerson(selectedItem);
            List<Persona> people = App.personRepo.GetAllPeople();
            listaPersona.ItemsSource = people;

        }
    }

    private async void btnEditar_Clicked(object sender, EventArgs e)
    {
        var selectedItem = (Persona)listaPersona.SelectedItem;
        var editPage = new EditPersonaPage(selectedItem);
        await Navigation.PushModalAsync(editPage);

        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;
    }
}