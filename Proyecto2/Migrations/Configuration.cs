namespace Proyecto2.Migrations
{
    using Proyecto2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Proyecto2.Models.ApplicationDbContext context)
        {
            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;


            var newUser = new Users()
            {
                UserName = "Admin",
                Dpi = "3057250680301",
                Nombre = "Jorge Antonio",
                Apellido = "Monterroso Aspuac",
                Email = "admin@bgf.com",
                Direccion = "San Lucas Sacatep�quez",
                Telefono = "34563214",
                Referencia1 = "Juan Lopez",
                TelefonoReferencia1 = "59302965",
                Referencia2 = "Bryam Paniagua",
                TelefonoReferencia2 = "24755102"
            };

            success = idManager.CreateUser(newUser, "Kinal2015");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
