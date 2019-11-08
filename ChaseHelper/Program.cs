using System;
using Utils;
using System.Linq;
// to do - make a bills list  (read in from json)
// make an exclude list
// make an or include list 
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

			cp.applyFilter();

			cp.daysDiscrete(-40);
			cp.weeksDiscrete(-8);
			cp.daysBack();
			cp.monthlies();
			
			cp.monthlyDetails(-8);
			Console.WriteLine(cp.sb.ToString());
			Utils.Filer.writeAllText(@"c:\a2\" +DateTime.Now.Ticks.ToString()+".txt", cp.sb.ToString());
			Console.ReadLine();
			
			

			
			
        }
    }
}
