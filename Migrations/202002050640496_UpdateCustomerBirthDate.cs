namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='05/21/2000' WHERE Id = 1");
            Sql("UPDATE Customers SET BirthDate='03/15/1999' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
