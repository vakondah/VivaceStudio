using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class MockSchoolRepository : ISchoolRepository
    {

        public IEnumerable<School> GetSchools => 
            new List<School>
            {
                new School
                {
                    SchoolID = 1,
                    SchoolName = "Rock Academy"
                },
                new School
                {
                    SchoolID = 2,
                    SchoolName = "Harmony School of Music"
                },
                new School
                {
                    SchoolID = 3,
                    SchoolName = "Centennial Piano School"
                }
            };

        public School GetSchoolById(int schoolId)
        {
            return GetSchools.FirstOrDefault(s => s.SchoolID == schoolId);
        }
    }
}
