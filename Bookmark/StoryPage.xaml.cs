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
    public partial class StoryPage : ContentPage
    {
        public StoryPage()
        {
            InitializeComponent();
        }

        private void OnFinishClicked(object sender, EventArgs e)
        {
            var story = (Story)BindingContext;
            story.IsFinished = 0;
            story.Finished = DateTime.Now;
        }
    }
}