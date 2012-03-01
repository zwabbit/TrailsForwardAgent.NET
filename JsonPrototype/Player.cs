using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonPrototype
{
    [DataContract(Name = "players")]
    public class Player
    {
        [DataMember(Name="id")]
        int id;
        [DataMember(Name="name")]
        string name;
        [DataMember(Name="type")]
        string type;
        [DataMember(Name="world_id")]
        int worldID;
        [DataMember(Name="world_name")]
        string worldName;
        [DataMember(Name="balance")]
        int balance;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
