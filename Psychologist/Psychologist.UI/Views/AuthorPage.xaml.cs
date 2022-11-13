using System;
using Autofac;
using Psychologist.Core;
using Psychologist.Core.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage
    {
        public AuthorPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = DependencyInitializerCore.Container.Resolve<AuthorViewModel>();
        }

        private async void EmailTapGesture(object sender, EventArgs e)
        {
            try
            {
                await Email.ComposeAsync(string.Empty, string.Empty, "shukhratjoni@gmail.com");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void PhoneTapGesture(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("+992927772445");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private async void InstagramTapGesture(object sender, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync("https://www.instagram.com/shukhratjoni/");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void TelegramOpen(object sender, EventArgs e)
        {
            try
            {
                Launcher.OpenAsync("https://t.me/ShukhratIbragimov");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void WhatsappOpen(object sender, EventArgs e)
        {
            try
            {
                Launcher.OpenAsync("https://wa.me/992927772445");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}