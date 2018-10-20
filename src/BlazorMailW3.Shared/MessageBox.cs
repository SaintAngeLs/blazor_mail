using System.Collections.Generic;

namespace BlazorMailW3.Shared
{
    public class MessageBox
    {
        public IList<MessageThread> Draft { get; set; }
        public IList<MessageThread> Inbox { get; set; }
        public IList<MessageThread> Sent { get; set; }
    }
}
