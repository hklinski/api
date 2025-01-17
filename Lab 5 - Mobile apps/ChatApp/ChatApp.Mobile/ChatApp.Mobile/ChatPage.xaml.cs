﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly string userName;
        private readonly HubConnection hubConnection;
        private ObservableCollection<UserChatMessage> Messages { get; } = new ObservableCollection<UserChatMessage>();

        public ChatPage(string userName)
        {
            InitializeComponent();
            this.userName = userName;

            btnSend.Clicked += BtnSend_ClickedAsync;

            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://192.168.1.156:5000/chathub")
                .Build();

            hubConnection.On<UserChatMessage>(Consts.RECEIVE_MESSAGE, ReceiveMessage_Event);
            hubConnection.On<string>(Consts.USER_JOINED, UserJoined_Event);
            hubConnection.StartAsync();
        }

        private void UserJoined_Event(string obj)
        {
            Messages.Insert(0, new UserChatMessage
            {
                Messages = "User joined to the conversation",
                userName = userName,
                TimeStamp = DateTime.Now
            });
        }

        private void ReceiveMessage_Event(object obj)
        {
            Messages.Insert(0, (UserChatMessage)obj);
        }

        private async void BtnSend_ClickedAsync(object sender, EventArgs e)
        {
            var message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(message))
            {
                await DisplayAlert("Validation errors", "The message is required.", "Ok");
                return;
            }
            await hubConnection.SendAsync(Consts.SEND_MESSAGE, new UserChatMessage
            {
                Message = message,
                Username = userName
            });
        }
    }
}