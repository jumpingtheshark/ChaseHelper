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

        public void loadData()
        {
            Utils.Utils u = new Utils.Utils();
            List<string[]> ls = u.csv2ListStringArray(csvpath);
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

    }
}
