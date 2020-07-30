namespace FarmBook_v7.Models
{
    using System;

    public class ChatMessage
    {
        public string Username { get; set; }

        public string MessageText { get; set; }

        public DateTime TimeSent { get; set; }
    }
}