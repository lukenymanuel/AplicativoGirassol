using MAUI.Repository;
using MAUI.Model;
namespace MAUI;

public partial class LoginPage : ContentPage
{
    readonly IAlunoRepository alunoRepository = new AlunoServices();
    
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Login_Btn_Clicked(object sender, EventArgs e)
    {
        try
        {
            string username = Entry_Username.Text;
           
            string password = Entry_Password.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                return;
            }

            Aluno aluno = await alunoRepository.Login(username, password);
            if (aluno == null)
            {
                await DisplayAlert("Error", "Credentials are incorrect", "Ok");
                return;
            }
            await Navigation.PushAsync(new MainPage());
            await DisplayAlert("Login", "Successfully logged in", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Login", ex.Message, "Ok");
        }
    }

}