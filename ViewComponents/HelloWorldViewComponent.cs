using System;
using Microsoft.AspNetCore.Mvc;
using SitefinityWeb.Entities.HelloWorld;
using Progress.Sitefinity.AspNetCore.ViewComponents;

namespace SitefinityWeb.ViewComponents
{
    [SitefinityWidget ]
    public class HelloWorldViewComponent : ViewComponent
    {
        // Invokes the view.
        public IViewComponentResult Invoke(IViewComponentContext<HelloWorldEntity> context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return this.View(context.Entity);
        }
    }
}