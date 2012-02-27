using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonPrototype
{
    [DataContract]
    public class AuthenticationToken
    {
        [DataMember]
        private int id;
        [DataMember(Name="auth_token")]
        private string authToken;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string AuthToken
        {
            get { return authToken; }
            set { authToken = value; }
        }
    }
}
