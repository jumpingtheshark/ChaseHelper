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


			

   
			ChaseProcessor cp = new ChaseProcessor(@"c:\a2\f.csv");
             
            cp.loadData();
			cp.standardReport();
			cp.daysDiscrete(-40);
			cp.weeksDiscrete(-8);
			cp.monthlyDetails(-8);
			Console.WriteLine(cp.sb.ToString());
			Console.ReadLine();
			return; 
			/*
			var studentNames = studentList.Where(s => s.Age > 18)
							  .Select(s => s)
							  .Where(st => st.StandardID > 0)
							  .Select(s => s.StudentName);

		*/

			var fl = cp.tl.Where(f => f._02_description.ToLower().Contains("online transfer") == false);
			int count = fl.Count();

			//cp.standardReport();

			Console.ReadLine();
			
			
			
        }
    }
}
