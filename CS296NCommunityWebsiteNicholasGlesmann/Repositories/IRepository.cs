using CS296NCommunityWebsiteNicholasGlesmann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295NCommunityWebsiteNicholasGlesmann.Repositories
{
    public interface IRepository
    {
        List<Message> Messages { get; }
        void AddMessage(Message message);
        void AddResponse(string messageTitle, Message response);
        Message GetMessageByMessageTitle(string title);
    }
}
