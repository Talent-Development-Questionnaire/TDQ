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
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();
        }

        private async void ImgBtnAddGroup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddGroupPage());
        }
    }
}