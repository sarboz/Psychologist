using Psychologist.Core.Abstractions;
using ReactiveUI;
using Xamarin.Forms;

namespace Psychologist.UI.Abstractions
{
    public class BaseContentPage<TViewModel> : ContentPage, IViewFor<TViewModel> where TViewModel : BaseViewModel
    {
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => BindingContext = ViewModel = value as TViewModel;
        }

        public TViewModel ViewModel { get; set; }

        private bool isInited;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!isInited)
                ViewModel?.ViewInitialized();
            isInited = true;
            if (!string.IsNullOrEmpty(ViewModel?.Title))
                Title = ViewModel?.Title;
        }
    }
}