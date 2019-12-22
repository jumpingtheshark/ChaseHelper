using System;
using Utils;
using System.Linq;
using System.IO;
using System.Collections.Generic;

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



			string configFolder = args[0];

			Dictionary<string, string> settings = Utils.Jsoner.dnr(configFolder);
			
   
			ChaseProcessor cp = new ChaseProcessor
				(
					settings["baseFolder"],
					settings["csv"],
					settings["bills"]
				);
             
            cp.loadData();


			var cw = new ChaseWriter(cp);
			cw.
			//cp.getLatestBills();
			

			
			Console.WriteLine(cp.sb.ToString());
			Utils.Filer.writeAllText(@"c:\github\chaseFiles\" + Dater.TimeStamp()+"Bills.txt", cp.sb.ToString());

			Console.WriteLine("any key for general report");
			Console.ReadLine();

			cp.sb = new System.Text.StringBuilder();

			cp.runMainReport(true);


			Console.WriteLine(cp.sb.ToString());
			Utils.Filer.writeAllText(@"c:\github\chaseFiles" + Dater.TimeStamp() + "Mainreport.txt", cp.sb.ToString());




		}
    }
}
