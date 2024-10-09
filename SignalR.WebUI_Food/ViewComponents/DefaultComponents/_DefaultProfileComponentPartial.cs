using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.ViewModels.UserViewModels;

namespace SignalR.WEB_Food.ViewComponents.DefaultComponents
{
    public class _DefaultProfileComponentPartial : ViewComponent
    {
        private UserManager<AppUser> _userManager;

        public _DefaultProfileComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var userViewModel = new UpdateUserViewModel
            {
                Mail = currentUser!.Email!,
                Username = currentUser!.UserName!,
                Name = currentUser!.Name,
                Surname = currentUser!.Surname,
                Phone = currentUser!.PhoneNumber,
                City = currentUser!.City,
                Gender = currentUser!.Gender,
            };
            return View(userViewModel);
        }
    }
}
