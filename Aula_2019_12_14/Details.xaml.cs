using System;
using System.Collections.Generic;
using Aula_2019_12_14.Models;
using Xamarin.Forms;

namespace Aula_2019_12_14
{
    public partial class Details : ContentPage
    {
        public User User { get; set; }

        public Details(User user)
        {
            Title = user.Login;

            User = user;
            BindingContext = this;

            InitializeComponent();
        }
    }
}
