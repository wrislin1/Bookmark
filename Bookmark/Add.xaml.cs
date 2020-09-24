using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmark
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        
        public Add()
        {
            InitializeComponent();
            this.BindingContext = new Story();
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex == -1) return;
            var selectedItem = picker.Items[picker.SelectedIndex];
            switch (selectedItem)
            {
                case "Movie":
                    ctype.Text = "Director";
                    break;
                case "Podcast":
                    ctype.Text = "Creator";
                    break;
                case "Television":
                    ctype.Text = "Channel/Streaming Platform";
                    break;
                default:
                    ctype.Text = "Author";
                    break;
            }
        }

       async private void OnButtonClicked(object sender, EventArgs e)
        {
            var story = (Story)BindingContext;
            story.Type = picker.Items[picker.SelectedIndex];
            story.Started = started.Date;
            await App.Database.SaveItemAsync(story);
            await Navigation.PopAsync();
        }
    }
}