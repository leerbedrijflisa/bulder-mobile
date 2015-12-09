using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lisa.BulderMobile
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
			MainPage = new NavigationPage (new ChannelOverview());
        }

}
