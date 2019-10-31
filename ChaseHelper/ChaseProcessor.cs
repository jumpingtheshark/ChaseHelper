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
