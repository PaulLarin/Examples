using System;
using System.Windows.Input;
using ContactsClient.Commands;
using ContactsShared;

namespace ContactsClient.ViewModel
{
	public class ContactItemViewModel
	{
		private readonly Contact _contact;

		public ContactItemViewModel(Contact contact)
		{
			_contact = contact;
		}

		public Guid Id { get { return _contact.Id; } }

		public bool IsNew { get; private set; }

		public string FirstName
		{
			get { return _contact.FirstName; }
			set { _contact.FirstName = value; }
		}

		public string LastName
		{
			get { return _contact.LastName; }
			set { _contact.LastName = value; }
		}

		public string Patronym
		{
			get { return _contact.Patronym; }
			set { _contact.Patronym = value; }
		}

		public long Phone
		{
			get { return _contact.Phone; }
			set { _contact.Phone = value; }
		}

		public ICommand SaveCommand => new RelayCommand(_ =>
		{
			var result = IsNew
				? ServicesClientsFactory.GetContactsService().Create(_contact)
				: ServicesClientsFactory.GetContactsService().Update(_contact);
		});

		public Contact Contact
		{
			get { return _contact; }
		}


		public static ContactItemViewModel CreateNew()
		{
			return new ContactItemViewModel(new Contact() { Id = Guid.NewGuid() }) { IsNew = true };
		}

		public static ContactItemViewModel CreateNew(Contact contact)
		{
			return new ContactItemViewModel(contact) { IsNew = true };
		}
	}
}