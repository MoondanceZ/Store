﻿using Store.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store.Web.ControllerFactory
{
    public class AutofacControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Called by MVC system and creates controller instance for given controller type.
        /// </summary>
        /// <param name="requestContext">Request context</param>
        /// <param name="controllerType">Controller type</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            return IocContainer.Resolve(controllerType) as IController;
        }
    }
}