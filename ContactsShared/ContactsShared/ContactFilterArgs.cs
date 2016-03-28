using System.Runtime.Serialization;

namespace ContactsShared
{
	[DataContract]
	public class ContactFilterArgs
	{
		[DataMember]
		public string LastnameSearchText { get; set; }

		[DataMember]
		public string FirstnameSearchText { get; set; }

		[DataMember]
		public string PatronymSearchText { get; set; }

		[DataMember]
		public string ByPhoneSearchText { get; set; }
	}
}