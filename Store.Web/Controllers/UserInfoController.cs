using Store.Model;
using Store.Repository;
using Store.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            for (int i = 0; i < 2000; i++)
            {
                list.Add(new UserInfo
                {
                    Account = "account" + i
                });
            }
            //ViewBag.St = DateTime.Now.ToString();
            //var a = _userInfoRepository;
            //a.AddAll(list);
            //_unitOfWork.Commit();
            var a = _userInfoRepository.Get(m => m.Id == 1);
            ViewBag.Et = DateTime.Now.ToString();
            return View();
        }

        public ActionResult Update()
        {
            //var all = _userInfoRepository.GetAllLazy().AsNoTracking().ToList();
            //UserInfo userInfo = new UserInfo
            //{
            //    Id = 1,
            //    Account = "up_account1",
            //    Name = 1.ToString()
            //};
            var userInfo = _userInfoRepository.Get(m => m.Id == 1);
            userInfo.Password = "111";
            _userInfoRepository.Update(userInfo);
            _unitOfWork.Commit();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}