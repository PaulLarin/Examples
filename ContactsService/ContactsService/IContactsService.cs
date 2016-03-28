using System;
using System.Collections.Generic;
using System.ServiceModel;
using ContactsShared;

namespace ContactsService
{
	[ServiceContract]
	public interface IContactsService
	{
		[OperationContract]
		Contact GetContact(Guid id);

		[OperationContract]
		List<Contact> GetContacts(ContactFilterArgs filterArgs);

		[OperationContract]
		bool Update(Contact contact);

		[OperationContract]
		bool Create(Contact contact);

		[OperationContract]
		bool Remove(Guid id);
	}
}
