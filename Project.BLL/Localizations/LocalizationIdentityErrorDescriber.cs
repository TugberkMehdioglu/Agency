using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new() { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifre özel karakterlerden en az birini içermelidir (*? vb.)" };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new() { Code = "PasswordRequiresDigit", Description = "Şifre rakam içermelidir" };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new() { Code = "PasswordRequiresLower", Description = "Şifre küçük karakter içermelidir" };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new() { Code = "PasswordRequiresUpper", Description = "Şifre büyük karakter içermelidir" };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"{email} daha önce başka bir kullanıcı tarafından alınmıştır" };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"{userName} daha önce başka bir kullanıcı tarafından alınmıştır" };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new() { Code = "InvalidEmail", Description = $"{email} formatı geçersizdir" };
        }

        public override IdentityError InvalidToken()
        {
            return new() { Code = "InvalidToken", Description = $"Geçersiz token" };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new() { Code = "InvalidUserName", Description = $"{userName} gerçersiz bir kullanıcı adıdır" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = $"Şifre en az {length} karakter olmalıdır" };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new() { Code = "DuplicateRoleName", Description = $"{role} rolü zaten mevcuttur" };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new() { Code = "InvalidRoleName", Description = $"{role} geçersiz bir rol adıdır" };
        }

        public override IdentityError PasswordMismatch()
        {
            return new() { Code = "PasswordMismatch", Description = $"Şifre yanlış" };
        }

        //------------------------------------------------

        public override IdentityError ConcurrencyFailure()
        {
            return new() { Code = "ConcurrencyFailure", Description = "Eşzamanlılık sorunu oluştu" };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new() { Code = "LoginAlreadyAssociated", Description = "Giriş zaten yapıldı" };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new() { Code = "PasswordRequiresUniqueChars", Description = "Şifre benzersiz karakterlerden oluşmalıdır" };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new() { Code = "RecoveryCodeRedemptionFailed", Description = "Kurtarma kodu kullanımı başarısız" };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new() { Code = "UserAlreadyHasPassword", Description = "Kullanıcının şifresi zaten mevcut" };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new() { Code = "UserAlreadyInRole", Description = $"Kullanıcı zaten {role} rolüne sahip" };
        }
        public override IdentityError UserLockoutNotEnabled()
        {
            return new() { Code = "UserLockoutNotEnabled", Description = $"Lockout mekanizması etkin değil" };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new() { Code = "UserNotInRole", Description = $"Kullanıcı {role} rolüne sahip değil" };
        }
    }
}
