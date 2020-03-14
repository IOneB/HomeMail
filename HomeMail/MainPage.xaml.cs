using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomeMail
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnSend_Clicked(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert("Подтвердить действие", "Отправить сообщения?", "Да", "Нет");
            if (result)
            {
                await SendEmail(to: "barabanovivan@bk.ru");
                await SendEmail(to: "barabanovivan@bk.ru");
                await SendEmail(to: "barabanovivan@bk.ru");
            }
            await DisplayAlert("Действие выполнено", "Письма отправлены", "Ок");
        }

        private async Task SendEmail(string to)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.yandex.ru");

                mail.From = new MailAddress("ivan.barabanov@simbirsoft.com");
                mail.To.Add(to);
                mail.Subject = "Работа из дома";
                mail.Body = "Работа из дома";

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.yandex.ru";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ivan.barabanov@simbirsoft.com", "h6E4KcT32!");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}
