using Store.Model;
using Store.Repository;
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
        IUnitOfWork _unitOfWork;
        public UserInfoController(IUserInfoRepository userInfoRepository, IUnitOfWork unitOfWork)
        {
            _userInfoRepository = userInfoRepository;
            _unitOfWork = unitOfWork;
        }
        // GET: UserInfo
        public ActionResult Index()
        {

            List<UserInfo> list = new List<UserInfo>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new UserInfo
                {
                    Account = "account" + i
                });
            }
            ViewBag.St = DateTime.Now.ToString();
            // var a = _userInfoRepository;
            //a.AddAll(list);
            // _unitOfWork.Commit();
            ViewBag.Et = DateTime.Now.ToString();
            return View();
        }
    }
}