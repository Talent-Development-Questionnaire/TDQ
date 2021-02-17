﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var result = Classes.DatabaseController.AccountCheck(EntryEmail.Text, EntryPassword.Text);

            if (result == true)
            {
                Utils.SavedSettings.LoginSettings = "LoggedIn";
                (Application.Current).MainPage = new Navigation_Drawer_Logged_In();
            }
            else
                await DisplayAlert("Account", "Account does not exist, please try again.", "OK");
        }
    }
}