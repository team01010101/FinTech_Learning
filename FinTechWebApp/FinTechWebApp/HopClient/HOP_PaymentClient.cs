using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FinTechWebApp.MicroServices
{
    public class HOP_PaymentClient
    {
        // Fields and Properties
        public HttpClient Client { get; set; }

        public string MerchantId { get; set; }

        public string Password { get; set; }

        public string MerchantKey { get; set; }

        public string AuthToken { get; set; }

        // Builder
        public HOP_PaymentClient(string merchantId = "00005006", string password = "8b275e7b46", string merchantKey = "76D5D9948bC9Ea491d9bC06c8f2e0d5b", string baseEndPoint = "https://testhop.hakrinbank.com/gateway/service/WebshopAuth/")
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseEndPoint);
            MerchantId = merchantId;
            Password = password;
            MerchantKey = merchantKey;
        }

        // Request Methods
        //static async Task<Product> GetProductAsync(string path)
        //{
        //    Product product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Product>();
        //    }
        //    return product;
        //}

        public string GetAuthorizationToken(string invoice, double amount)
        {
            string jsonData = RequestAuthorizationTokenAsync(invoice, amount).GetAwaiter().GetResult();
            var jsonObj = JObject.Parse(jsonData);
            if (jsonObj["Code"].ToString() == "0")
            {
                return jsonObj["Resp"].ToString();
            }
            //return null;
            return jsonObj["Resp"].ToString(); // testing

        }
        public async Task<string> RequestAuthorizationTokenAsync(string invoice, double amount)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Client.Timeout = new TimeSpan(1, 0, 0);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // https://hop.hakrinbank.com/gateway/service/WebshopAuth/<merchant_id>/<password>/<invoice#>/<amount>
            //Client.BaseAddress = new Uri("https://hop.hakrinbank.com/gateway/service/WebshopAuth/00000000/aaaaa00000/1691709/13.45");
            string reqArgs = MerchantId + "/" + Password + "/" + invoice + "/" + amount.ToString();
            

            HttpResponseMessage response = await Client.GetAsync(reqArgs);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null; // something it's wrong
        }

        //public async
        public string PaymentRequest(string email, double amount, string description, string invoice, string returnUrl)
        {
            //Response.Redirect("https://hop.hakrinbank.com/gateway/service/PaymentController.php?TokenID=1d3496824b626ed7cf712512ec42e3c3&Email=user@mailer.com&Amount=13.45&Desc=Some_Item&Inv=1691709&returnURL=http%3A%2F%2Fdemo.web.com%2Fpayments%0A%2Fservice")
            
            return "https://testhop.hakrinbank.com/gateway/service/PaymentController.php?TokenID=" + GetAuthorizationToken(invoice, amount) +
                    "&Email=" + email + "&Amount=" + amount + "&Desc=" + description + "&Inv=" + invoice +
                    "&returnURL=" + returnUrl;
        }

    }
}