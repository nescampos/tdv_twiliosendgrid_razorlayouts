using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.Extensions.Configuration;
using SendGridFluentEmailSender;
using System.Net.Mail;


string emailServer = "<SMTP Server, by default: localhost>";
int emailPort = <SMTP port>;

SmtpClient smtpClient = new SmtpClient(emailServer, emailPort);

Email.DefaultRenderer = new RazorRenderer();
Email.DefaultSender = new SmtpSender(smtpClient);


IFluentEmail firstEmail = Email
    .From("<sender email address>")
    .To("<destination email address>")
    .Subject("Test Email")
    .Tag("test")
    .UsingTemplateFromFile($"FirstTemplate.cshtml", new FirstTemplateModel { Name = "Nestor Campos" });

IFluentEmail secondEmail = Email
    .From("<sender email address>")
    .To("<destination email address>")
    .Subject("Second Email")
    .Tag("test")
    .UsingTemplateFromFile($"SecondTemplate.cshtml", new SecondTemplateModel {  Title = "Welcome to our site", Description = "We are sending some product discounts for you as our new customer", ColumnOne = "This is our first discount", ColumnTwo = "This is our second discount" });

SendResponse firstEmailResponse = firstEmail.Send();
SendResponse secondEmailResponse = secondEmail.Send();

Console.WriteLine(firstEmailResponse.Successful ? "First email queued" : "First email failed to send");
Console.WriteLine(secondEmailResponse.Successful ? "Second email queued" : "Second email failed to send");
