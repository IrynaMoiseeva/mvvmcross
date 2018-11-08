using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

using MvvmCross_Application1.Core.Services;

namespace MvvmCross_Application1.Core.Module
{
    public class MyModule : Autofac.Module

    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<PlatformService>().As<IPlatformService>();
        }
    }
    public class MappedTypeModule : Autofac.Module
    {
        private Dictionary<Type, Type> _mappedtypes;
        public MappedTypeModule(Dictionary<Type, Type> mappedtypes)
        {
            _mappedtypes = mappedtypes;

        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var mappedtype in _mappedtypes)
            {
               builder.RegisterType(mappedtype.Key).As(mappedtype.Value);
            }
            
        }
    }
}
