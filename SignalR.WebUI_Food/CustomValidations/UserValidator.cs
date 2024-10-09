﻿using Microsoft.AspNetCore.Identity;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.WEB_Food.CustomValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _);

            if (isDigit)
            {
                errors.Add(new()
                {
                    Code = "UserNameContainFirstLetterDigit",
                    Description = "Kullanıcı Adının İlk Karekteri Sayısal Bir Karekter İçeremez"
                });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
