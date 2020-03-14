using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class MockSchoolInfoRepository : ISchoolInfoRepository
    {
        public SchoolInfo MySchoolInfo => new SchoolInfo
        {
            StudentID = 123123,
            MockSchoolName = "Harmony School of Music",
            MockInstrument = "Guitar",
            MockTeacher = "Mr. Rusinn",
            MyClasses = "Guitar, piano, choir"
        };

        public IEnumerable<SchoolInfo> GetSchoolInfo => throw new NotImplementedException();

        public SchoolInfo GetSchoolInfoByStudentId(int studentId)
        {
            return GetSchoolInfo.FirstOrDefault(i => i.StudentID == studentId);
        }
    }
}
