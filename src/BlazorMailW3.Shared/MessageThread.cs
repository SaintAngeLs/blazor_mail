using System;
using System.Collections.Generic;

namespace BlazorMailW3.Shared
{
    public class MessageThread
    {
        public Guid Id { get; set; }
        public IList<Message> Messages = new List<Message>();
    }
}
