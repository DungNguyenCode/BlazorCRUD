using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IUser
    {
        public Task<List<Userr>> GetAll();
        public Task<Userr> GetById(Guid id);
        public Task<bool> Add(Userr user);
        public Task<bool> Update(Userr user);
        public Task<bool> Delete(Guid id);
    }
}
