using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Input;
using ContactsClient.Commands;
using ContactsDatalayer.ContactsService;
using ContactsShared;

namespace ContactsClient.ViewModel
{
	public class ContactsCatalogViewModel : BaseViewModel
	{

		private ContactItemViewModel _selectedItem;
		private ContactItemViewModel _contactUnderEdit;

		private List<Contact> _cache;
		private readonly ContactFilterArgs _filterArgs;

		private ICommand _saveCommand;
		private ICommand _removeCommand;
		private ICommand _addCommand;

		public void Refresh()
		{
			try
			{
				_cache = ServicesClientsFactory.GetContactsService().GetContacts(_filterArgs);
				Contacts.Clear();

				_cache.ForEach(c => Contacts.Add(new ContactItemViewModel(c)));
				IsServiceUnavailable = false;
			}
			catch (EndpointNotFoundException ex)
			{
				IsServiceUnavailable = true;
			}

			RaisePropertyChanged("IsServiceUnavailable");
		}

		public ContactsCatalogViewModel()
		{
			_filterArgs = new ContactFilterArgs();

			Contacts = new ObservableCollection<ContactItemViewModel>();

			Refresh();
		}

		public ObservableCollection<ContactItemViewModel> Contacts { get; private set; }

		public string LastnameSearchText
		{
			get { return _filterArgs.LastnameSearchText; }
			set
			{
				if (_filterArgs.LastnameSearchText == value)
					return;

				_filterArgs.LastnameSearchText = value;

				Refresh();
			}
		}
		public string FirstnameSearchText
		{
			get { return _filterArgs.FirstnameSearchText; }
			set
			{
				if (_filterArgs.FirstnameSearchText == value)
					return;

				_filterArgs.FirstnameSearchText = value;

				Refresh();
			}
		}
		public string PatronymSearchText
		{
			get { return _filterArgs.PatronymSearchText; }
			set
			{
				if (_filterArgs.PatronymSearchText == value)
					return;

				_filterArgs.PatronymSearchText = value;

				Refresh();
			}
		}

		public string ByPhoneSearchText
		{
			get { return _filterArgs.ByPhoneSearchText; }
			set
			{
				if (_filterArgs.ByPhoneSearchText == value)
					return;

				_filterArgs.ByPhoneSearchText = value;

				Refresh();
			}
		}

		public ContactItemViewModel SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (value == _selectedItem)
					return;

				_selectedItem = value;

				SetSelectedItemForEdit();

				RaisePropertyChanged("SelectedItem");
			}
		}

		public ContactItemViewModel ContactUnderEdit
		{
			get { return _contactUnderEdit; }
			set
			{
				if (value == _contactUnderEdit)
					return;

				_contactUnderEdit = value;
				RaisePropertyChanged("ContactUnderEdit");
			}
		}

		public bool IsServiceUnavailable { get; private set; }

		public void SetSelectedItemForEdit()
		{
			if (_selectedItem == null)
			{
				ContactUnderEdit = null;
				return;
			}

			if (_selectedItem.IsNew)
			{
				ContactUnderEdit = ContactItemViewModel.CreateNew(_selectedItem.Contact);
				return;
			}

			var contact = ServicesClientsFactory.GetContactsService().GetContact(_selectedItem.Id);

			if (contact == null)
				return;

			ContactUnderEdit = new ContactItemViewModel(contact);
		}


		public ICommand SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new RelayCommand(_ =>
				{
					if (ContactUnderEdit == null)
						return;

					ContactUnderEdit.SaveCommand.Execute(null);
					Refresh();
				}));
			}
		}

		public ICommand RemoveCommand
		{
			get
			{
				return _removeCommand ?? (_removeCommand = new RelayCommand(_ =>
				{
					if (SelectedItem.IsNew)
						Contacts.Remove(SelectedItem);
					else
						ServicesClientsFactory.GetContactsService().Remove(SelectedItem.Id);

					Refresh();
				}));
			}
		}

		public ICommand AddCommand
		{
			get
			{
				return _addCommand ?? (_addCommand = new RelayCommand(_ =>
				{
					var newItem = ContactItemViewModel.CreateNew();
					Contacts.Add(newItem);
					SelectedItem = newItem;
				}));
			}
		}
	}
}