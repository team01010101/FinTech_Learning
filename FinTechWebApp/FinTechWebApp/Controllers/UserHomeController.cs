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

        [HttpPost]
        public ActionResult CreateLoanRequest(LoanRequest loanRequest)
        {
            if (ModelState.IsValid)
                LoanRequestService.AddLoanRequest(loanRequest);

            return RedirectToAction("Index");
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

        public ActionResult ShowLoan(Guid loanGuid)
        {
            using (var context = new HackathonContext())
            {
                var request = context.Loans.Find(loanGuid);

                if (request != null)
                    return View(request);

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult MakePayment(Loan loan)
        {
            if (ModelState.IsValid)
            {
                using (var context = new HackathonContext())
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();

                    //Set creditpoint
                }

            }

            return RedirectToAction("ShowLoanRequest");
        }
    }
}