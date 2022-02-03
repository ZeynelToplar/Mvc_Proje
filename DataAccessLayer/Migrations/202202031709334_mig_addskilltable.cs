namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addskilltable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillOne = c.String(),
                        SkillTwo = c.String(),
                        SkillThree = c.String(),
                        SkillOneValue = c.Double(nullable: false),
                        SkillTwoValue = c.Double(nullable: false),
                        SkillThreeValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
