using System;
using Utils;
using System.Linq;

// to do - make a bills list  (read in from json)
// install ssms to work with sql 
// get settings like path from app.json instead of hard coded 
// make an upload button and write endpoints
// also.. dump this into cloud sql 
namespace ChaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {


			

   
			ChaseProcessor cp = new ChaseProcessor(@"c:\a2\f.csv", @"c:\a2\bills.json");
             
            cp.loadData();
			cp.getLatestBills();
			

			
			Console.WriteLine(cp.sb.ToString());
			Utils.Filer.writeAllText(@"c:\a2\" + Dater.TimeStamp()+"Bills.txt", cp.sb.ToString());

			Console.WriteLine("any key for general report");
			Console.ReadLine();

			cp.sb = new System.Text.StringBuilder();

			cp.runMainReport(true);


			Console.WriteLine(cp.sb.ToString());
			Utils.Filer.writeAllText(@"c:\a2\" + Dater.TimeStamp() + "Mainreport.txt", cp.sb.ToString());




		}
    }
}
