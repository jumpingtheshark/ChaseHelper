﻿using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Linq;


namespace ChaseHelper
{
    class ChaseProcessor
    {
		// todo sql load
		// todo transactions under/over forty
		// list highest hits over the last 30 days
		// total spending grouped by month intervals 
		// highest from each 2 week interval (goes along with the paycheck pattern)
		// dumping into sql tables- raw data (with and without bills)
		// table: daily summary spending (bills/no bills) 
		//table: bills only
		// table: weekly spending
		//	table bi-weekly spending
		// table: highest 10 purchases each month
		//  table: transactions over 40
		// table: clothing transactions
		// table: all food transactions (including coffee, starbucks, etc..) 
		// table: fast food transactions: starbucks, panera, etc.. 
		// list fees, tickets, etc...
		// non bill spending going backwards from most recent week by week 

       

        public List<Transaction> tl = new List<Transaction>();// starting unfiltered, may be filterd
		
        public string csvpath;
		public decimal debitSum;
		public decimal creditSum;
		public StringBuilder sb = new StringBuilder();// command line output
		Dictionary<string, string> bills;


		public ChaseProcessor(string path, string billsPath)
		{
			csvpath = path;
			sb.Append(DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString());
			sb.Append(Environment.NewLine);

			if (billsPath != "")
			{

				bills=Utils.Jsoner.dnr(billsPath);

			}


		}

		public void runMainReport( bool applyBillsFilter)
		{
			if (applyBillsFilter)
				applyFilter();

			daysDiscrete(-40);
			weeksDiscrete(-8);
			daysBack();
			monthlies();
			monthlyDetails(-8);

		}
		public void loadData()
        {
            
            List<string[]> ls = Utils.CSVHelper.csv2ListStringArray(csvpath);
            //string[] line;
            Transaction t;
            TransactionProcessor tp = new TransactionProcessor();
            bool header = true;
            foreach (string[] line in ls)
            {
                if (!header)
                {
                    t = tp.load(line);
                    tl.Add(t);
                }
                else
                    header = false;
            }


       // https://username:password@github.com/username/repository.git

        }

		private void writePeriod (StringBuilder sb, int daysback)
		{

		
			sb.Append(Environment.NewLine);
			sb.Append("Days Back: " + daysback.ToString());
			sb.Append(" \t");
			sb.Append ("Spent: " + debitSum.ToString("C"));
			sb.Append(" \t ");
			sb.Append("Earned: " + creditSum.ToString("C"));
			sb.Append(" \t ");
			sb.Append("Surplus: " + (creditSum + debitSum).ToString());		
		
			


		}

		public void monthlyDetails (int monthsBack )
		{
			sb.Append(Environment.NewLine);
			sb.Append(Environment.NewLine);
			sb.Append("discrete monthly details");
			sb.Append(Environment.NewLine);
			for (int i =0; i> monthsBack; i--)
			{
				sb.Append(Environment.NewLine);
				DateTime dt1 = DateTime.Now;
				DateTime dt2 = dt1.AddMonths(i);
				DateTime dt3 = new DateTime(dt2.Year, dt2.Month, 1);
				sb.Append(dt3.ToString("MMM"));
				sb.Append("\t");
				for (int j=1; j<5; j++)
				{
					DateTime dt4 = dt3.AddDays(6);
					TransactionSum(dt3, dt4);
					
					sb.Append(j.ToString() + "\t");

					sb.Append(debitSum.ToString("C") + "\t ");
					dt3 = dt4;

				}


			}

		}
		// rework this to show week by week instead of 7 day intervals, so that it's easier to compare the numbers.  
		public void weeksDiscrete(int weeksback)
		{
			sb.Append(Environment.NewLine);
			sb.Append(Environment.NewLine);
			sb.Append("Weeks Discrete: ");
			sb.Append(Environment.NewLine);

			for (int i = 0; i >=weeksback; i--)
			{
				DateTime dt = DateTime.Now.AddDays(i*7);

				DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				DateTime dt3 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				dt3 = dt3.AddDays(6).AddHours(23);

				TransactionSum(dt2, dt3);
				sb.Append(Environment.NewLine);
				sb.Append(dt.ToShortDateString() + ": \t  debits: " + debitSum.ToString("C") + "  \t credits: " + creditSum.ToString("C"));



			}


		}
		public void daysDiscrete (int daysback )
		{
			sb.Append(Environment.NewLine);
			sb.Append(Environment.NewLine);
			sb.Append("Days Discrete: ");
			sb.Append(Environment.NewLine);
					
		for (int i=0; i>=daysback; i--)
			{
				DateTime dt = DateTime.Now.AddDays(i);

				DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				DateTime dt3 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				dt3 = dt3.AddHours(23);
				TransactionSum(dt2, dt3);
				sb.Append(Environment.NewLine);
				sb.Append(dt.ToShortDateString() + ": \t  debits: " + debitSum.ToString("C") + "  \t credits: " + creditSum.ToString("C"));



			}


		}


