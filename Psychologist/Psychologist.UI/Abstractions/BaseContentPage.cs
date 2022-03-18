using Psychologist.Core.Abstractions;
using ReactiveUI;
using Xamarin.Forms;

namespace Psychologist.UI.Abstractions
{
    public class BaseContentPage<TViewModel>:ContentPage,IViewFor<TViewModel> where TViewModel:BaseViewModel
    {
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => BindingContext = ViewModel = value as TViewModel;
        }
        public TViewModel ViewModel { get; set; }
        
    }
}