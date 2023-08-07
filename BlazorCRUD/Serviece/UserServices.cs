using AppData.AppDBcontext;
using AppData.Interface;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Serviece
{
    public class UserServices : IUser
    {
        public UserDbContext _dbContext;
        public UserServices()
        {
            _dbContext = new UserDbContext();
        }
        public async Task<bool> Add(Userr user)
        {
            if (user != null)
            {
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            Userr user = await _dbContext.users.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _dbContext.users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Userr>> GetAll()
        {
            return await _dbContext.users.ToListAsync();
        }

        public async Task<Userr> GetById(Guid id)
        {
            return await _dbContext.users.SingleOrDefaultAsync(c => c.Id == id);

        }

        public async Task<bool> Update(Userr user)
        {
            Userr userItem = await _dbContext.users.SingleOrDefaultAsync(c => c.Id == user.Id);
            if (user != null)
            {

                userItem.Name = user.Name;
                userItem.Age = user.Age;
                _dbContext.users.Update(userItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
