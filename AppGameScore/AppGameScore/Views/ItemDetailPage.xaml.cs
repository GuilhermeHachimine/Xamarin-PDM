using AppGameScore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppGameScore.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}