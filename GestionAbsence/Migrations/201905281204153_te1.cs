namespace GestionAbsence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class te1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRoles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "ApplicationUsers");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogins");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.IdentityRoles", "RoleNameIndex");
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUsers", "UserNameIndex");
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.IdentityUserRoles");
            DropPrimaryKey("dbo.IdentityUserLogins");
            CreateTable(
                "dbo.ABSENCE",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IDABSENCE = c.Int(nullable: false),
                        IDTYPEABSENCE = c.Int(nullable: false),
                        DATEDEBUTABSENCE = c.DateTime(),
                        DATEFINABSENCE = c.DateTime(),
                        DUREEABSENCE = c.Int(),
                        VALIDATION = c.Int(),
                        FK_IDCollaborateur = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id, t.IDABSENCE })
                .ForeignKey("dbo.AspNetUsers", t => t.FK_IDCollaborateur)
                .ForeignKey("dbo.TYPEABSENCE", t => t.IDTYPEABSENCE)
                .Index(t => t.IDTYPEABSENCE)
                .Index(t => t.FK_IDCollaborateur);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        IDRH = c.Int(nullable: false),
                        IDAGENCE = c.Int(nullable: false),
                        IDROLE = c.Int(nullable: false),
                        NOMCOLLAB = c.String(maxLength: 50, fixedLength: true, unicode: false),
                        PRENOMCOLLAB = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        TEL_PORTPROCOLLAB = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        EMAILCOLLAB = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        PASSWORDCOLLAB = c.String(maxLength: 50, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AGENCE", t => t.IDAGENCE)
                .ForeignKey("dbo.RH", t => t.IDRH)
                .ForeignKey("dbo.ROLE", t => t.IDROLE)
                .Index(t => t.IDRH)
                .Index(t => t.IDAGENCE)
                .Index(t => t.IDROLE);
            
            CreateTable(
                "dbo.AGENCE",
                c => new
                    {
                        IDAGENCE = c.Int(nullable: false),
                        NOMAGENCE = c.String(maxLength: 50, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.IDAGENCE);
            
            CreateTable(
                "dbo.RH",
                c => new
                    {
                        IDRH = c.Int(nullable: false),
                        NOMRH = c.String(maxLength: 30, unicode: false),
                        PRENOMRH = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDRH);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EQUIPE",
                c => new
                    {
                        IDEQUUIPE = c.Int(nullable: false),
                        NOMEQUIPE = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => new { t.IDEQUUIPE, t.NOMEQUIPE });
            
            CreateTable(
                "dbo.ESTCHEF",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IDEQUUIPE = c.Int(nullable: false),
                        NOMEQUIPE = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                        DATECHEF = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.IDEQUUIPE, t.NOMEQUIPE, t.DATECHEF })
                .ForeignKey("dbo.EQUIPE", t => new { t.IDEQUUIPE, t.NOMEQUIPE })
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => new { t.IDEQUUIPE, t.NOMEQUIPE });
            
            CreateTable(
                "dbo.PROJET",
                c => new
                    {
                        IDPROJET = c.Int(nullable: false),
                        IDEQUUIPE = c.Int(nullable: false),
                        NOMEQUIPE = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                        NOMPROJET = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        TYPEPRIORISATION = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.IDPROJET)
                .ForeignKey("dbo.EQUIPE", t => new { t.IDEQUUIPE, t.NOMEQUIPE })
                .Index(t => new { t.IDEQUUIPE, t.NOMEQUIPE });
            
            CreateTable(
                "dbo.ROLE",
                c => new
                    {
                        IDROLE = c.Int(nullable: false),
                        ROLE = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.IDROLE);
            
            CreateTable(
                "dbo.TYPEABSENCE",
                c => new
                    {
                        IDTYPEABSENCE = c.Int(nullable: false),
                        LIBELLETYPEABSENCE = c.String(maxLength: 20, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.IDTYPEABSENCE);
            
            CreateTable(
                "dbo.CONGE",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IDTYPEABSENCE = c.Int(nullable: false),
                        NBJOUR = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id, t.IDTYPEABSENCE })
                .ForeignKey("dbo.TYPEABSENCE", t => t.IDTYPEABSENCE)
                .Index(t => t.IDTYPEABSENCE);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TRAVAILLE_DANS",
                c => new
                    {
                        IDAGENCE = c.Int(nullable: false),
                        IDRH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDAGENCE, t.IDRH })
                .ForeignKey("dbo.AGENCE", t => t.IDAGENCE, cascadeDelete: true)
                .ForeignKey("dbo.RH", t => t.IDRH, cascadeDelete: true)
                .Index(t => t.IDAGENCE)
                .Index(t => t.IDRH);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.COMPOSER",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IDEQUUIPE = c.Int(nullable: false),
                        NOMEQUIPE = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.IDEQUUIPE, t.NOMEQUIPE })
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.EQUIPE", t => new { t.IDEQUUIPE, t.NOMEQUIPE }, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => new { t.IDEQUUIPE, t.NOMEQUIPE });
            
            AddColumn("dbo.IdentityUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRoles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserClaims", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogins", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String());
            AlterColumn("dbo.ApplicationUsers", "Email", c => c.String());
            AlterColumn("dbo.ApplicationUsers", "UserName", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String());
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            CreateIndex("dbo.IdentityUserRoles", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaims", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogins", "ApplicationUser_Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.CONGE", "IDTYPEABSENCE", "dbo.TYPEABSENCE");
            DropForeignKey("dbo.ABSENCE", "IDTYPEABSENCE", "dbo.TYPEABSENCE");
            DropForeignKey("dbo.AspNetUsers", "IDROLE", "dbo.ROLE");
            DropForeignKey("dbo.ESTCHEF", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.COMPOSER", new[] { "IDEQUUIPE", "NOMEQUIPE" }, "dbo.EQUIPE");
            DropForeignKey("dbo.COMPOSER", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PROJET", new[] { "IDEQUUIPE", "NOMEQUIPE" }, "dbo.EQUIPE");
            DropForeignKey("dbo.ESTCHEF", new[] { "IDEQUUIPE", "NOMEQUIPE" }, "dbo.EQUIPE");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TRAVAILLE_DANS", "IDRH", "dbo.RH");
            DropForeignKey("dbo.TRAVAILLE_DANS", "IDAGENCE", "dbo.AGENCE");
            DropForeignKey("dbo.AspNetUsers", "IDRH", "dbo.RH");
            DropForeignKey("dbo.AspNetUsers", "IDAGENCE", "dbo.AGENCE");
            DropForeignKey("dbo.ABSENCE", "FK_IDCollaborateur", "dbo.AspNetUsers");
            DropIndex("dbo.COMPOSER", new[] { "IDEQUUIPE", "NOMEQUIPE" });
            DropIndex("dbo.COMPOSER", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.TRAVAILLE_DANS", new[] { "IDRH" });
            DropIndex("dbo.TRAVAILLE_DANS", new[] { "IDAGENCE" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CONGE", new[] { "IDTYPEABSENCE" });
            DropIndex("dbo.PROJET", new[] { "IDEQUUIPE", "NOMEQUIPE" });
            DropIndex("dbo.ESTCHEF", new[] { "IDEQUUIPE", "NOMEQUIPE" });
            DropIndex("dbo.ESTCHEF", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "IDROLE" });
            DropIndex("dbo.AspNetUsers", new[] { "IDAGENCE" });
            DropIndex("dbo.AspNetUsers", new[] { "IDRH" });
            DropIndex("dbo.ABSENCE", new[] { "FK_IDCollaborateur" });
            DropIndex("dbo.ABSENCE", new[] { "IDTYPEABSENCE" });
            DropPrimaryKey("dbo.IdentityUserLogins");
            DropPrimaryKey("dbo.IdentityUserRoles");
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.IdentityUserLogins", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserClaims", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRoles", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRoles", "IdentityRole_Id");
            DropTable("dbo.COMPOSER");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TRAVAILLE_DANS");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.CONGE");
            DropTable("dbo.TYPEABSENCE");
            DropTable("dbo.ROLE");
            DropTable("dbo.PROJET");
            DropTable("dbo.ESTCHEF");
            DropTable("dbo.EQUIPE");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RH");
            DropTable("dbo.AGENCE");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ABSENCE");
            AddPrimaryKey("dbo.IdentityUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.IdentityUserClaims", "UserId");
            CreateIndex("dbo.ApplicationUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.IdentityUserRoles", "RoleId");
            CreateIndex("dbo.IdentityUserRoles", "UserId");
            CreateIndex("dbo.IdentityRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.ApplicationUsers", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.IdentityRoles", newName: "AspNetRoles");
        }
    }
}
