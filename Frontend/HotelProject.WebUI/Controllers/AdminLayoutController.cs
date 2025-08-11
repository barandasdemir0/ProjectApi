using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
        public PartialViewResult _NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarNotificationPartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarLanguagePartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarProfilePartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarMessagePartial()
        {
            return PartialView();
        }
        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _SidebarPartPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SidebarLogoPartial()
        {
            return PartialView();
        }

        public PartialViewResult _SidebarProfilePartial()
        {
            return PartialView();
        }
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
    }
}
