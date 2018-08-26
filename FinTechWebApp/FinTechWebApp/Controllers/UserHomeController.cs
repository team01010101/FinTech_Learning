using System;
using System.Linq;
using System.Web.Mvc;
using FinTechWebApp.Data;
using FinTechWebApp.Helpers;
using FinTechWebApp.MicroServices;
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
                        var loan = context.Loans.FirstOrDefault();
                        if (loan != null)
                        {
                            var payment =
                                context.Payments.FirstOrDefault(x => x.Status == (short)Enumerators.PaymentStatus.NotPayed);
                            HOP_PaymentClient hopClient = new HOP_PaymentClient();
                            string redirectUrl = "http://localhost:50162" + Url.Action("Index", new {username = "elena"});
                            //var url = hopClient.PaymentRequest(loan.User.EmailAddress, payment.InvoicedAmount, "",
                            //    payment.InvoiceNumber,
                            //    redirectUrl);

                            var a = hopClient.GetAuthorizationToken(payment.InvoiceNumber, payment.InvoicedAmount);

                            var url = "https://testhop.hakrinbank.com/gateway/service/PaymentController.php?TokenID=" + a +
                                   "&Email=" + "manson.mels@gmail.com" + "&Amount=" + payment.InvoicedAmount + "&Desc=" + "Description" + "&Inv=" + payment.InvoiceNumber +
                                   "&returnURL=" + redirectUrl;
                            Response.Redirect(url);
                            //context.Loans.Remove(loan);
                            //context.SaveChanges();
                            //return RedirectToAction("ShowLoan");
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