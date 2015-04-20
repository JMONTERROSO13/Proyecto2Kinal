using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2.Models
{
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña Actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage =
            "La {0} debe tener al menos {2} carácteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nueva Contraseña")]
        [Compare("NewPassword", ErrorMessage =
            "La nueva contraseña y la confirmación de contraseña no coinciden")]
        public string ConfirmPassword { get; set; }
    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nombre De Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recuerdame?")]
        public bool RememberMe { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre De Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage =
            "La {0} debe tener al menos {2} carácteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar  Contraseña")]
        [Compare("Password", ErrorMessage =
            "La nueva contraseña y la confirmación de contraseña no coinciden")]
        public string ConfirmPassword { get; set; }

        // New Fields added to extend Application User class:
        [Required]
        [StringLength(13)]
        [Display(Name = "Identificación Personal(DPI)")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un DPI correcto")]
        public string Dpi { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }
         
        [Required]
        [StringLength(200, MinimumLength = 20)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 8)]
        [Display(Name = "Teléfono")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Nombre Primer Referencia")]
        public string Referencia1 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "Telfono Primer Referencia")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia1 { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Nombre Segunda Referencia")]
        public string Referencia2 { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 8)]
        [Display(Name = "Teléfono Segunda Referencia")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia2 { get; set; }

        // Return a pre-poulated instance of AppliationUser:
        public Users GetUser()
        {
            var user = new Users()
            {
                UserName = this.UserName,
                Email = this.Email,
                Dpi = this.Dpi,
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Direccion = this.Direccion,
                Telefono = this.Telefono,
                Referencia1 = this.Referencia1,
                Referencia2 = this.Referencia2,
                TelefonoReferencia1 = this.TelefonoReferencia1,
                TelefonoReferencia2 = this.TelefonoReferencia2
            };
            return user;
        }
    }


    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of Users:
        public EditUserViewModel(Users user)
        {
                this.UserName = user.UserName;
                this.Email = user.Email;
                this.Dpi = user.Dpi;
                this.Nombre = user.Nombre;
                this.Apellido = user.Apellido;
                this.Direccion = user.Direccion;
                this.Telefono = user.Telefono;
                this.Referencia1 = user.Referencia1;
                this.Referencia2 = user.Referencia2;
                this.TelefonoReferencia1 = user.TelefonoReferencia1;
                this.TelefonoReferencia2 = user.TelefonoReferencia2;
        }
        
        [Required]
        [Display(Name = "Nombre De Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(13)]
        [Display(Name = "Identificación Personal(DPI)")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un DPI correcto")]
        public string Dpi { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 20)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 8)]
        [Display(Name = "Teléfono")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Nombre Primer Referencia")]
        public string Referencia1 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "Telfono Primer Referencia")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia1 { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Nombre Segunda Referencia")]
        public string Referencia2 { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 8)]
        [Display(Name = "Teléfono Segunda Referencia")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia2 { get; set; }
    }


    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of Users:
        public SelectUserRolesViewModel(Users user)
            : this()
        {
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Dpi = user.Dpi;
            this.Nombre = user.Nombre;
            this.Apellido = user.Apellido;
            this.Direccion = user.Direccion;
            this.Telefono = user.Telefono;
            this.Referencia1 = user.Referencia1;
            this.Referencia2 = user.Referencia2;
            this.TelefonoReferencia1 = user.TelefonoReferencia1;
            this.TelefonoReferencia2 = user.TelefonoReferencia2;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                checkUserRole.Selected = true;
            }
        }
        public string UserName { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Referencia1 { get; set; } 
        public string Referencia2 { get; set; }
        public string TelefonoReferencia1 { get; set; }
        public string TelefonoReferencia2 { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
