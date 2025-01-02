using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.UserAggrigate.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<CardAggrigate.Entities.Card> Cards { get; set; } = new();
        public User() { }
        public User(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
        }
    }
}
