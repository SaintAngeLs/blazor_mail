using System;

namespace BlazorMailW3.Shared
{
    public class Message
    {
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Contact From { get; set; }
        public bool IsSpam { get; set; }
        public bool InTrash { get; set; }
        public bool Read { get; set; }
        public string Subject { get; set; }
        public Contact To { get; set; }      
    }
}
