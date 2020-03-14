using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface ISchoolInfoRepository
    {
        // this property will be used only while working with mock repositories:
        public SchoolInfo MySchoolInfo { get; }


        public IEnumerable<SchoolInfo> GetSchoolInfo { get; }
        SchoolInfo GetSchoolInfoByStudentId(int studentId);
    }
}
