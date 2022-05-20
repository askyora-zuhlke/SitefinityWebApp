using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using SitefinityWebApp.Dto;

namespace SitefinityWeb.ViewComponents
{

    [SitefinityWidget]
    public class SingaporePsiViewComponent : ViewComponent
    {
        private static readonly HttpClient client = new HttpClient();
        private static Psi psi;
        private static DateTime lastUpdated;


        // Invokes the view.
        public IViewComponentResult Invoke(IViewComponentContext<Psi> context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            getAndReplacePsiObject();
            return this.View(psi);
        }

        private void getAndReplacePsiObject()
        {
            long elapsedTicks = DateTime.Now.Ticks - lastUpdated.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

            if (psi == null || lastUpdated == null || elapsedSpan.Seconds >= 60)
            {
                String jsonString = client.GetStringAsync("https://api.data.gov.sg/v1/environment/psi").Result;
                if (jsonString != null)
                {
                    psi = JsonConvert.DeserializeObject<Psi>(jsonString);
                    lastUpdated = DateTime.Now;
                }
            }
        }
    }
}