using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.Extensions;
using SignalR.WEB_Food.Models;

namespace SignalR.WEB_Food.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.Select(x => new ResultRoleViewModel
            {
                Id = x.Id,
                Name = x.Name!
            }).ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole()
            {
                Name = request.Name,
            });

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }
            return RedirectToAction(nameof(RolesController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(id);
            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Rol Bulunamamıştır.");
            }
            return View(new UpdateRoleViewModel
            {
                Id = roleToUpdate!.Id.ToString(),
                Name = roleToUpdate.Name!
            });
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(UpdateRoleViewModel request)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Rol Bulunamamıştır.");
            }


            roleToUpdate!.Name = request.Name;
            await _roleManager.UpdateAsync(roleToUpdate);
            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> RoleDelete(string id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(id);

            if (roleToDelete == null)
            {
                throw new Exception("Silinecek Rol Bulunamamıştır.");
            }

            var result = await _roleManager.DeleteAsync(roleToDelete);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(x => x.Description).First());
            }
            return RedirectToAction(nameof(RolesController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = await _userManager.FindByIdAsync(id);
            ViewBag.userId = id;
            var roles = await _roleManager.Roles.ToListAsync();
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            var userRoles = await _userManager.GetRolesAsync(currentUser!);

            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel() { Id = role.Id, Name = role.Name! };

                if (userRoles.Contains(role.Name!))
                {
                    assignRoleToUserViewModel.Exist = true;
                }

                roleViewModelList.Add(assignRoleToUserViewModel);
            }
            return View(roleViewModelList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(List<AssignRoleToUserViewModel> requestList, string userId)
        {
            var userToAssignRole = (await _userManager.FindByIdAsync(userId))!;
            foreach (var role in requestList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToAssignRole, role.Name);//gelen rolü ekle
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssignRole, role.Name);//rolü sil
                }
            }
            return RedirectToAction(nameof(AdminLayoutController.UserList), "AdminLayout");
        }
    }
}
