using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.LaSoTuVi.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        //public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        //{
        //    builder.RegisterType<Nop.Plugin.LaSoTuVi.Controllers.
        //    HomeController>().As<Nop.Web.Controllers.HomeController>();
        //}

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //builder.RegisterType<Nop.Plugin.LaSoTuVi.Controllers.
            //TVHomeController>().As<Nop.Web.Controllers.HomeController>();
        }

        public int Order
        {
            get { return 100; }
        }
    }
}
