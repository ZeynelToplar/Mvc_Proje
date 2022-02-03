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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void AddSkill(Skill skill)
        {
            _skillDal.Add(skill);
        }

        public void DeleteSkill(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillId == id);
        }

        public List<Skill> GetSkills()
        {
            return _skillDal.GetAll();
        }

        public void UpdateSkill(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
