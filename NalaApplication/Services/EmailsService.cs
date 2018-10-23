using NalaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class EmailsService
    {

            public Task SendEmailAsync(string email, string subject, string message)
            {
                return Task.CompletedTask;
            }

            public Task SendOrderConfirmToUser(Order order, ApplicationUser user)
            {
                string from = "***";
                string to = "***";
                string subject = "";
                string htmlBody = "";

                htmlBody += "<table>";
                htmlBody += "<tr><td> Namn </td><td>Pris</td><td>Antal</td></tr>";
                foreach (var item in order.Cart.CartItems)
                {
                    htmlBody += "<tr><td>" + item.Product.Name + "</td><td>" + item.Product.Price + "</td><td>" + item.Quantity + "</td></tr>";
                }

                htmlBody += "</table>";
                htmlBody += "Summa: " + order.TotalPrice;

                htmlBody += "<br>  " +
                    "<br>" + user.FirstName + "<br>" + user.LastName + "<br>" + user.Street + "<br>" + user.ZipCode + "<br>" + user.City + "<br>";

                htmlBody += " ****** Tel: 123456789";


                MailMessage mailMessage = new MailMessage(from, to, subject, htmlBody);
                mailMessage.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("********", "********");
                client.EnableSsl = true;
                client.Credentials = credentials;
                client.Send(mailMessage);
                return Task.CompletedTask;
            }
        }
    }


