namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TCSystemModel : DbContext
    {
        public TCSystemModel()
            : base("name=TCSystemModel")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupClient> GroupClient { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Notificationtype> Notificationtype { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<TrainerClient> TrainerClient { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingClient> TrainingClient { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.GroupClient)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.TrainerClient)
                .WithRequired(e => e.Client1)
                .HasForeignKey(e => e.client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.TrainingClient)
                .WithRequired(e => e.Client1)
                .HasForeignKey(e => e.client)
                .WillCascadeOnDelete(false);

            //?e.Client cl
            modelBuilder.Entity<Client>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Client1)
                .HasForeignKey(e => e.Client);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupClient)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<Notificationtype>()
                .HasMany(e => e.Notification)
                .WithRequired(e => e.Notificationtype)
                .HasForeignKey(e => e.type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Group)
                .WithRequired(e => e.Trainer1)
                .HasForeignKey(e => e.trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.TrainerClient)
                .WithRequired(e => e.Trainer1)
                .HasForeignKey(e => e.trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Training)
                .WithRequired(e => e.Trainer1)
                .HasForeignKey(e => e.trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Trainer1)
                .HasForeignKey(e => e.Trainer);

            modelBuilder.Entity<Training>()
                .HasMany(e => e.Group)
                .WithRequired(e => e.Training1)
                .HasForeignKey(e => e.training)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Training>()
                .HasMany(e => e.TrainingClient)
                .WithRequired(e => e.Training1)
                .HasForeignKey(e => e.training)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notification)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notification1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.sender)
                .WillCascadeOnDelete(false);
        }

        public static TCSystemModel Create()
        {
            return new TCSystemModel();
        }
    }
}
