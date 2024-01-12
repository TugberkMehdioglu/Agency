using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Project.MVCUI.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddModelErrorWithOutKey(this ModelStateDictionary modelState, string error)
        {
            modelState.AddModelError(string.Empty, error);
        }

        public static void AddModelErrorWithOutKey(this ModelStateDictionary modelState, params string[] errors)
        {
            foreach (string item in errors)
            {
                modelState.AddModelError(string.Empty, item);
            }
        }

        public static void AddModelErrorListWithOutKey(this ModelStateDictionary modelState, IEnumerable<string> errors)
        {
            foreach (string error in errors)
            {
                modelState.AddModelError(string.Empty, error);
            }
        }

        public static void AddModelErrorListWithOutKey(this ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            foreach (IdentityError item in errors)
            {
                modelState.AddModelError(string.Empty, item.Description);
            }
        }
    }
}
