using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonPrototype
{
    [DataContract(Name="user")]
    public class User
    {
        [DataMember(Name="email")]
        private string email;
        [DataMember(Name="password")]
        private string password;
        AuthenticationToken token;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int ID
        {
            get { return token.ID; }
            set { token.ID = value; }
        }

        public string AuthToken
        {
            get { return token.AuthToken; }
            set { token.AuthToken = value; }
        }

        public AuthenticationToken Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
