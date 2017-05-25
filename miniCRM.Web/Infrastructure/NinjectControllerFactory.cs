using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using miniCRM.Data;
using miniCRM.Data.Abstract;
using miniCRM.Data.Entities;

namespace miniCRM.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IBaseRepository<Employe>>().To<MainBaseRepository<Employe>>();
            ninjectKernel.Bind<IBaseRepository<Act>>().To<MainBaseRepository<Act>>();
        }
    }
}