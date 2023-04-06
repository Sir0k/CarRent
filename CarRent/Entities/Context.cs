using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CarRent.Entities
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=CarRentSettings")
        {
        }

        public virtual DbSet<AvailableCars> AvailableCars { get; set; }
        public virtual DbSet<CarInRent> CarInRent { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableCars>()
                .Property(e => e.brand)
                .IsFixedLength();

            modelBuilder.Entity<AvailableCars>()
                .Property(e => e.model)
                .IsFixedLength();

            modelBuilder.Entity<AvailableCars>()
                .Property(e => e.engine)
                .IsFixedLength();

            modelBuilder.Entity<AvailableCars>()
                .Property(e => e.body)
                .IsFixedLength();

            modelBuilder.Entity<AvailableCars>()
                .Property(e => e.color)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.surname)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.patronymic)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.city)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.adress)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.phone_number)
                .IsFixedLength();

            modelBuilder.Entity<Roles>()
                .Property(e => e.role)
                .IsFixedLength();

            modelBuilder.Entity<Roles>()
                .Property(e => e.salary)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.surname)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.patronymic)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.role)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.login)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.password)
                .IsFixedLength();
        }
    }
}
