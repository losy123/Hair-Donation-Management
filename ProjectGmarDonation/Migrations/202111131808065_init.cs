namespace ProjectGmarDonation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairDonations", "Donor_Email", c => c.String());
            AddColumn("dbo.HairDonations", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.HairDonations", "isColor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HairDonations", "isColor");
            DropColumn("dbo.HairDonations", "Approved");
            DropColumn("dbo.HairDonations", "Donor_Email");
        }
    }
}
