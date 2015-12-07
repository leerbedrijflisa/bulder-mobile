using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace Lisa.BulderMobile
{
	public partial class ChannelOverview : ContentPage
	{
		public ChannelOverview ()
		{
			InitializeComponent ();
		}

		private async void GetChannels(object sender, EventArgs e)
		{
			using(var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://10.10.33.228:13693/");

				var result = await client.GetAsync("/channels/");

				if(result.StatusCode == HttpStatusCode.OK)
				{
					var json = await result.Content.ReadAsStringAsync();

					var channels = JsonConvert.DeserializeObject<IEnumerable<Channel>>(json);

					foreach(var channel in channels)
					{
						TeacherPicker.Items.Add(channel.Name);
					}
				}
			}
		}
	}
}

