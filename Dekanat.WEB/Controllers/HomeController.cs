using AutoMapper;
using Dekanat.BLL.DTO;
using Dekanat.BLL.Interfaces;
using Dekanat.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dekanat.WEB.Controllers
{
    public class HomeController : Controller
    {
        IStudentService studentService;
        IGroupService groupService;
        IDormitoryService dormitoryService;

        public HomeController(IStudentService studentService, IGroupService groupService, IDormitoryService dormitoryService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.dormitoryService = dormitoryService;
        }

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult StudentNameSearch(string nam)
        {
            List<StudentDTO> studDtos = studentService.SearchByName(nam);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            var newst = mapper.Map<List<StudentDTO>, List<StudentViewModel>>(studDtos);

            if (newst == null)
            {
                return HttpNotFound();
            }
            return View(newst);
        }

        public ActionResult GroupNameSearch(string nam)
        {
            List<GroupDTO> groupDtos = groupService.SearchByName(nam);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupViewModel>()).CreateMapper();
            var newgr = mapper.Map<List<GroupDTO>, List<GroupViewModel>>(groupDtos);

            if (newgr == null)
            {
                return HttpNotFound();
            }
            return View(newgr);
        }

        public ActionResult DormitoryNumberSearch(int num)
        {
            List<DormitoryDTO> dormDtos = dormitoryService.SearchByName(num);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DormitoryDTO, DormitoryViewModel>()).CreateMapper();
            var newdorms = mapper.Map<List<DormitoryDTO>, List<DormitoryViewModel>>(dormDtos);

            if (newdorms == null)
            {
                return HttpNotFound();
            }
            return View(newdorms);
        }


    }
}