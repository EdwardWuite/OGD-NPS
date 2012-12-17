using System;

namespace Entities
{
	public class ActionLog
	{
		public virtual int Id { get; set; }
		public virtual string AccountManagerName { get; set; }
		public virtual string CustomerName { get; set; }
		public virtual string ProjectName { get; set; }
		public virtual string ContactName { get; set; }
		public virtual bool Finished { get; set; }
		public virtual DateTime ActionDate { get; set; }
	}
}