using System.Collections.Generic;

namespace Entities
{
	public class Contact
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string EmailAddress { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual IList<Project> Projects { get; set; }

		public Contact()
		{
			Projects = new List<Project>();
		}
	}
}