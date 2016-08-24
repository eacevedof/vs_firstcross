/*
 * @file \nsfirstapp\nsfirstapp\app.cs 1.0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using NsFirstapp.views;
namespace NsFirstapp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new ViewHomepage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }//App
}//NsFirstapp
