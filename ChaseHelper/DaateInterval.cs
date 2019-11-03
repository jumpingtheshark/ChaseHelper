using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseHelper
{
	public class DateInterval
	{
		public DateTime sdate;
		public DateTime edate;

		public DateInterval (int  months)
		{
			DateTime month = DateTime.Now.AddMonths(months);
			sdate = new DateTime(month.Year, month.Month, 1);
			edate = new DateTime(month.Year, month.Month, 1);
			edate = edate.AddMonths(1).AddDays(-1);


		}

	}

}
