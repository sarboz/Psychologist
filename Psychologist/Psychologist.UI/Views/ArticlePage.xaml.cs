using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlePage
    {
        public ArticlePage()
        {
            InitializeComponent();
        }

        private HtmlWebViewSource _sourse = new ();
        public int FontSize { get; set; } = 25;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel != null)
            {
                _sourse.Html =
                    $"<header><meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no'><style>img{{max-width:100%}}</style></header><body><div style='text-align: justify;text-indent: 20px; font-size: {FontSize}px'>" +
                    ViewModel.Article.Content + "</div></body>";
                WebView.Source = _sourse;
            }

            WebView.Reload();
        }
    }
}