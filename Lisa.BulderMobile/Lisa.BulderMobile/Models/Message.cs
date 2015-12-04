using System;

namespace Lisa.BulderMobile
{
	public class Message
	{
		public string Text { get; set; }
		public string Author { get; set; }
		public string PartitionKey { get; set; }
		public string RowKey { get; set; }
		public DateTime TimeStamp { get; set; }
		public string ETag { get; set; }
	}
} 

