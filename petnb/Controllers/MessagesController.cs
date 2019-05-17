using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petnb.Services;

namespace petnb.Controllers
{
    public class MessagesController : Controller
    {
    private readonly IFirebaseService _firebaseService;

        public MessagesController(IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }
        public async Task<IActionResult> Index()
        {
            var checkToken = HttpContext.Session.GetString("FirebaseToken");

            if (checkToken == null)
            {
                var customToken = await _firebaseService.GenerateCustomToken("test");
                HttpContext.Session.SetString("FirebaseToken", customToken);
            }

            ViewBag.Conversations = GetDummyData();

            return View();

        }

        private List<Conversation> GetDummyData()
        {    
            var messages1 = new List<Message>()
            {
                new Message("Hi",true),
                new Message("Hi",false),
                new Message("Can you petsit my dog next Wednesday??",true),
                new Message("Yes",false),
                new Message("At what time should i be there?",false),
                new Message("13:00 would be fine",true),
                new Message("Okay, then it is a deal",false)

            };

            var messages2 = new List<Message>()
            {
                new Message("Hi2",true),
                new Message("Hi",false),
                new Message("Can you petsit my dog next Wednesday??",true),
                new Message("Yes",false),
                new Message("At what time should i be there?",false)

            };

            var messages3 = new List<Message>()
            {
                new Message("At what time should i be there?",false),
                new Message("13:00 would be fine",true),
                new Message("Okay, then it is a deal",false)

            };
            return new List<Conversation>()
            {
                new Conversation("Willem Williamsen", messages1),
                new Conversation("James Jamesson", messages2),
                new Conversation("Hanne Jackson", messages3)
            };
        }
    }

    public class Conversation
    {
        public string MessageReceiver { get; set; }
        public List<Message> Messages { get; set; }
        public int Id { get; set; }


        public Conversation(string messageReceiver, List<Message> messages)
        {
            MessageReceiver = messageReceiver;
            Messages = messages;
        }
    }

    public class Message
    {
        public string MessageText { get; set; }
        public bool IsReceiverMessage { get; set; }

        public Message(string messageText, bool isReceiverMessage)
        {
            MessageText = messageText;
            IsReceiverMessage = isReceiverMessage;
        }
    }
}