namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SkillColumnTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "SkillValue", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "SkillValue", c => c.Double(nullable: false));
        }
    }
}
