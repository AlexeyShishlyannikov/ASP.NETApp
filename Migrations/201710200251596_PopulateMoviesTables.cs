namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,Genre,ReleasedDate,DateAdded,NumberInStock) VALUES ('Hangover', 'Comedy', 10/6/2009, 5/4/2016,5)");
        }
        
        public override void Down()
        {
        }
    }
}
