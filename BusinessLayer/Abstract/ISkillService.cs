using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetSkills();
        void AddSkill(Skill skill);
        Skill GetById(int id);
        void DeleteSkill(Skill skill);
        void UpdateSkill(Skill skill);
    }
}
