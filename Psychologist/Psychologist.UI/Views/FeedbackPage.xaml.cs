using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }

        private void SendViaSMS(object sender, EventArgs e)
        {
            if (CrossMessaging.IsSupported && CrossMessaging.Current.SmsMessenger.CanSendSms)
                CrossMessaging.Current.SmsMessenger.SendSms("+992927772445", Entry.Text);
        }
    }
}