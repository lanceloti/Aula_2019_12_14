using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aula_2019_12_14
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Command LogarCommand { get; set; }

        public MainPage()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(20, 60, 20, 20);
            }
            else
            {
                Padding = new Thickness(20);
            }

            BindingContext = this;

            Email = "leandro@lanceloti.com.br";
            Senha = "123123";

            LogarCommand = new Command(Logar);

            InitializeComponent();

            //Email.Text = "leandro@lanceloti.com.br";
            //Email.BackgroundColor = Color.Red;
            //Email.TextColor = Color.FromHex("fff");
        }

        async void Logar()
        {
            if (!string.IsNullOrEmpty(Email) && Email.ToLower() == "leandro@lanceloti.com.br" && !string.IsNullOrEmpty(Senha) && Senha == "123123")
            {
                Application.Current.MainPage = new NavigationPage(new Users());
            }
            else
            {
                await DisplayAlert("Erro...", "Dados inválidos!", "Ok");
            }
        }
    }
}
