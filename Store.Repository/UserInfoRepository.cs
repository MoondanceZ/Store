using Store.Model;
using Store.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Model.DbContext;

namespace Store.Repository
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
