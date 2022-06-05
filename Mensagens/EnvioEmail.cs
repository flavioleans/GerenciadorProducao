using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Configuration;

namespace Mensagens
{
    public class EnvioEmail
    {
        //metodo de envio de e-mail
        public void enviar(string msg)
        {

            try
            {
                SmtpClient cliente = new SmtpClient();
                NetworkCredential credenciais = new NetworkCredential();


                //definir configurações da conta
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = false;

                //definir credenciais de acesso ao e-mail
                credenciais.UserName = "bolinha.lacucabrinquedos";
                credenciais.Password = "lakuka1010";

                //define as credenciais no cliente.
                cliente.Credentials = credenciais;

                //mensagem a ser enviada
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("bolinha.lacucabrinquedos@gmail.com");
                mensagem.IsBodyHtml = true;//permite usar tag html para fortação do texto
                mensagem.Subject = ConfigurationManager.AppSettings["tituloEmailMaquina"]; // + $"{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.Hour}h";
                mensagem.Body = ConfigurationManager.AppSettings["corpoEmailMaquinaParada"] + DateTime.Now.ToString() + "<br> MOTIVO: " + msg;
                mensagem.To.Add("adm2@lacucabrinquedos.com.br");
                mensagem.To.Add("sac@lacucabrinquedos.com.br");
                mensagem.To.Add("cristino@lacucabrinquedos.com.br");
                mensagem.To.Add("flavioleandro@lacucabrinquedos.com.br");





                //envio da mensagem
                cliente.Send(mensagem); //ativar envio de e-mail por outras aplicações.
                                        //https://myaccount.google.com/lesssecureapps
                MessageBox.Show("E-MAIL ENVIADO COM SUCESSO!");
            }
            catch (Exception e)
            {

                MessageBox.Show($"Exception ao enviar EmailOK. EX: {e}");
            }


        }

        //ENVIO DE E-MAIL MUDANÇA DE COR
        public void enviarMudanca()
        {

            try
            {
                SmtpClient cliente = new SmtpClient();
                NetworkCredential credenciais = new NetworkCredential();


                //definir configurações da conta
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = false;

                //definir credenciais de acesso ao e-mail
                credenciais.UserName = "bolinha.lacucabrinquedos";
                credenciais.Password = "lakuka1010";

                //define as credenciais no cliente.
                cliente.Credentials = credenciais;

                //mensagem a ser enviada
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("bolinha.lacucabrinquedos@gmail.com");
                mensagem.IsBodyHtml = true;//permite usar tag html para fortação do texto
                mensagem.Subject = ConfigurationManager.AppSettings["tituloEmailCor"]; // + $"{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.Hour}h";
                mensagem.Body = ConfigurationManager.AppSettings["corpoEmailCor"] + DateTime.Now.ToString();
                mensagem.To.Add("adm2@lacucabrinquedos.com.br");
                mensagem.To.Add("sac@lacucabrinquedos.com.br");
                mensagem.To.Add("cristino@lacucabrinquedos.com.br");
                mensagem.To.Add("flavioleandro@lacucabrinquedos.com.br");




                //envio da mensagem
                cliente.Send(mensagem); //ativar envio de e-mail por outras aplicações.
                                        //https://myaccount.google.com/lesssecureapps
                MessageBox.Show("E-MAIL ENVIADO COM SUCESSO!");
            }
            catch (Exception e)
            {

                MessageBox.Show($"Exception ao enviar EmailOK. EX: {e}");
            }


        }
    }
}
