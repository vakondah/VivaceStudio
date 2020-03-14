using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface ITeacherRepository
    {
        public IEnumerable<Teacher> GetTeachers { get; }
        Teacher GetTeacherById(int teacherId);
    }
}
