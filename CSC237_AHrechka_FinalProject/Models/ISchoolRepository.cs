using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface ISchoolRepository
    {
        School MySchool { get; }
        IEnumerable<School> GetSchools { get; }
        School GetSchoolById(int schoolId);
    }
}
