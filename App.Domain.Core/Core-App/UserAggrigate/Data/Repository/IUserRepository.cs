using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.UserAggrigate.Data.Repository
{
    public interface IUserRepository
    {
        public bool Create(User user);
        public User GetByusername(string username);
        public User GetById(int userId);
        public bool Delete(int id);
        public List<User> GetAllUser();
        public void ShowCardBalance(int userId);
        public List<Card> GetAllCard();
        public List<Card>? GetCards(int id);
    }
}
