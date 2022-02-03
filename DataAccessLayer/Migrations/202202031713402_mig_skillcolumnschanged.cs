namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skillcolumnschanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillName", c => c.String());
            AddColumn("dbo.Skills", "SkillValue", c => c.Double(nullable: false));
            DropColumn("dbo.Skills", "SkillOne");
            DropColumn("dbo.Skills", "SkillTwo");
            DropColumn("dbo.Skills", "SkillThree");
            DropColumn("dbo.Skills", "SkillOneValue");
            DropColumn("dbo.Skills", "SkillTwoValue");
            DropColumn("dbo.Skills", "SkillThreeValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "SkillThreeValue", c => c.Double(nullable: false));
            AddColumn("dbo.Skills", "SkillTwoValue", c => c.Double(nullable: false));
            AddColumn("dbo.Skills", "SkillOneValue", c => c.Double(nullable: false));
            AddColumn("dbo.Skills", "SkillThree", c => c.String());
            AddColumn("dbo.Skills", "SkillTwo", c => c.String());
            AddColumn("dbo.Skills", "SkillOne", c => c.String());
            DropColumn("dbo.Skills", "SkillValue");
            DropColumn("dbo.Skills", "SkillName");
        }
    }
}
