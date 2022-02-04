using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        IAdminDal _adminDal;
        IWriterDal _writerDal;

        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin Login(string userName, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}
