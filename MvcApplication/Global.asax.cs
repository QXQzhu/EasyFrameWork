﻿using Easy.IOC;
using Easy.Web.Application;
using MvcApplication.Tasks;

namespace MvcApplication
{

    public class MvcApplication : UnityMvcApplication
    {
        public override void Application_Starting()
        {
            TaskManager
                .Include<ConfigTask>()
                .Include<ResourceTask>();
        }
    }
    public class WebModule : IModule
    {
        public void Load(IContainerAdapter adapter)
        {
            
        }
    }

}