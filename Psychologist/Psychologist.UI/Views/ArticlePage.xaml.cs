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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel != null)
            {
                var htmlSource = new HtmlWebViewSource
                {
                    Html = "<div style='text-align: justify;text-indent: 20px;'>" + ViewModel.Article.Content + "</div>"
                };
                WebView.Source = htmlSource;
            }
        }
    }
}