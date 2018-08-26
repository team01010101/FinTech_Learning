using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinTechWebApp.Data;

namespace FinTechWebApp.Models.Services
{
    public class PaymentService
    {
        public static bool MakeNextPayment(Guid paymentGuid)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    var payment = context.Payments.ToList();

                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }
}