namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialByOsama : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerValue = c.String(),
                        Question_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionClaims", t => t.Question_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.QuestionClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionType = c.String(),
                        Question = c.String(),
                        Designation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.Designation_Id)
                .Index(t => t.Designation_Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        CNIC = c.String(),
                        ParentCNIC = c.String(),
                        EmergencyPhoneNumber = c.String(),
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
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Session_Id);
            
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
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearFrom = c.String(),
                        YearTo = c.String(),
                        Name = c.String(),
                        Class_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Cluster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clusters", t => t.Cluster_Id)
                .Index(t => t.Cluster_Id);
            
            CreateTable(
                "dbo.Clusters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserDesignations",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Designation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Designation_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.Designation_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Designation_Id);
            
            CreateTable(
                "dbo.LevelQuestionClaims",
                c => new
                    {
                        Level_Id = c.Int(nullable: false),
                        QuestionClaim_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Level_Id, t.QuestionClaim_Id })
                .ForeignKey("dbo.Levels", t => t.Level_Id, cascadeDelete: true)
                .ForeignKey("dbo.QuestionClaims", t => t.QuestionClaim_Id, cascadeDelete: true)
                .Index(t => t.Level_Id)
                .Index(t => t.QuestionClaim_Id);
            
            CreateTable(
                "dbo.UniversityLevels",
                c => new
                    {
                        University_Id = c.Int(nullable: false),
                        Level_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.University_Id, t.Level_Id })
                .ForeignKey("dbo.Universities", t => t.University_Id, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.Level_Id, cascadeDelete: true)
                .Index(t => t.University_Id)
                .Index(t => t.Level_Id);
            
            CreateTable(
                "dbo.LevelUsers",
                c => new
                    {
                        Level_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Level_Id, t.User_Id })
                .ForeignKey("dbo.Levels", t => t.Level_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Level_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Schools", "Cluster_Id", "dbo.Clusters");
            DropForeignKey("dbo.Clusters", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Classes", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LevelUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LevelUsers", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.UniversityLevels", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.UniversityLevels", "University_Id", "dbo.Universities");
            DropForeignKey("dbo.LevelQuestionClaims", "QuestionClaim_Id", "dbo.QuestionClaims");
            DropForeignKey("dbo.LevelQuestionClaims", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.UserDesignations", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.UserDesignations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionClaims", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.QuestionClaims");
            DropIndex("dbo.LevelUsers", new[] { "User_Id" });
            DropIndex("dbo.LevelUsers", new[] { "Level_Id" });
            DropIndex("dbo.UniversityLevels", new[] { "Level_Id" });
            DropIndex("dbo.UniversityLevels", new[] { "University_Id" });
            DropIndex("dbo.LevelQuestionClaims", new[] { "QuestionClaim_Id" });
            DropIndex("dbo.LevelQuestionClaims", new[] { "Level_Id" });
            DropIndex("dbo.UserDesignations", new[] { "Designation_Id" });
            DropIndex("dbo.UserDesignations", new[] { "User_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Clusters", new[] { "City_Id" });
            DropIndex("dbo.Schools", new[] { "Cluster_Id" });
            DropIndex("dbo.Classes", new[] { "School_Id" });
            DropIndex("dbo.Sessions", new[] { "Class_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Session_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.QuestionClaims", new[] { "Designation_Id" });
            DropIndex("dbo.Answers", new[] { "User_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.LevelUsers");
            DropTable("dbo.UniversityLevels");
            DropTable("dbo.LevelQuestionClaims");
            DropTable("dbo.UserDesignations");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Cities");
            DropTable("dbo.Clusters");
            DropTable("dbo.Schools");
            DropTable("dbo.Classes");
            DropTable("dbo.Sessions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Universities");
            DropTable("dbo.Levels");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Designations");
            DropTable("dbo.QuestionClaims");
            DropTable("dbo.Answers");
        }
    }
}
