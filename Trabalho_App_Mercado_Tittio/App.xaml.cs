﻿using System;
using Trabalho_App_Mercado_Tittio.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoadPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
