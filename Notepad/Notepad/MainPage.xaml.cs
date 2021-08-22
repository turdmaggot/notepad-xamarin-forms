using Notepad.Repositories;
using Notepad.ViewModels;
using System;
using Xamarin.Forms;

namespace Notepad
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var vm = new MainPageViewModel(new InMemoryNoteRepository());
            BindingContext = vm;
        }
    }
}
