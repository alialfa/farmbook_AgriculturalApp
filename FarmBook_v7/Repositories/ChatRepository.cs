/* the chat repository connects with the chat controller to store user chat messages*/

namespace FarmBook_v7.Repositories
{
    using System.Collections.Generic;

    using FarmBook_v7.Models;
    using FarmBook_v7.Utils;

    public static class ChatRepository
    {
        private const int MaxNumberInRepo = 50;

        private static volatile List<ChatMessage> messages = new List<ChatMessage>();
        private static object messageLock = new object();

        public static void AddMsg(ChatMessage msg)
        {
            if (string.IsNullOrWhiteSpace(msg.MessageText))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(msg.Username))
            {
                return;
            }

            msg.MessageText = msg.MessageText.Sanitize();
            msg.Username = msg.Username.Sanitize();

            lock (messageLock)
            {
                messages.Insert(0, msg);
                while (messages.Count > MaxNumberInRepo)
                {
                    messages.RemoveAt(messages.Count - 1);
                }
            }
        }

        public static IEnumerable<ChatMessage> GetMessages()
        {
            return messages.AsReadOnly();
        }
    }
}