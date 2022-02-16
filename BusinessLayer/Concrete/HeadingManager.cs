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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeading(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void DeleteHeading(Heading heading)
        {
            heading.HeadingStatus = false;
            _headingDal.Update(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetHeadings()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetHeadingsByWriter(int id)
        {
            return _headingDal.GetAll(x => x.WriterId == id).Where(y => y.HeadingStatus == true).ToList();
        }

        public void UptadeHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
