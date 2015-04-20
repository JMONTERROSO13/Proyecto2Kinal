namespace Proyecto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Dpi = c.String(maxLength: 13),
                        Nombre = c.String(maxLength: 60),
                        Apellido = c.String(maxLength: 60),
                        Email = c.String(),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 11),
                        Referencia1 = c.String(maxLength: 100),
                        TelefonoReferencia1 = c.String(maxLength: 10),
                        Referencia2 = c.String(maxLength: 100),
                        TelefonoReferencia2 = c.String(maxLength: 12),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombreCuenta = c.String(maxLength: 10),
                        TipoID = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Prestamoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentaMonetariaId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cuenta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaMonetarias", t => t.CuentaMonetariaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuentas", t => t.Cuenta_Id)
                .Index(t => t.CuentaMonetariaId)
                .Index(t => t.Cuenta_Id);
            
            CreateTable(
                "dbo.CuentaMonetarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombreCuenta = c.String(maxLength: 10),
                        TipoID = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.TarjetaDebitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numeroTarjeta = c.String(),
                        credito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        usoCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaMonetariaId = c.Int(nullable: false),
                        Pin = c.String(maxLength: 10),
                        Cuenta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaMonetarias", t => t.CuentaMonetariaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuentas", t => t.Cuenta_Id)
                .Index(t => t.CuentaMonetariaId)
                .Index(t => t.Cuenta_Id);
            
            CreateTable(
                "dbo.AbonoDebitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TarjetaDebitoId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TarjetaDebitoes", t => t.TarjetaDebitoId, cascadeDelete: true)
                .Index(t => t.TarjetaDebitoId);
            
            CreateTable(
                "dbo.RetiroDebitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TarjetaDebitoId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TarjetaDebitoes", t => t.TarjetaDebitoId, cascadeDelete: true)
                .Index(t => t.TarjetaDebitoId);
            
            CreateTable(
                "dbo.TarjetaCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numeroTarjeta = c.String(),
                        credito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        usoCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaMonetariaId = c.Int(nullable: false),
                        Pin = c.String(maxLength: 10),
                        Cuenta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaMonetarias", t => t.CuentaMonetariaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuentas", t => t.Cuenta_Id)
                .Index(t => t.CuentaMonetariaId)
                .Index(t => t.Cuenta_Id);
            
            CreateTable(
                "dbo.CargoCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentaMonetariaId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TarjetaCredito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaMonetarias", t => t.CuentaMonetariaId, cascadeDelete: true)
                .ForeignKey("dbo.TarjetaCreditoes", t => t.TarjetaCredito_Id)
                .Index(t => t.CuentaMonetariaId)
                .Index(t => t.TarjetaCredito_Id);
            
            CreateTable(
                "dbo.PagoCreditoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TarjetaCreditoId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TarjetaCreditoes", t => t.TarjetaCreditoId, cascadeDelete: true)
                .Index(t => t.TarjetaCreditoId);
            
            CreateTable(
                "dbo.CuentaAhorroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombreCuenta = c.String(maxLength: 10),
                        TipoID = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.AbonoAhorroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentaAhorroId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaAhorroes", t => t.CuentaAhorroId, cascadeDelete: true)
                .Index(t => t.CuentaAhorroId);
            
            CreateTable(
                "dbo.RetiroAhorroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuentaAhorroId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 10),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CuentaAhorroes", t => t.CuentaAhorroId, cascadeDelete: true)
                .Index(t => t.CuentaAhorroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuentaMonetarias", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CuentaAhorroes", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RetiroAhorroes", "CuentaAhorroId", "dbo.CuentaAhorroes");
            DropForeignKey("dbo.AbonoAhorroes", "CuentaAhorroId", "dbo.CuentaAhorroes");
            DropForeignKey("dbo.Cuentas", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TarjetaCreditoes", "Cuenta_Id", "dbo.Cuentas");
            DropForeignKey("dbo.TarjetaDebitoes", "Cuenta_Id", "dbo.Cuentas");
            DropForeignKey("dbo.Prestamoes", "Cuenta_Id", "dbo.Cuentas");
            DropForeignKey("dbo.PagoCreditoes", "TarjetaCreditoId", "dbo.TarjetaCreditoes");
            DropForeignKey("dbo.TarjetaCreditoes", "CuentaMonetariaId", "dbo.CuentaMonetarias");
            DropForeignKey("dbo.CargoCreditoes", "TarjetaCredito_Id", "dbo.TarjetaCreditoes");
            DropForeignKey("dbo.CargoCreditoes", "CuentaMonetariaId", "dbo.CuentaMonetarias");
            DropForeignKey("dbo.RetiroDebitoes", "TarjetaDebitoId", "dbo.TarjetaDebitoes");
            DropForeignKey("dbo.TarjetaDebitoes", "CuentaMonetariaId", "dbo.CuentaMonetarias");
            DropForeignKey("dbo.AbonoDebitoes", "TarjetaDebitoId", "dbo.TarjetaDebitoes");
            DropForeignKey("dbo.Prestamoes", "CuentaMonetariaId", "dbo.CuentaMonetarias");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RetiroAhorroes", new[] { "CuentaAhorroId" });
            DropIndex("dbo.AbonoAhorroes", new[] { "CuentaAhorroId" });
            DropIndex("dbo.CuentaAhorroes", new[] { "Users_Id" });
            DropIndex("dbo.PagoCreditoes", new[] { "TarjetaCreditoId" });
            DropIndex("dbo.CargoCreditoes", new[] { "TarjetaCredito_Id" });
            DropIndex("dbo.CargoCreditoes", new[] { "CuentaMonetariaId" });
            DropIndex("dbo.TarjetaCreditoes", new[] { "Cuenta_Id" });
            DropIndex("dbo.TarjetaCreditoes", new[] { "CuentaMonetariaId" });
            DropIndex("dbo.RetiroDebitoes", new[] { "TarjetaDebitoId" });
            DropIndex("dbo.AbonoDebitoes", new[] { "TarjetaDebitoId" });
            DropIndex("dbo.TarjetaDebitoes", new[] { "Cuenta_Id" });
            DropIndex("dbo.TarjetaDebitoes", new[] { "CuentaMonetariaId" });
            DropIndex("dbo.CuentaMonetarias", new[] { "Users_Id" });
            DropIndex("dbo.Prestamoes", new[] { "Cuenta_Id" });
            DropIndex("dbo.Prestamoes", new[] { "CuentaMonetariaId" });
            DropIndex("dbo.Cuentas", new[] { "Users_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropTable("dbo.RetiroAhorroes");
            DropTable("dbo.AbonoAhorroes");
            DropTable("dbo.CuentaAhorroes");
            DropTable("dbo.PagoCreditoes");
            DropTable("dbo.CargoCreditoes");
            DropTable("dbo.TarjetaCreditoes");
            DropTable("dbo.RetiroDebitoes");
            DropTable("dbo.AbonoDebitoes");
            DropTable("dbo.TarjetaDebitoes");
            DropTable("dbo.CuentaMonetarias");
            DropTable("dbo.Prestamoes");
            DropTable("dbo.Cuentas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
