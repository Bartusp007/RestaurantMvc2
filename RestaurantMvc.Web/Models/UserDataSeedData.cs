using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RestaurantMvc.Web.Models
{
    public class UserDataSeedData:DropCreateDatabaseIfModelChanges<IdentityModels.ApplicationDbContext>
    {
        protected override void Seed(IdentityModels.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "admin" });
            }
            if (!context.Roles.Any(r => r.Name == "user"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "user" });
            }

            if (!context.Roles.Any(r => r.Name == "staff"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "staff" });
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<IdentityModels.ApplicationUser>(context);
                var manager = new UserManager<IdentityModels.ApplicationUser>(store);
                var user = new IdentityModels.ApplicationUser {UserName = "admin@admin.comm", Email = "admin@admin.com", EmailConfirmed = false, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 };
                manager.Create(user, "Password@1");
                manager.AddToRole(user.Id, "admin");
            }
            if (!context.Users.Any(u => u.UserName == "user@user.com"))
            {
                var store = new UserStore<IdentityModels.ApplicationUser>(context);
                var manager = new UserManager<IdentityModels.ApplicationUser>(store);
                var user = new IdentityModels.ApplicationUser {UserName = "user@user.com", Email = "user@user.com", EmailConfirmed = false, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 };
                manager.Create(user, "Password@1");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(u => u.UserName == "staff@staff.com"))
            {
                var store = new UserStore<IdentityModels.ApplicationUser>(context);
                var manager = new UserManager<IdentityModels.ApplicationUser>(store);
                var user = new IdentityModels.ApplicationUser {UserName = "staff@staff.com", Email = "staff@staff.com", EmailConfirmed = false, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 };
                manager.Create(user, "Password@1");
                manager.AddToRole(user.Id, "staff");
            }

        }
    }
}