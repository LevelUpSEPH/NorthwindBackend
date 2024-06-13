using System;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.AutoFac
{
	public class AutofacBusinessModule:Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfProductDal>().As<IProductDal>();
        }
    }
}

