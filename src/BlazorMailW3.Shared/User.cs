using System.Collections.Generic;

namespace BlazorMailW3.Shared
{
    public class User : Contact
    {      
        public MessageBox MessageBox { get; set; } = new MessageBox();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
