using ContactsDatalayer;
using ContactsDatalayer.ContactsService;

namespace ContactsClient
{
	public class ServicesClientsFactory
	{
		private static ContactsServiceClientWrapper contactsService = new ContactsServiceClientWrapper();
		public static ContactsServiceClientWrapper GetContactsService()
		{
			return contactsService;
		}
	}
}