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
			return Call(() => Service.GetContact(id));
		}

		public Contact GetContactByPhone(string phone)
		{
			return Call(() => Service.GetContactByPhone(phone));
		}

		public bool Update(Contact contact)
		{
			return Call(() => Service.Update(contact));
		}

		public bool Create(Contact contact)
		{
			return Call(() => Service.Create(contact));
		}

		public bool Remove(Guid id)
		{
			return Call(() => Service.Remove(id));
		}

		public List<Contact> GetContacts(ContactFilterArgs filterArgs)
		{
			return Call(() => Service.GetContacts(filterArgs));
		}

		private T Call<T>(Func<T> func) where T : new()
		{
			try
			{
				return func.Invoke();
			}
			catch (Exception ex)
			{
                // exception handling logic
				throw ex;
			}
		}
	}
}