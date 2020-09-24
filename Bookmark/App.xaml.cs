using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmark
{
    public partial class App : Application
    {
        static BookmarkDB database;
        public static BookmarkDB Database 
        {
            get
            {
                if (database == null)
                    database = new BookmarkDB();
                return database;
            }
            
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
