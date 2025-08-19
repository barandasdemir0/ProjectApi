using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        //RoleInsert
        [HttpGet]
        public IActionResult RoleInsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleInsert(AddRoleViewModel addRole)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRole.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();


        }


        //RoleDelete
   
        public async Task<IActionResult> RoleDelete(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }





        //RoleUpdate

        [HttpGet]
        public IActionResult RoleUpdate(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel addRole = new UpdateRoleViewModel()
            {
                RoleId = values.Id,
                RoleName = values.Name
            };
            return View(addRole);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(UpdateRoleViewModel updateRole)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRole.RoleId);
            values.Name = updateRole.RoleName;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
