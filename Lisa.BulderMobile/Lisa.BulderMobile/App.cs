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
			MainPage = new NavigationPage (new ChannelOverview());
        }
	
	}
}
