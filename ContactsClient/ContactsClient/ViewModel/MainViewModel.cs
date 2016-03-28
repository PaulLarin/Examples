namespace ContactsClient.ViewModel
{
	public class MainViewModel
	{
		public MainViewModel()
		{
			ContactsCatalogViewModel = new ContactsCatalogViewModel();
		}

		public ContactsCatalogViewModel ContactsCatalogViewModel { get; set; }
	}
}