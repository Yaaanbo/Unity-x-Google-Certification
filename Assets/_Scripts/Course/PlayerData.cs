using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Incomplete
{
    public class PlayerData
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public bool isLoggedIn {get; private set;}

        public PlayerData() { }

        public PlayerData(string _username, string _password, bool _isLoggedIn)
        {
            this.username = _username;
            this.password = _password;
            this.isLoggedIn = _isLoggedIn;
        }
    }
}

