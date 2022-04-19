using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AppCenter.Crashes;
using Plugin.Messaging;
using Psychologist.Core;
using Psychologist.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage 
    {
        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = DependencyInitializerCore.Container.Resolve<FeedbackViewModel>();
        }

        private void SendViaSMS(object sender, EventArgs e)
        {
            if (CrossMessaging.IsSupported && CrossMessaging.Current.SmsMessenger.CanSendSms)
            {
                string text = $"{Entry.Text}.";

                if (!string.IsNullOrEmpty(NameEntry.Text))
                {
                    text += $" С Уважением {NameEntry.Text}";
                }

                if (!string.IsNullOrEmpty(CityEntry.Text))
                    text += $" из {CityEntry.Text}";
                CrossMessaging.Current.SmsMessenger.SendSms("+992927772445", text);
            }
        }
    }
}