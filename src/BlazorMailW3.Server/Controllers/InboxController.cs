using System;
using System.Collections.Generic;
using System.Linq;
using BlazorMailW3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMailW3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        // GET: api/Inbox
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return Data.MessageRepo.LoggedInUser().MessageBox.Inbox
                .Select(x => new { x.Messages[0].From, x.Messages[0].Subject, x.Messages.Count });
        }

        // GET: api/Inbox/5
        [HttpGet("{id}", Name = "Get")]
        public Message Get(int id)
        {
            if (id > Data.MessageRepo.LoggedInUser().MessageBox.Inbox.Count - 1)
                return null;

            return null;
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    if (id > Data.MessageRepo.InboxMessages.Count - 1)
        //        throw new Exception("Error deleting message");

        //    Data.MessageRepo.InboxMessages.RemoveAt(id);
        //}
    }
}
