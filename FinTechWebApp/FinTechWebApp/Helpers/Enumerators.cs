using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Helpers
{
    public class Enumerators
    {
        public enum LoanRequestStatus
        {
            Requested = 1,
            NeedFeedback,
            Approved,
            Denied
        }

        public enum LoanStatus
        {
            Active = 1,
            NoActive,
            Finished,
            Canceled
        }
    }
}