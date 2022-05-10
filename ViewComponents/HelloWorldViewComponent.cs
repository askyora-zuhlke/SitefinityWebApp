

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SitefinityWeb.Entities;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using SitefinityWebApp.Dto;

namespace SitefinityWeb.ViewComponents
{
    [SitefinityWidget]
    public class HelloWorldViewComponent : ViewComponent
    {
        
        private static readonly HttpClient client = new HttpClient();

        // Invokes the view.
        public IViewComponentResult Invoke(IViewComponentContext<HelloWorldEntity> context)
        {
           

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Entity.Message = "Change by Widget";
            
            return this.View(context.Entity);
        }
        
        
        
    }
}