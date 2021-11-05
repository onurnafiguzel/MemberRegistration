using MemberRegistration.Entities.Concrete;
using MemberRegistration.Business.KpsServiceReference;
using System;

namespace MemberRegistration.Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool ValidateUser(Member member)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcNo), member.FirstName.ToUpper(), member.LastName.ToUpper(), member.DateOfBirth.Year);
        }
    }
}
