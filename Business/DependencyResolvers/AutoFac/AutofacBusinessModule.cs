using System;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.Jwt;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.AutoFac
{
	public class AutofacBusinessModule:Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

