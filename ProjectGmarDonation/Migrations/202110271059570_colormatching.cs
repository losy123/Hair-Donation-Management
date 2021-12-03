namespace ProjectGmarDonation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colormatching : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairDonations", "isColor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HairDonations", "isColor");
        }
    }
}
