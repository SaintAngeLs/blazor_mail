using BlazorMailW3.Shared;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMailW3.Client.Services
{
    public class AppState
    {
        private readonly HttpClient http;
        private User _user;
        public List<MessageThread> Inbox = new List<MessageThread>();
        public List<MessageThread> Sent = new List<MessageThread>();
        public List<Contact> People { get; set; }

        public event Action OnStateChanged;

        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;            
        }

        public async Task Init()
        {
            await Loaduser();

            OnStateChanged?.Invoke();
        }

        public void CloseModal()
        {            
            OnStateChanged?.Invoke();
        }

        /// <summary>
        /// Sends the email. TODO Move out of this service into API
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="Body">The body.</param>
        /// <param name="subject">The subject.</param>
        public void SendEmail(string email, string Body, string subject)
        {
            //Get a Contact or add a new one
            var reciept = _user.Contacts.FirstOrDefault(x => x.Email == email);
            if (reciept == null)
            {
                _user.Contacts.Add(new Contact() { Email = email });
                reciept = _user.Contacts.LastOrDefault();
            }
                
            Sent.Add(new MessageThread()
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {                    
                    new Message()
                    {
                        Body = Body,
                        From = _user,
                        Subject = subject,
                        To = reciept,
                        Date = DateTime.UtcNow
                    }
                }
            });
        }

        private async Task Loaduser()
        {
            _user = await http.GetJsonAsync<User>("/api/user");

            Inbox = (List<MessageThread>)_user.MessageBox.Inbox;
            Sent = (List<MessageThread>)_user.MessageBox.Sent;

            Console.WriteLine("Initialized logged in User");
        }
    }
}
