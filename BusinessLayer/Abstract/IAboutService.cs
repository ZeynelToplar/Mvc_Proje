using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAbouts();
        void AddAbout(About about);
        About GetById(int id);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
    }
}
