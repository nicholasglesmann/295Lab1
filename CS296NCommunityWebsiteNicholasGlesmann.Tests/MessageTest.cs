using System;
using Xunit;
using CS296NCommunityWebsiteNicholasGlesmann.Models;
using CS296NCommunityWebsiteNicholasGlesmann.Controllers;
using CS295NCommunityWebsiteNicholasGlesmann.Repositories;
using Xunit.Abstractions;

namespace CS295NCommunityWebsiteNicholasGlesmann.Tests
{
    public class MessageTest
    {
        private readonly ITestOutputHelper output;

        public MessageTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SendMessageTest()
        {
            // Arrange
            var repo = new FakeMessageRepository();
            var messageController = new MessageController(repo);

            // Act
            messageController.SendMessage("Mickey Mouse", "Donald Duck",
                "3Low", "Send Message Title", "Some Message Text");

            // Assert
            Assert.Equal("Mickey Mouse", repo.Messages[repo.Messages.Count - 1].Name);
            Assert.Equal("Donald Duck", repo.Messages[repo.Messages.Count - 1].Recipient);
            Assert.Equal("3Low", repo.Messages[repo.Messages.Count - 1].MessagePriority);
            Assert.Equal("Send Message Title", repo.Messages[repo.Messages.Count - 1].MessageTitle);
            Assert.Equal("Some Message Text", repo.Messages[repo.Messages.Count - 1].MessageText);
        }

        [Fact]
        public void SendResponseTest()
        {
            // Arrange
            var repo = new FakeMessageRepository();
            var messageController = new MessageController(repo);

            messageController.SendMessage("Mickey Mouse", "Donald Duck",
                "3Low", "Send Response Message Title", "Some Message Text");

            // Act
            messageController.SendResponse("Send Response Message Title", "A Response Title",
                "Some Response Text", "Donald Duck");

            // Assert
            var message = repo.GetMessageByMessageTitle("Send Response Message Title");
            var response = message.Responses[message.Responses.Count - 1];
            Assert.Equal("Donald Duck", response.Name);
            Assert.Equal("A Response Title", response.MessageTitle);
            Assert.Equal("Some Response Text", response.MessageText);
            Assert.Equal("Mickey Mouse", response.Recipient);
        }

        [Fact]
        public void SortMessagesTest()
        {
            // Arrange
            var repo2 = new FakeMessageRepository();
            var messageController2 = new MessageController(repo2);

            messageController2.SendMessage("Mickey Mouse", "Donald Duck",
                "3Low", "First Message Title", "Some Message Text");

            messageController2.SendMessage("Mickey Mouse", "Donald Duck",
                "2Medium", "Second Message Title", "Some Message Text");

            messageController2.SendMessage("Mickey Mouse", "Donald Duck",
                "1High", "Third Message Title", "Some Message Text");

            output.WriteLine("Name: {0}", repo2.Messages[1].Name);
            output.WriteLine("Message Title: {0}", repo2.Messages[1].MessageTitle);
            output.WriteLine("Priority: {0}", repo2.Messages[1].MessagePriority);


            Assert.Equal("3Low", repo2.Messages[0].MessagePriority);

            // Act
            var sortedMessages = messageController2.SortMessages(repo2.Messages);

            // Assert
            Assert.Equal("1High", sortedMessages[0].MessagePriority);

        }
    }
}
