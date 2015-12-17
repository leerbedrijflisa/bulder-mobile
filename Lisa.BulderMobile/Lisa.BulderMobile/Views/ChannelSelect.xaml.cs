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
	public partial class ChannelSelect : ContentPage
	{
		public string partitionKey;

		public ChannelSelect (Channel selectedChannel)
		{
			InitializeComponent ();
			OnAppear (selectedChannel);
		}

		//waiting for GetMessages to fill the ListView
		protected async void OnAppear (Channel selectedChannel)
		{
			MessagesList.ItemsSource = await GetMessagesArgs(selectedChannel);

			MessagesList.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;
			};

		}

		//Filling variable
		private async Task<List<Message>> GetMessagesArgs (Channel selectedChannel)
		{
			partitionKey = selectedChannel.PartitionKey;
			return await GetMessages(partitionKey);

		}

		private async Task<List<Message>> GetMessages(string partitionKey)
		{
			using(var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://10.10.48.226:13693/");
		
				var result = await client.GetAsync("/messages/" + partitionKey);

				if(result.StatusCode == HttpStatusCode.OK)
				{
					var json = await result.Content.ReadAsStringAsync();

					var channels = JsonConvert.DeserializeObject<List<Message>>(json);

					return channels;

				} else {

					return null;

				}
			}
		}
	}
}

