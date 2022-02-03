using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AddAbout(About about)
        {
            _aboutDal.Add(about);
        }

        public void DeleteAbout(About about)
        {
            _aboutDal.Delete(about);
        }

        public List<About> GetAbouts()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public void UpdateAbout(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
