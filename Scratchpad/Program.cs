using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Scratchpad
{
	class Program
	{
		static void Main(string[] args)
		{

			//first thing, get an end on 



		}




		class Account 
		{
			// todo: sort charges by date desc, and use only linq to pick out the very first bill and add it to a new list of charges
			// this will avoid using the loop in my main projet 
			
			// use a wher with linq to   
			public List<Transaction> lt = new List<Transaction>();
			Account()
			{
				lt.Add(new Transaction { amount = 22, merchant = "starbucks", tdate = 1, ttype = "charge" });
				lt.Add(new Transaction { amount = 100, merchant = "bestbuy", tdate = 2, ttype = "charge" });
				lt.Add(new Transaction { amount = 34, merchant = "nsf", tdate = 3, ttype = "fee" });



				lt = lt.Where(a => a.amount > 10 && a.ttype != "fee").ToList();


			}



			}



		class Transaction
		{


			public int tdate { get; set; }
			public string merchant { get; set; }

			public decimal amount { get; set; };

			
		// fee or charge for simplicity 
			public string ttype { get; set; }





		}

	}