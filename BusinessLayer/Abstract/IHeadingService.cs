using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadings();
        void AddHeading(Heading heading);
        Heading GetById(int id);
        void DeleteHeading(Heading heading);
        void UptadeHeading(Heading heading);
    }
}
