using System;
using System.Runtime.Serialization;

namespace ContactsShared
{
	[DataContract]
	public class Contact
	{
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public string Patronym { get; set; }

		[DataMember]
		public long Phone { get; set; }
	}
}