using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseHelper
{
    public class Transaction
    {
		public Transaction(Transaction t)
		{

			_00_details = t._00_details;

			_01_datestring = t._01_datestring;
			_02_description = t._02_description;
			_03_amount= t._03_amount;
			_04_type= t._04_type;
			_05_balance= t._05_balance;
			_06_checknumber= t._06_checknumber;
			transDate = t.transDate;



		}
		public Transaction()
		{}// default constructor that does pretty much nothign 


		public string toTabbedString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(_01_datestring);
			sb.Append('\t');
			sb.Append(_02_description.Substring(0, 25));
			sb.Append('\t');
			sb.Append(_03_amount);

			return sb.ToString();


		}

		public string   _00_details { get; set; }
        public string   _01_datestring {  get; set;  }
        public string   _02_description { get; set; }
        public decimal  _03_amount;
        public string   _04_type;
        public decimal  _05_balance;
        public string   _06_checknumber;
		public DateTime transDate;
        



    }
}
