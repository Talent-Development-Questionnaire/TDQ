﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using TDQ.Models;
using Xamarin.Forms;

namespace TDQ
{
    public partial class MainPage : ContentPage
    {
        List<Questionnaire> Questionnaires;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (!string.IsNullOrEmpty(Utils.SavedSettings.LoginSettings))
            {
                Questionnaires = Classes.DatabaseController.GetQuestionnaires(Utils.SavedSettings.LoginSettings);
                LstQuestionnaire.ItemsSource = Questionnaires;
            }

            Classes.SettingsPageFunctions.SetBackground(ImgBg, MainContentPage);
            Classes.SettingsPageFunctions.ChangeTheme(Utils.SavedSettings.ThemeSettings);
        }

        private async void ImgBtnAddQuestionnaire_Clicked(object sender, EventArgs e)
        {
            ImgBtnAddQuestionnaire.IsEnabled = false;
            await Navigation.PushModalAsync(new PopupPages.AddQuestionnairePage(this));
            ImgBtnAddQuestionnaire.IsEnabled = true;
        }

        public void UpdateQuestionnareList()
        {
            if (!string.IsNullOrEmpty(Utils.SavedSettings.LoginSettings))
            {
                Questionnaires = Classes.DatabaseController.GetQuestionnaires(Utils.SavedSettings.LoginSettings);
                LstQuestionnaire.ItemsSource = Questionnaires;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Confirm Exit", "Are you sure you want to exit?", "Yes", "No");

                if (result)
                {
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow(); 
                }
            });
            return true;
        }

    }
}
