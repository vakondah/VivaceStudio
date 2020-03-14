using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSC237_AHrechka_FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public ProfileController(IUserRepository userRepository,
                                 ISchoolInfoRepository schoolInfoRepository,
                                 ISchoolRepository schoolRepository,
                                 IInstrumentRepository instrumentRepository,
                                  ITeacherRepository teacherRepository)
        {
            _userRepository = userRepository;
            _schoolInfoRepository = schoolInfoRepository;
            _schoolRepository = schoolRepository;
            _instrumentRepository = instrumentRepository;
            _teacherRepository = teacherRepository;
        }
        public IActionResult PersonalInfo()
        {
            var user = _userRepository.MyUser;
            return View(user);
        }
        public IActionResult SchoolInfo()
        {
            ViewBag.Schools = _schoolRepository.GetSchools.ToList();
            ViewBag.Instruments = _instrumentRepository.GetInstruments.ToList();
            ViewBag.Teachers = _teacherRepository.GetTeachers.ToList();
            var schoolInfo = _schoolInfoRepository.MySchoolInfo;
            return View(schoolInfo);
        }
        public IActionResult Card()
        {
            return View();
        }
        

        

    }
}