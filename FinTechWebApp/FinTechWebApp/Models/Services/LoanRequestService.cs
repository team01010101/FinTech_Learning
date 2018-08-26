using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FinTechWebApp.Data;
using FinTechWebApp.Models.Hackathon;

namespace FinTechWebApp.Models.Services
{
    public class LoanRequestService
    {
        public static List<LoanRequest> GetLoanRequests(short loanRequestStatus)
        {
            using (var context = new HackathonContext())
            {
                return context.LoanRequests
                    .Where(x => x.Status == loanRequestStatus).ToList();
            }
        }

        public static bool AddLoanRequest(LoanRequest request)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    context.LoanRequests.Add(request);

                    var user = context.Users.FirstOrDefault(x => x.UserId == request.User.UserId);

                    if (user != null)
                    {
                        user.CreditPoints += 100;
                        context.Entry(user).State = EntityState.Modified;
                    }

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

        public static bool RemoveLoanRequest(Guid requestGuid)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    var request = context.LoanRequests.Find(requestGuid);
                    if (request != null)
                    {
                        context.LoanRequests.Remove(request);
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