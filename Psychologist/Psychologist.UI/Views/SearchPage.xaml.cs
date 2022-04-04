﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage 
    {
        public SearchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchView.Focus();
        }
    }
}