using System;
using System.Web.Mvc;
using FinTechWebApp.Data;
using FinTechWebApp.Helpers;
using FinTechWebApp.Models.Hackathon;
using FinTechWebApp.Models.Services;

namespace FinTechWebApp.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult Index(string username)
        {
            return View(LoanService.GetLoans(username, (short)Enumerators.LoanRequestStatus.Approved));
        }

        [HttpGet]
        public ActionResult RequestLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestALoan()
        {
            return Index("elena");
        }

        public ActionResult ShowLoanRequest(Guid loanRequestGuid)
        {
            using (var context = new HackathonContext())
            {
                var request = context.LoanRequests.Find(loanRequestGuid);

                if (request != null)
                    return View(request);

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ShowLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowALoan()
        {
            return Index("elena");
        }

        public ActionResult MakePayment()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var context = new HackathonContext())
                    {
                        var loan = context.Loans.Find(Constants.LoanGuid());
                        if (loan != null)
                        {
                            context.Loans.Remove(loan);
                            context.SaveChanges();
                            return RedirectToAction("ShowLoan");
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            return RedirectToAction("ShowLoanRequest");
        }
    }
}