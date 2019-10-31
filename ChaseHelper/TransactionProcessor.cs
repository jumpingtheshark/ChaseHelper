using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace ChaseHelper
{
    class TransactionProcessor
    {
        public Transaction load(string[] ts)
        {
           
            Transaction t = new Transaction();
            // non pending row
            if (ts[5].Trim() != "")
            {
                t._00_details = ts[0];
				// need to circle back and finish the utils part here
				t._01_datestring = Utils.Dater.datestring2string(ts[1]);
                t._02_description = ts[2];
                t._03_amount = Convert.ToDecimal(ts[3]);
                t._04_type = ts[4];
                t._05_balance = Convert.ToDecimal(ts[5]);
				t.transDate = Utils.Dater.datestring2DateTime(ts[1]);
            }
            return t;

        }

    }
}
