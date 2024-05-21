using System.Text;
using Newtonsoft.Json;

namespace jgarrido_s5.Views;

public partial class EditStudent : ContentPage
{
	public EditStudent(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtCedula.Text = datos.cedula.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    codigo = txtCodigo.Text,
                    cedula = txtCedula.Text,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    edad = txtEdad.Text
                }), Encoding.UTF8, "application/json");

                var response = await client.PutAsync("http://192.168.1.6:8888/moviles/post.php", content);

                if (response.IsSuccessStatusCode)
                {
                    await Navigation.PushAsync(new Estudiantes());
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Alerta", $"Error al actualizar el estudiante: {responseString}", "Cerrar");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"http://192.168.1.6:8888/moviles/post.php?codigo={txtCodigo.Text}");

                if (response.IsSuccessStatusCode)
                {
                    await Navigation.PushAsync(new Estudiantes());
                }
                else
                {
                    await DisplayAlert("Alerta", "Error al eliminar el estudiante", "Cerrar");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}
