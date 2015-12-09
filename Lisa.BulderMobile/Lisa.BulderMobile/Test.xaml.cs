using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace Lisa.BulderMobile
{
	public partial class Test : ContentPage
	{
		public Test ()
		{
			InitializeComponent ();
		}

		private async void GetMessages(object sender, EventArgs e)
		{
			using(var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://10.10.33.252:13693/");

				var result = await client.GetAsync("/messages/AAA/");

				if(result.StatusCode == HttpStatusCode.OK)
				{
					var json = await result.Content.ReadAsStringAsync();

					var messages = JsonConvert.DeserializeObject<IEnumerable<Message>>(json);

					foreach(var message in messages)
					{
						TeacherPicker.Items.Add(message.Text);
					}
				}
			}
		}
	}
}

