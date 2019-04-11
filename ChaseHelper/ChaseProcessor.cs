using System;
using System.Collections.Generic;
using System.Text;
using Utils;


namespace ChaseHelper
{
    class ChaseProcessor
    {
       public List<Transaction> tl = new List<Transaction>();
        public string csvpath;

        public void loadData()
        {
            Utils.Utils u = new Utils.Utils();
            List<string[]> ls = u.csv2ListStringArray(csvpath);
            

           

        }

    }
}
