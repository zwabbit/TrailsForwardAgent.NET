using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonPrototype
{
    [DataContract]
    public class User
    {
        [DataMember]
        internal string fullName = "user";
        [DataMember]
        private string name;
        [DataMember]
        private string password;

        public string Name
        {
            get { return Name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
