using Gilde.SchietScore.Data;
using Microsoft.AspNetCore.Identity;

namespace Gilde.SchietScore.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<SchietScoreUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<SchietScoreUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
