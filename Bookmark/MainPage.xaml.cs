using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bookmark
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       async private void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Add());
        }

       async private void OnListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List());
        }

       async private void OnMetricsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Metrics());
        }
    }
}
