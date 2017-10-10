using System;
using WhenActivatedIssue.Views;
using Xamarin.Forms;

namespace WhenActivatedIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new FirstPage();
            else
                MainPage = new NavigationPage(new FirstPage());
        }
    }
}
