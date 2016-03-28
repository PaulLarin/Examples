using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using ContactsShared;

namespace ContactsService.Actions
{
	public class ContactActions
	{
		private DataMock _data = new DataMock();


		public bool Update(Contact contact)
		{
			var toUpdate = _data.Contacts.FirstOrDefault(x => x.Id == contact.Id);

			if (toUpdate == null)
				return false;

			var ind = _data.Contacts.IndexOf(toUpdate);

			_data.Contacts.Insert(ind, contact);
			_data.Contacts.Remove(toUpdate);

			return true;
		}

		public bool Create(Contact contact)
		{
			_data.Contacts.Add(contact);

			return true;
		}

		public bool Remove(Guid id)
		{
			_data.Contacts.RemoveAll(x => x.Id == id);

			return true;
		}

		public Contact GetContact(Guid id)
		{
			return _data.Contacts.FirstOrDefault(x => x.Id == id);
		}

	

		public List<Contact> GetContacts(ContactFilterArgs filterArgs)
		{
			  var res = _data.Contacts.Where(x =>
				(string.IsNullOrWhiteSpace(filterArgs.FirstnameSearchText)
				 || x.FirstName.StartsWith(filterArgs.FirstnameSearchText, true, CultureInfo.CurrentCulture))
				&&
				(string.IsNullOrWhiteSpace(filterArgs.LastnameSearchText)
				 || x.LastName.StartsWith(filterArgs.LastnameSearchText, true, CultureInfo.CurrentCulture))
				&&
				(string.IsNullOrWhiteSpace(filterArgs.PatronymSearchText)
				 || x.Patronym.StartsWith(filterArgs.PatronymSearchText, true, CultureInfo.CurrentCulture))
				&&
				(string.IsNullOrWhiteSpace(filterArgs.ByPhoneSearchText)
				 || x.Phone.ToString().StartsWith(filterArgs.ByPhoneSearchText))
				);

			return res.ToList();
		}

	}
}
