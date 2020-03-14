using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class MockTeacherRepository : ITeacherRepository
    {
        public IEnumerable<Teacher> GetTeachers =>
            new List<Teacher>
            {
                new Teacher
                {
                    TeacherID = 1,
                    FirstName = "Andrew",
                    LastName = "Rusinn",
                    Phone = "720 666-4567"
                },
                new Teacher
                {
                    TeacherID = 2,
                    FirstName = "Maria",
                    LastName = "Ortega",
                    Phone = "720 122-0809"
                },
                new Teacher
                {
                    TeacherID = 3,
                    FirstName = "Lorena",
                    LastName = "Kirkland",
                    Phone = "720 898-3839"
                },
                new Teacher
                {
                    TeacherID = 4,
                    FirstName = "Olga",
                    LastName = "Kostenko",
                    Phone = "303 920 1764"
                },
                new Teacher
                {
                    TeacherID = 5,
                    FirstName = "John",
                    LastName = "Stivens",
                    Phone = "720 009-1890"
                }

            };

        public Teacher GetTeacherById(int teacherId)
        {
            return GetTeachers.FirstOrDefault(t => t.TeacherID == teacherId);
        }
    }
}
