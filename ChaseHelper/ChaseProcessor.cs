using System;
using System.Collections.Generic;
using System.Text;
using Utils;


namespace ChaseHelper
{
    class ChaseProcessor
    {

        public ChaseProcessor (string path)
        {
            csvpath = path;


        }

        public List<Transaction> tl = new List<Transaction>();
        public string csvpath;
		public decimal debitSum;
		public decimal creditSum;

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
			sb.Append(" ");
			sb.Append ("Spent: " + debitSum.ToString("C"));
			sb.Append("  ");
			sb.Append("Earned: " + creditSum.ToString("C"));
			sb.Append("  ");
			sb.Append("Surplus: " + (creditSum + debitSum).ToString());		
			sb.Append(Environment.NewLine);
			


		}

		public void standardReport ()
		{
			// money spent and earned over the last 7, 14,  21 and 30 days
			// also, money spent on bills, and other stuff
			StringBuilder sb = new StringBuilder();
			int daysback = -7;
			TransactionSum(daysback);
			sb.Append("Money Report: " + DateTime.Now.ToShortDateString());
			sb.Append(Environment.NewLine);
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

			Console.WriteLine(sb);




			//int daysback = -30;
			//cp.TransactionSum(daysback);
			//Console.WriteLine("Days Back: " + daysback.ToString());
			//Console.WriteLine("Spent: " + cp.debitSum.ToString());
			//Console.WriteLine("Earned: " + cp.creditSum.ToString());
			//Console.ReadLine();

		}

		public void TransactionSum(int daysback)
		{
			debitSum = 0;
			creditSum = 0;

			foreach (var t in tl)
			
				if (
					 t.transDate > DateTime.Now.AddDays(daysback) 
					&&
					t._02_description.ToLower().Contains("online transfer")==false 
					&&
					t._02_description.ToLower().Contains("smart llc") == false
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
