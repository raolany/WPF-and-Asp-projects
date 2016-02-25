using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebAppAsp1.Models;

[assembly: OwinStartupAttribute(typeof(WebAppAsp1.Startup))]
namespace WebAppAsp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //var db = ApplicationDbContext.Create();
            //var userStore = new UserStore<ApplicationUser>(db);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            //if (!db.Users.Any(a => (a.UserName == "admin@admin.com")))
            //{
            //    var user = new ApplicationUser {UserName = "admin@admin.com", Email = "admin@admin.com"};
            //    var result = userManager.Create(user, "admin");
            //    if(result.Succeeded) userManager.AddToRole(user.Id, "Admin");
            //}
        }
    }
}
