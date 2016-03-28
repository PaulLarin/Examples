using System;
using System.Collections.Generic;
using ContactsShared;

namespace ContactsService.Actions
{
	public class DataMock
	{
		private static List<Contact> _contacts = new List<Contact>()
		{
			new Contact() {Id=new Guid("cdafb59e-f0ee-41b3-bbbb-8cd02c1bc646"), FirstName = "Киррил", LastName = "Третьяков", Patronym = "Аксонович", Phone = 1597894523},
			new Contact() {Id=new Guid("a81f8399-e814-4397-9357-cedef564cb3b"), FirstName = "Трифон", LastName = "Тетрайдер", Patronym = "Ксанталович", Phone=9518794523},
			new Contact() {Id=new Guid("56069799-2ca1-4218-886e-433246cf6414"), FirstName = "Актиния", LastName = "Патрицева", Patronym = "Алексеевна", Phone =4561234578},
			new Contact() {Id=new Guid("9b069788-c4cd-460e-b74e-eec7740bb38e"), FirstName = "Алексей", LastName = "Суровер",  Patronym = "Дмитриевич", Phone = 9845612345},
			new Contact() {Id=new Guid("10c8c011-2763-476f-b6e7-a19daf22c8b6"), FirstName = "Василий", LastName = "Анаксимен",  Patronym = "Петрович", Phone =1594562389},
			new Contact() {Id=new Guid("0f4a448e-ed05-4027-9c28-4455c5e483b5"), FirstName = "Игорь", LastName = "Дружинин", Patronym = "Анаксимандрович", Phone =7891594589},
			new Contact() {Id=new Guid("dd3c3921-9244-4f58-8ddc-d969e9aea62f"), FirstName = "Петр", LastName = "Васильев",  Patronym = "Петрович", Phone = 6543218945},
			new Contact() {Id=new Guid("b2855fd3-cefc-4e53-a0fb-b92c97f35796"), FirstName = "Милитарий", LastName = "Викторов",  Patronym = "Витальевич", Phone =1597856456},
			new Contact() {Id=new Guid("3d42c604-9e68-4197-a0e6-3cece8346386"), FirstName = "Анаксагор", LastName = "Полиморфов", Patronym = "Геродотович", Phone =1594578687},
		};

		public List<Contact> Contacts
		{
			get { return _contacts; }
			set { _contacts = value; }
		}
	}
}










