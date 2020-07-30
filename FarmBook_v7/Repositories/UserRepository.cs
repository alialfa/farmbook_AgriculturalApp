/* the user repository stores user chat messages for the session of their chat intermission */
 
namespace FarmBook_v7.Repositories
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using FarmBook_v7.Models;

    public static class UserRepository
    {
        private static ConcurrentDictionary<string, UsersSignedIn> connectionUserMap = new ConcurrentDictionary<string, UsersSignedIn>();

        public static void AddUser(string connectionId, string userName)
        {
            var user = new UsersSignedIn { Username = userName, SignedIn = DateTime.Now };

            connectionUserMap.TryAdd(connectionId, user);
        }

        public static string RemoveUser(string connectionId)
        {
            UsersSignedIn userName;
            connectionUserMap.TryRemove(connectionId, out userName);
            return userName == null ? null : userName.Username;
        }

        public static ICollection<UsersSignedIn> Users()
        {
            return connectionUserMap.Values;
        }
    }
}