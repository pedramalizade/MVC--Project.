
using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.Data.Repository;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.Services;
using App.Domain.Service.Core_App.CardAggrigate;
using App.Domain.Service.Core_App.UserAggrigate;
using App.Infra.Data.Repos.Ef.Core_App.UserAggrigate;
using App.Infra.DataBase.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Core_App.UserAggrigate
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService()
        {
            _userService = new UserService();
        }
        static Dictionary<int, DateTime> Codes = new Dictionary<int, DateTime>();
        public void AddCard(int userId, Card card)
        {
            _userService.AddCard(userId, card);
        }

        public int GenerateRandomeCode()
        {
            var randomcode = _userService.GenerateRandomeCode();
            Codes[randomcode] = DateTime.Now.AddSeconds(50);
            return randomcode;
        }

        public List<Card> GetAll()
        {
            return _userService.GetAll();
        }

        public List<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }

        public List<Card> GetUserCards(int id)
        {
            var cards = _userService.GetUserCards(id);
            if(cards == null)
            {
                throw new NullReferenceException();
            }
            return cards;
        }

        public User Login(string username, string password)
        {
            return _userService.Login(username, password);
        }

        public bool Register(User user)
        {
            return _userService.Register(user);
        }

        public void RemoveCard(string cardNumber)
        {
            _userService.RemoveCard(cardNumber);
        }

        public void ShowCardBalance(int userId)
        {
            _userService.ShowCardBalance(userId);
        }
    }
}
