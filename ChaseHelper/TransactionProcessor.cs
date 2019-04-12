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
            Utils.Utils u = new Utils.Utils();
            Transaction t = new Transaction();
            t._01_details = ts[0];
            // need to circle back and finish the utils part here
            t._02_datestring = u.datestring2string(ts[1]);
            
            return t;

        }

    }
}
