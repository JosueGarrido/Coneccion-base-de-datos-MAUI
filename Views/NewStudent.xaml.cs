using System.Collections.Specialized;
using System.Net;

namespace jgarrido_s5.Views;

public partial class NewStudent : ContentPage
{
	public NewStudent()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
	{
        try
        {
            WebClient cliente = new WebClient();

            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("cedula", txtCedula.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://10.2.12.7:8888/moviles/post.php", "POST", parametros);
            Navigation.PushAsync(new Estudiantes());
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");

        }
	}
		
}
