using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Aula_2019_12_14.Models;
using Aula_2019_12_14.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aula_2019_12_14
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users : ContentPage
    {
        public ObservableCollection<User> Items { get; set; }

        public Users()
        {
            BindingContext = this;

            Items = new ObservableCollection<User>();
            //Items.Add(new User() { Login = "Lanceloti" });
            //Items.Add(new User() { Login = "Lucas" });

            InitializeComponent();
        }

        void MudoOTexto(SearchBar sender, TextChangedEventArgs e)
        {
            CarregarDados(e.NewTextValue);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async Task CarregarDados(string busca)
        {
            var url = "https://api.github.com/search/users?q=" + busca;
            var web = new HttpClientService();
            var json = await web.GetStringAsync(url);

            var s = new { Items = new List<User>() };
            var users = JsonConvert.DeserializeAnonymousType(json, s);

            Items.Clear();

            foreach (var user in users.Items)
            {
                Items.Add(user);
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var user = (User)e.Item;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new Details(user));
        }
    }
}
