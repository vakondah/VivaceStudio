using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class MockUserRepository : IUserRepository
    {
        public User MyUser => new User
        {
            UserID = 1,
            FirstName = "Aliaksandra",
            LastName = "Hrechka",
            DateOfBirth = DateTime.Parse("2000-01-08"),
            Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus." +
            " Praesent aliquam in tellus eu.",
            Address = "9999 E Orange St, Aurora, CO, 80011",
            Email = "ahrechka@mail.com",
            Phone = "970-777-7777"
        };

        public IEnumerable<User> GetUsers => throw new NotImplementedException();// users will be added when seeding database

        public User GetUserById(int userId)
        {
            return GetUsers.FirstOrDefault(u => u.UserID == userId);
        }
    }
}
