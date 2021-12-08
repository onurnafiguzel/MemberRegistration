﻿using Ninject;

namespace MemberRegistration.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstace<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
