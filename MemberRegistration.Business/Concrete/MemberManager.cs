using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;

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

        public void Add(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kullanıcı reel değil!");
            }
            _memberDal.Add(member);
        }
    }
}
