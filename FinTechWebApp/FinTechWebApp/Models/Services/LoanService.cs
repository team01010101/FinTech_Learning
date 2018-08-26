using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinTechWebApp.Data;
using FinTechWebApp.Models.Hackathon;

namespace FinTechWebApp.Models.Services
{
    public class LoanService
    {
        public static List<Loan> GetLoans(string username, short loanStatus)
        {
            using (var context = new HackathonContext())
            {
                return context.Loans
                    .Where(x => x.User.Username == username
                                && x.Status == loanStatus).ToList();
            }
        }

        public static bool AddLoan(Loan request)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    context.Loans.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                //ignored
            }

            return false;
        }

        public static bool RemoveLoan(Guid loanGuid)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    var loan = context.Loans.Find(loanGuid);
                    if (loan != null)
                    {
                        context.Loans.Remove(loan);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //ignored
            }

            return false;
        }
    }
}