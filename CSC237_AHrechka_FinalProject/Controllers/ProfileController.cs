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
        // private fields for repositories:
        private readonly IUserRepository _userRepository;
        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly ITeacherRepository _teacherRepository;

        // DI
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
        // opens Personal Info page and passes users info from the mock repository to view:
        [Route("Profile")]
        public IActionResult PersonalInfo()
        {
            var user = _userRepository.MyUser;
            return View(user);
        }
        // opens view and fills out ViewBags to be passed to the view:
        [Route("Profile/School")]
        public IActionResult SchoolInfo()
        {
            ViewBag.Schools = _schoolRepository.GetSchools.ToList();
            ViewBag.Instruments = _instrumentRepository.GetInstruments.ToList();
            ViewBag.Teachers = _teacherRepository.GetTeachers.ToList();
            var schoolInfo = _schoolInfoRepository.MySchoolInfo;
            return View(schoolInfo);
        }
        // opens personal student's card and passes student info:
        [Route("Profile/Card")]
        public IActionResult Card()
        {
            var user = _userRepository.MyUser;
            return View(user);
        }
        // opens profile picture view:
        [Route("Profile/Picture")]
        public IActionResult ProfilePicture()
        {
            return View();
        }
        // opens practice log settings page:
        [Route("Settings/Log")]
        public IActionResult PracticeLogSettings()
        {
            return View();
        }
        // opens chat settings page:
        [Route("Settings/Chat")]
        public IActionResult ChatSettings()
        {
            return View();
        }
       // opens account settings page:
       [Route("Settings/Account")]
        public IActionResult AccountSettings()
        {
            return View();
        }
        
        

        

    }
}