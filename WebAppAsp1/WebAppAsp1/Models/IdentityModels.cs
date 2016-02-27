using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TCSystemModel", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Notificationtype> NotificationType { get; set; }
        public virtual DbSet<TrainingClient> TrainingClient { get; set; }
        public virtual DbSet<GroupClient> GroupClient { get; set; }
    }
}