using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMemberService memberService = InstanceFactory.GetInstace<IMemberService>();
            memberService.Add(new Member { FirstName = "Onur", LastName = "Güzel", DateOfBirth = new DateTime(1998, 5, 20), TcNo = "12345678900", Email = "ongguzel@gmail.com" }); // Doğru bilgilerle test edildi, çalışıyor.
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
