using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lisa.BulderMobile
{
	public partial class ChannelOverview : ContentPage
	{
		public ChannelOverview ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			ChannelsList.ItemsSource = await GetChannels();
		}

		private async Task<List<Channel>> GetChannels()
		{
			using(var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://10.10.34.7:13693/");

				var result = await client.GetAsync("/channels/");

				if(result.StatusCode == HttpStatusCode.OK)
				{
					var json = await result.Content.ReadAsStringAsync();

					var channels = JsonConvert.DeserializeObject<List<Channel>>(json);

					return channels;
				} else {

					return null;
				}
			}
		}
	}
}

