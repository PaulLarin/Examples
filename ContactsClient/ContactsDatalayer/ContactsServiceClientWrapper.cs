using System;
using System.Collections.Generic;
using ContactsDatalayer.ContactsService;
using ContactsShared;
using IContactsService = ContactsDatalayer.ContactsService.IContactsService;

namespace ContactsDatalayer
{
	public class ContactsServiceClientWrapper : ContactsService.IContactsService
	{
		private ContactsService.IContactsService _contactsService;
		
		private IContactsService Service
		{
			get
			{
				if (_contactsService == null)
					try
					{
						_contactsService = new ContactsServiceClient();
					}
					catch (Exception)
					{ }

				return _contactsService;
			}
		}

		public Contact GetContact(Guid id)
		{
			return SafeCall(() => Service.GetContact(id));
		}

		public Contact GetContactByPhone(string phone)
		{
			return SafeCall(() => Service.GetContactByPhone(phone));
		}

		public bool Update(Contact contact)
		{
			return SafeCall(() => Service.Update(contact));
		}

		public bool Create(Contact contact)
		{
			return SafeCall(() => Service.Create(contact));
		}

		public bool Remove(Guid id)
		{
			return SafeCall(() => Service.Remove(id));
		}

		public List<Contact> GetContacts(ContactFilterArgs filterArgs)
		{
			return SafeCall(() => Service.GetContacts(filterArgs));
		}

		private T SafeCall<T>(Func<T> func) where T : new()
		{
			try
			{
				return func.Invoke();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return new T();
		}
	}
}