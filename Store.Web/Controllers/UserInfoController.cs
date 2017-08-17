using Store.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoRepository _userInfoRepository;
        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }
        // GET: UserInfo
        public ActionResult Index()
        {
            var a = _userInfoRepository;
            var b = a.GetAll();
            return View();
        }
    }
}