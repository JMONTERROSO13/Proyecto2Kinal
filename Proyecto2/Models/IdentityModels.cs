using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2.Models
{
    public class Users : IdentityUser
    {
        [Required]
        [StringLength(13)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un DPI correcto")]
        public string Dpi { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 20)]
        public string Direccion { get; set; }
         
        [Required]
        [StringLength(11, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Referencia1 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia1 { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Referencia2 { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia2 { get; set; }

        public virtual ICollection<Cuenta> Cuentas { get; set; }
        public virtual ICollection<CuentaAhorro> CuentasAhorro { get; set; }
        public virtual ICollection<CuentaMonetaria> CuentasMonetarias { get; set; }

    }


    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
    }


    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(Users user, string password)
        {
            var um = new UserManager<Users>(
                new UserStore<Users>(new ApplicationDbContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<Users>(
                new UserStore<Users>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<Users>(
                new UserStore<Users>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.Role.Name);
            }
        }
    }
}