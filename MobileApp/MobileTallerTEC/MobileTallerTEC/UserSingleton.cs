using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTallerTEC
{
    public sealed class UserSingleton
    {
        private UserSingleton() { }

        private static UserSingleton _instance;
        public string Id { get; set; }
        public static UserSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserSingleton();
            }
            return _instance;
        }

    }
}
