using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SignalR.API_Food_EntityLayer.Entities;
using System.Text;

namespace SignalR.WEB_Food.TagHelpers
{
    public class UserRolesNamesTagHelper : TagHelper
    {
        public string UserId { get; set; } = null!;
        private readonly UserManager<AppUser> _userManager;

        public UserRolesNamesTagHelper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(user!);

            var stringBuilder = new StringBuilder();

            userRoles.ToList().ForEach(x =>
            {
                stringBuilder.Append(@$"<span class='badge bg-success mr-1'>{x.ToLower()}</span>");
            });

            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