		public void monthlies ()
		{
			for (int i = 0; i > -6; i--)
			{
				sb.Append(Environment.NewLine);
				DateInterval di = new DateInterval(i);
				TransactionSum(di.sdate, di.edate);
				sb.Append(di.sdate.ToString("MMM"));
				sb.Append(": \t ");
				sb.Append("debits: " + debitSum.ToString("C"));
				sb.Append(" \t credits: " + creditSum.ToString("C"));
				sb.Append(" \t" + "surplus: " + (creditSum + debitSum).ToString("C"));


			}



		}
		public void daysBack ()
		{
			// money spent and earned over the last 7, 14,  21 and 30 days
			// also, money spent on bills, and other stuff
			
			int daysback = -7;
			TransactionSum(daysback);
			sb.Append("Money Report: " + DateTime.Now.ToShortDateString());
			sb.Append(Environment.NewLine);
			sb.Append("Cumulatives: ");
			sb.Append(Environment.NewLine);
			writePeriod(sb, daysback);
			
			daysback = -14;
			TransactionSum(daysback);
			writePeriod(sb, daysback);
			daysback = -30;
			TransactionSum(daysback);
			writePeriod(sb, daysback);
			daysback = -60;
			TransactionSum(daysback);
			writePeriod(sb, daysback);
			daysback = -90;
			TransactionSum(daysback);
			writePeriod(sb, daysback);
			daysback = -180;
			TransactionSum(daysback);
			writePeriod(sb, daysback);

			sb.Append(Environment.NewLine);
			sb.Append("Monthlies:");
			sb.Append(Environment.NewLine);

			


		}



		public void getLatestBills()
		{
			// divide water by 3 since the village charges per season - or just exclude it all together? 
			// I feel like I should include it for a more compelete picture. 

			// todo - turn this into linq calls 
			List<Transaction> lb = new List<Transaction>();
			foreach (var bill in bills)
			{
				foreach (Transaction t  in tl)
				{
					if (
						t._02_description.ToLower().
						Contains(bill.Value.ToLower())
						&& 
						t._04_type != "FEE_TRANSACTION"
						)
						
					{
						var x = lb.Where(a => a._02_description.ToLower().Contains(bill.Value.ToLower()));
						if (x.Count()==0)
							lb.Add(new Transaction(t));
					}
								


				}
			}

			decimal billSum = 0;
			foreach (var t in lb)
			{
				sb.Append(t.toTabbedString());
				sb.Append(Environment.NewLine);
				billSum = billSum + t._03_amount;


			}


			sb.Append(Environment.NewLine);
			sb.Append ("Total bills:  \t\t \t\t\t " + billSum.ToString());

		}

		// to do - how to do an end with linq extension methods - if not, then use the syntax 
		public void applyFilter ()
		{
			foreach (var bill in bills)
			{
				if (bill.Value.Length > 2)
					{

					var c = tl
						.Where(
						f => f._02_description.ToLower()

						.Contains(bill.Value.ToLower()) == false
						
					
						)
						

						.ToList();

					tl = c;

				} 
   }


		}
	public void TransactionSum (DateTime sdate, DateTime edate)
		{
			// filter the list with linq;
			// take out online transfer, smart llc and whatever else, and mom's deposits?  
			debitSum = 0;
			creditSum = 0;

			var fl = tl.Where(f => f._02_description.ToLower().Contains("online transfer") == false)
				.Where(f => f._02_description.ToLower().Contains("atm checking transfer") == false)
				.Where(f => f._02_description.ToLower().Contains("atm savings transfer") == false)
				.Where(f => Utils.Dater.BetweenInclusive(sdate, edate, f.transDate));
			

			foreach (var fll in fl)
			{
				if (0 > fll._03_amount)
					debitSum = debitSum + fll._03_amount;
				else
					creditSum = creditSum + fll._03_amount;

			}



		}
		
		
  public void TransactionSum(int daysback )
		{
			debitSum = 0;
			creditSum = 0;

			foreach (var t in tl)
			
				if (
					 t.transDate > DateTime.Now.AddDays(daysback) 
					&&
					t._02_description.ToLower().Contains("online transfer")==false 

					//&&
					//t._02_description.ToLower().Contains("smart llc") == false
					)
				{
					if (0 > t._03_amount)
						debitSum = debitSum + t._03_amount;
					else
						creditSum = creditSum + t._03_amount;
				}
			

		}



    }
}
