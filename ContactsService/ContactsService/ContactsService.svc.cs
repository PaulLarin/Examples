using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContactsService.Actions;
using ContactsShared;

namespace ContactsService
{
	public class ContactsService : IContactsService
	{
		private readonly ContactActions _actions = new ContactActions();

		public List<Contact> GetContacts(ContactFilterArgs filterArgs)
		{
			return _actions.GetContacts(filterArgs);
		}

		public Contact GetContact(Guid id)
		{
			return _actions.GetContact(id);
		}

		public bool Update(Contact contact)
		{
			return _actions.Update(contact);
		}

		public bool Create(Contact contact)
		{
			return _actions.Create(contact);
		}

		public bool Remove(Guid id)
		{
			return _actions.Remove(id);
		}
	}
}
