using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace ArtigoTesteMetodoVoid.Core
{
    public class Arquivo
    {
        public void CriarArquivo(string nome)
        {
            var path = $@"C:\{nome}.txt";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine("Arquivo criado");
            }
        }

        public void EnviaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("E-mail obrigatório");
            }

            if (!ValidaEmail(email))
            {
                throw new ArgumentException("E-mail inválido");
            }

            try
            {
                var client = new SmtpClient("servidorSMTP")
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("usuario", "senha")
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("noreply@dominio.com")
                };

                mailMessage.To.Add(email);
                mailMessage.Body = "Corpo do email";
                mailMessage.Subject = "Assunto";
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private bool ValidaEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
