using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface IUserRepository
    {
        User MyUser { get; }
        IEnumerable<User> GetUsers { get; }
        User GetUserById(int userId);
    }
}
