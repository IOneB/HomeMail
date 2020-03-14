using HomeMail.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeMail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Addresses : ContentPage
    {
        public AddressesViewModel Model { get; set; }

        public Addresses()
        {
            InitializeComponent();
            Model = new AddressesViewModel();

            this.BindingContext = Model;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Model.Add(input.Text);
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            var parent = ((Button)sender)?.Parent;
            if (parent is StackLayout stackLayout)
            {
                var children = stackLayout?.Children?.FirstOrDefault(x => x is Label) as Label;
                EmailsListView.SelectedItem = EmailsListView.ItemsSource.Cast<string>()?.FirstOrDefault(x => x == children.Text);
            }

            Model.Remove(EmailsListView.SelectedItem?.ToString());
        }
    }
}