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
            return View(LoanService.GetLoans(username, (short)Enumerators.LoanStatus.Active));
        }

        [HttpGet]
        public ActionResult RequestLoan(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = Request.UrlReferrer?.Query.Split('=').Last();
            var user = UserService.FindUser(username);
            if (user != null)
                return View(new Loan{LoanGuid = Guid.NewGuid(), Username = username, Status = (short)Enumerators.LoanStatus.Active});

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult RequestLoan(Loan loan)
        {
            if (ModelState.IsValid)
            {
                if (LoanService.AddLoan(loan))
                    return RedirectToAction("Index", new { username = loan.Username });
            }

            return RedirectToAction("RequestLoan", new { username = loan.Username});
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
        public ActionResult ShowLoan(Guid loanGuid)
        {
            var loan = LoanService.FindLoan(loanGuid);

            if(loan != null)
                return View(loan);

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult MakePayment(Guid loanGuid)
        {
                try
                {
                    using (var context = new HackathonContext())
                    {
                        Loan loan = LoanService.FindLoan(loanGuid);
                        if (loan != null)
                        {
                            var payment =
                                context.Payments.FirstOrDefault(x => x.Status == (short)Enumerators.PaymentStatus.NotPayed);
                            HOP_PaymentClient hopClient = new HOP_PaymentClient();
                            string redirectUrl = "http://localhost:50162" + Url.Action("Index", new {username = "elena"});
                            //var url = hopClient.PaymentRequest(loan.User.EmailAddress, payment.InvoicedAmount, "",
                            //    payment.InvoiceNumber,
                            //    redirectUrl);
                            //payment.InvoicedAmount = 13.25;

                            //var a = hopClient.GetAuthorizationToken("1691709", payment.InvoicedAmount);
                            var a = "785b518590c14b5831de8674299bf1b39f49dca2";

                            var url = "https://testhop.hakrinbank.com/gateway/service/PaymentController.php?TokenID=" + a + "&Amount=" + payment.InvoicedAmount + "&Desc=" + "Description" + "&Inv=" + payment.InvoiceNumber +
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

            return RedirectToAction("ShowLoanRequest");
        }
    }
}