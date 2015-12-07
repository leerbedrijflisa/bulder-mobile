using System;

namespace Lisa.BulderMobile
{
	public class Channel
	{
		public string Administrators { get; set; }
		public string Authors { get; set; }
		public string Name { get; set; }
		public string PartitionKey { get; set; }
		public string RowKey { get; set; }
		public DateTime Timestamp { get; set; }
		public string Etag { get; set; }
	}
}


