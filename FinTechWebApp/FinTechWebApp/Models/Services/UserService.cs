using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinTechWebApp.Data;
using FinTechWebApp.Models.Hackathon;
using Microsoft.Owin.Security;

namespace FinTechWebApp.Models.Services
{
    public class UserService
    {
        public static User FindUser(string username)
        {
            using (var context = new HackathonContext())
            {
                return context.Users.FirstOrDefault(x => x.Username == username);
            }
        }

        public static bool AddUser(RegisterViewModel model)
        {
            try
            {
                using (var context = new HackathonContext())
                {
                    context.Users.Add(new User
                    {
                        UserId = model.UserId,
                        Name = model.Name,
                        LastName = model.LastName,
                        EmailAddress = model.EmailAddress,
                        Password = model.Password,
                        Username = model.Username
                    });
                    context.SaveChanges();
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