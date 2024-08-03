using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent.EstateAgentNavbar
{
    public class _EstateAgentNavbarMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
