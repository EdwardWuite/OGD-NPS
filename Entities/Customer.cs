using System.Collections.Generic;

namespace Entities
{
	public class Customer
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IList<Project> Projects { get; set; }
		public virtual IList<Contact> Contacts { get; set; }

		public Customer()
		{
			Projects = new List<Project>();
			Contacts = new List<Contact>();
		}
	}
}