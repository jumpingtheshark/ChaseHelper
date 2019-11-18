using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseHelper.ReportDataObjects
{
	public class SpendingInterval
	{
		public string description { get; set; }
		public DateTime sdate { get; set; }
		public string sdateString { get; set; }


		public DateTime edate { get; set; }
		public string edateString { get; set; }

		public Decimal debit { get; set; }

		public Decimal credit { get; set; }

	}
}
