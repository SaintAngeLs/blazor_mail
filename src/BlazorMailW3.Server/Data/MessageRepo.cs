using BlazorMailW3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorMailW3.Server.Data
{
    public class MessageRepo
    {
        //Email constants
        private const string MSG_OWNER = "you@blazormail.com";
        private const string SENDER1 = "amos@cheapmail.com";
        private const string SENDER2 = "dave@acmemail.com";
        private const string SENDER3 = "ponylover@chinemail.com";

        private static Contact[] People = new Contact[]
        {
            new Contact{Email=MSG_OWNER},
            new Contact{Email=SENDER1, Name = "Amos Sugdridge", Avatar = "/w3images/avatar2.png"},
            new Contact{Email=SENDER2, Name = "Dave BlazorUp", Avatar = "/w3images/avatar3.png"},
            new Contact{Email=SENDER3, Name = "Jane Horsefield", Avatar = "/w3images/avatar5.png"},
        };

        private static IList<MessageThread> InboxMessages = new List<MessageThread>()
        {
            new MessageThread
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {
                    new Message{To = People[0], From = People[1], Subject = "Woolpack Tonight?",
                    Body = "You up for a few beers? \n\r They got a new pinball machine in there as well if you didn't know.",
                    Date = DateTime.Now - TimeSpan.FromHours(2)
                    }
                }
            },
            new MessageThread
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {
                    new Message{To = People[0], From = People[2], Subject = "Can you remove viruzes?",
                    Body = "Can you remove viruses?? \n\r I only use Facebook on my PC, you can't get them there? Right??",
                    Date = DateTime.Now - TimeSpan.FromHours(2.5)
                    }
                }
            },
            new MessageThread
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {
                    new Message{To = People[0], From = People[3], Subject = "I'm riding the horse tonight, OK?", Read = true,
                    Body = "I gotta go take the Horse for a spin over some jumps etc later. \n\r Sorry, I know I have been doing this alot lately but I need to break her in some more.", Date = DateTime.Now - TimeSpan.FromHours(2.7)},

                    new Message{To = People[3], From = People[0], Subject = "I'm riding the horse tonight, OK?", Read = true,
                    Body = "Yeah whatever love. Do what you gotta do, you do anyway....XxX",
                    Date = DateTime.Now - TimeSpan.FromHours(2.5)},
                    },
                }
        };

        private static IList<MessageThread> SentMessages = new List<MessageThread>()
        {
            new MessageThread
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {
                    new Message{To = People[1], From = People[0], Subject = "Playing Pool?",
                        Body = "Up for some Pool down the Wooly??",
                        Date = DateTime.Now - TimeSpan.FromHours(1.5)},
                }
            },
            new MessageThread
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>()
                {
                    new Message{To = People[2], From = People[0], Subject = "Do you computer repairs?",
                    Body="Yeah I can help you remove them. \n\r Facebook is a Virus! Don't use it! LOL",
                    Date = DateTime.Now - TimeSpan.FromHours(1.4)}
                }
            }
        };

        private static User CurrentUser { get; set; }

        public static User LoggedInUser()
        {
            if (CurrentUser == null)
            {
                CurrentUser = new User();
                var people = People.Skip(1);
                CurrentUser.Name = "Gary Baldy";
                CurrentUser.Email = MSG_OWNER;
                CurrentUser.MessageBox = new MessageBox { Inbox = InboxMessages, Sent = SentMessages };
                CurrentUser.Contacts = people.ToList();
            }

            return CurrentUser;
        }
    }
}
