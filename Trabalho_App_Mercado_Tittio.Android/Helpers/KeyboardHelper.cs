using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_App_Mercado_Tittio.Droid.Helpers;
using Trabalho_App_Mercado_Tittio.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(KeyboardHelper))]
namespace Trabalho_App_Mercado_Tittio.Droid.Helpers
{
    public class KeyboardHelper : IKeyboard
    {
        public void HideKeyboard()
        {
            var context = Forms.Context;
            var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null && context is Activity)
            {
                var activity = context as Activity;
                var token = activity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                activity.Window.DecorView.ClearFocus();
            }
        }
    }
}