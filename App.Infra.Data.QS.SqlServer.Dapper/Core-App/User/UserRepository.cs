using App.Domain.Core.Core_App.UserAggrigate.Data.Repository;
using App.Infra.DataBase.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Dapper.Core_App.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public bool Create(Domain.Core.Core_App.UserAggrigate.Entities.User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id == id);
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Domain.Core.Core_App.UserAggrigate.Entities.User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public Domain.Core.Core_App.UserAggrigate.Entities.User GetById(int userId)
        {
            var result = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            return result;
        }

        public Domain.Core.Core_App.UserAggrigate.Entities.User GetByusername(string username)
        {
            var result = _appDbContext.Users.FirstOrDefault(u => u.Username == username);
            return result;
        }

        public void ShowCardBalance(int userId)
        {
            var CardList = _appDbContext.Cards.ToList();
            foreach (var card in CardList)
            {
                if (card.UserId == userId)
                {
                    Console.WriteLine($"Card Number : {card.CardNumber}, Holder Name : {card.HolderName}, Balance : {card.Balance}");
                }
            }
        }
    }
}
