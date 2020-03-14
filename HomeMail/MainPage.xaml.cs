using HomeMail.Services;
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
        private readonly Repository _repository;
        private readonly SendMail _mailService;

        public MainPage()
        {
            InitializeComponent();

            _repository = new Repository();
            _mailService = new SendMail();
        }

        async void btnSend_Clicked(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert("Подтвердить действие", "Отправить сообщения?", "Да", "Нет");
            var addresses = _repository.GetAll();

            if (result)
            {
                foreach (var address in addresses)
                {
                    try
                    {
                        _mailService.Send(address);
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert($"Отправка по адресу {address} провалена", ex.Message, "OK");
                    }
                }
            }
            await DisplayAlert("Действие выполнено", "Письма отправлены", "Ок");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addresses());
        }
    }
}
