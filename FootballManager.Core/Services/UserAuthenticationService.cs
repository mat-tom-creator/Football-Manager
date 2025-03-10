// FootballManager.Core/Services/UserAuthentication/UserAuthenticationService.cs
namespace FootballManager.Core.Services.UserAuthentication
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly Dictionary<string, string> _userCredentials = new Dictionary<string, string>();

        public UserAuthenticationService()
        {
            // Add a demo user
            _userCredentials.Add("admin", "password");
        }

        public bool Authenticate(string username, string password)
        {
            return _userCredentials.ContainsKey(username) && _userCredentials[username] == password;
        }

        public bool CreateUser(string username, string password)
        {
            if (_userCredentials.ContainsKey(username))
            {
                return false;
            }

            _userCredentials[username] = password;
            return true;
        }
    }
}