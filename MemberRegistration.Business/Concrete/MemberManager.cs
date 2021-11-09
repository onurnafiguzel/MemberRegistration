using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using MemberRegistration.Business.ValidationRules.FluentValidation;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            CheckIfMemberExists(member);
            CheckIfUserValidFromKps(member);
            _memberDal.Add(member);
        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kullanıcı reel değil!");
            }
        }

        private void CheckIfMemberExists(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur!");
            }
        }
    }
}
