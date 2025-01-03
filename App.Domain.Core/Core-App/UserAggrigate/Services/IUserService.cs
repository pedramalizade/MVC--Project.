
using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.UserAggrigate.Services
{
    public interface IUserService
    {
        public User Login(string username, string password);
        public bool Register(User user);
        public void ShowCardBalance(int userId);
        public void AddCard(int userId, Core_App.CardAggrigate.Entities.Card card);
        public void RemoveCard(string cardNumber);
        public int GenerateRandomeCode();
        public List<Card> GetAll();
        public List<User> GetAllUser();
    }
}
