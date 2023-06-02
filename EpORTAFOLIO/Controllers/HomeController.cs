using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using EpORTAFOLIO.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace EpORTAFOLIO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ProyLizbreria()
        {
            return View();
        }

        public ActionResult ProyFixel()
        {
            return View();
        }

        public ActionResult ProyManicura()
        {
            return View();
        }

        public ActionResult Contacto()
        {

            return View(new Contacto1());
        }

        [HttpPost]
        public ActionResult Enviar(EpORTAFOLIO.Models.Contacto1 contacto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Crear un objeto MimeMessage con la información del formulario.
                    var mensaje = new MimeMessage();
                    mensaje.From.Add(new MailboxAddress("From", "programacionvisual261@gmail.com"));
                    mensaje.To.Add(new MailboxAddress("Lizbeth", "Lrodriguez14@gmail.com"));
                    mensaje.Subject = "New Contact from the Form";
                    mensaje.Body = new TextPart("plain")
                    {
                        Text = string.Format("Hello, a new HostSchool wants to get in touch with IAG.\nFull Name: {0}\nEmail: {1}\nPhone: {2}\nMessage: {3}",
                            contacto.FullName, contacto.Correo, contacto.Correo, contacto.Mensaje)
                    };

                    // Enviar el correo electrónico utilizando el servidor SMTP de Gmail.
                    using (var clienteSmtp = new SmtpClient())
                    {
                        clienteSmtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        clienteSmtp.Authenticate("programacionvisual261@gmail.com", "mrctyjiiugkikxpf");
                        clienteSmtp.Send(mensaje);
                        clienteSmtp.Disconnect(true);
                    }

                    return RedirectToAction("Contacto");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error al enviar el correo electrónico. Por favor, intenta de nuevo más tarde.");
                }
            }


            return View("Contacto1", contacto);
        }

    }


}