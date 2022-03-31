using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Psychologist.Core;
using Psychologist.Core.ViewModels;
using Xamarin.Forms;
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
    }
}