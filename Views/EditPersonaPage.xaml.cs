using jgarrido_s5.Modelos;

namespace jgarrido_s5.Views;

public partial class EditPersonaPage : ContentPage
{

    private Persona _persona;
    public EditPersonaPage(Persona persona)
	{
		InitializeComponent();
        _persona = persona;
        txtPersona.Text = persona.Name;
        
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        _persona.Name = txtPersona.Text;
        App.personRepo.EditPerson(_persona);
        await Navigation.PopModalAsync();
    }
}
