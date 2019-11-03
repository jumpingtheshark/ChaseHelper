using System;
using Utils;
// current utils: C:\Users\Michael\source\repos\Utils\Utils\bin\Debug\netcoreapp2.2
// email sarah hilby about Anna's soccer
// order mud boots
namespace ChaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            ChaseProcessor cp = new ChaseProcessor(@"c:\a2\f.csv");
             
            cp.loadData();
			cp.standardReport();

			Console.ReadLine();
			
			/*
			int daysback = -30;
			cp.TransactionSum(daysback);
			Console.WriteLine("Days Back: " + daysback.ToString());
			Console.WriteLine("Spent: " + cp.debitSum.ToString());
			Console.WriteLine("Earned: " + cp.creditSum.ToString());
			Console.ReadLine();
			*/
			
        }
    }
}
