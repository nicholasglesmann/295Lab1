using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296NCommunityWebsiteNicholasGlesmann.Models;
using Microsoft.EntityFrameworkCore;

namespace CS295NCommunityWebsiteNicholasGlesmann.Repositories
{
    // this class is just for testing messaging functionality
    public class MessageRepository : IRepository
    {
        private AppDbContext context;
        // create a list for all messages and responses on the "Messages" page
        private static List<Message> messages = new List<Message>();

        // read only property for the messages list
        public List<Message> Messages { get { return context.Messages.ToList(); } }

        public MessageRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        // method to add a message to the messages list
        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void AddResponse(string messageTitle, Message response)
        {
            Message message = GetMessageByMessageTitle(messageTitle);
            message.Responses.Add(response);
            context.Messages.Update(message);
            context.SaveChanges();
        }

        // method to search for a message by the messageTitle field and return a message from the message list
        public Message GetMessageByMessageTitle(string messageTitle)
        {
            Message message;
            message = context.Messages.First(b => b.MessageTitle == messageTitle);
            return message;
        }

        public void AddSeedData()
        {
            Message message;
            message = new Message()
            {
                Name = "Nicholas Glesmann",
                Recipient = "Steven Wilson",
                Date = new DateTime(1943, 1, 1),
                MessagePriority = "1High",
                MessageTitle = "Hello Lab Partner",
                MessageText = "Thanks for reviewing this lab!",
            };
            AddMessage(message);

            message = new Message()
            {
                Name = "Nicholas Glesmann",
                Recipient = "Brian Bird",
                Date = new DateTime(1937, 1, 1),
                MessagePriority = "2Normal",
                MessageTitle = "Hello Professor",
                MessageText = "Thanks for grading my lab!",
            };
            AddMessage(message);
        }
    }
}
