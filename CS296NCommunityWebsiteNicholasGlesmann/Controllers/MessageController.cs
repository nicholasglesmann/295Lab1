using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CS296NCommunityWebsiteNicholasGlesmann.Models;
using Microsoft.AspNetCore.Mvc;
using CS295NCommunityWebsiteNicholasGlesmann.Repositories;

namespace CS296NCommunityWebsiteNicholasGlesmann.Controllers
{
    public class MessageController : Controller
    {
        IRepository repo;

        // constructor for the MessageController
        public MessageController(IRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            // get the list of messages from the MessageRepository
            List<Message> messages = repo.Messages;

            // get the count of messages and put it in the ViewBag
            ViewBag.messageCount = messages.Count;

            var sortedMessages = SortMessages(messages);

            // pass the sorted list of messages to the view
            return View(sortedMessages);
        }

        // this is the HttpGet version of SendMessage. This method gets called when the user first navigates
        // to the SendMessage page.
        public IActionResult SendMessage()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        // this is the HttpPost version of SendMessage. This method gets called when the user submits the form
        // on the SendMessage page. Parameter names come from the form field "name" html attribute in the 
        // html "input" tag.
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {

            // get the DateTime that the form was submitted and put it into the new message object
            DateTime date = DateTime.Now;
            message.Date = date;

            // put all the form field values into the new message object
            message.IsResponse = 0;

            if (ModelState.IsValid)
            {
                repo.AddMessage(message);  // this is temporary, in the future the data will go in a database

                return RedirectToAction("Index");
            }

            // If validation fails return to the view with the passed in object
            return View(message);
        }

        // this is the HttpGet version of SendResponse. This method gets called when the user navigates
        // to the SendResponse page by clicking the "Send a Response" link on the Message Index page.
        public IActionResult SendResponse(string messageTitle)
        {
            ViewData["messageTitle"] = HttpUtility.HtmlDecode(messageTitle);
            return View("SendResponse");
        }

        // this is the HttpPost version of SendResponse. This method gets called when the user submits the form
        // on the SendResponse page. Parameter names come from the form field "name" html attribute in the 
        // html "input" tag.
        [HttpPost]
        public RedirectToActionResult SendResponse(string messageTitle, string responseTitle,
                                                string responseText,
                                                string responder)
        {
            // get the DateTime that the response form was submitted
            DateTime date = DateTime.Now;

            // get the message that was responded to. This is done by searching for the messageTitle in the
            // MessageRepository list of messages.
            Message message = repo.GetMessageByMessageTitle(messageTitle);

            // create a new message object for the reponse and add it to the list of responses on the message
            // that was responded to. This allows for an infinate number of responses on any specific message.
            Message response = new Message() {
                Name = responder,
                Recipient = message.Name,
                MessageTitle = responseTitle,
                MessageText = responseText,
                Date = date,
                IsResponse = 1
            };

            repo.AddResponse(messageTitle, response);

            return RedirectToAction("Index");
        }

        public List<Message> SortMessages(List<Message> messages)
        {
            // sort the list of messages based on date oldest first
            messages.Sort((m1, m2) => string.Compare(m1.Date.ToString(), m2.Date.ToString(), StringComparison.Ordinal));

            // reverse the list so it is now sorted by date newest first
            messages.Reverse();

            // then sort the list based on message priority (highest first)
            messages.Sort((m1, m2) => string.Compare(m1.MessagePriority, m2.MessagePriority, StringComparison.Ordinal));

            return messages;
        }
    }
}