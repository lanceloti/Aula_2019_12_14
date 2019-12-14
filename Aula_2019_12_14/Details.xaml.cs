using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Aula_2019_12_14.Models;
using Aula_2019_12_14.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Aula_2019_12_14
{
    public partial class Details : ContentPage
    {
        public User User { get; set; }
        public ObservableCollection<Repository> Items { get; set; }

        public Details(User user)
        {
            Title = user.Login;

            User = user;
            Items = new ObservableCollection<Repository>();
            BindingContext = this;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CarregarDados();
        }

        async Task CarregarDados()
        {
            var url = $"https://api.github.com/users/{User.Login}/repos";
            var web = new HttpClientService();
            var json = await web.GetStringAsync(url);
            var users = JsonConvert.DeserializeObject<List<Repository>>(json);

            foreach (var user in users)
            {
                Items.Add(user);
            }

            if (Items.Count == 0)
            {
                Items.Add(new Repository() { Name = "Não há repositórios" });
            }
        }
    }
}
