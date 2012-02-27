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
        [DataMember(Name="email",Order=0)]
        private string email;
        [DataMember(Name="password",Order=1)]
        private string password;

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
    }
}
