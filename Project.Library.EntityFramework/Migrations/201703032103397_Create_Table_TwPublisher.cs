namespace Project.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_TwPublisher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TwBook",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 120),
                        ISBN = c.String(nullable: false, maxLength: 120),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Author_Id = c.Guid(nullable: false),
                        Publisher_Id = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Book_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TwAuthor", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.TwPublisher", t => t.Publisher_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.TwPublisher",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        Address = c.String(nullable: false, maxLength: 120),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Publisher_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TwBook", "Publisher_Id", "dbo.TwPublisher");
            DropForeignKey("dbo.TwBook", "Author_Id", "dbo.TwAuthor");
            DropIndex("dbo.TwBook", new[] { "Publisher_Id" });
            DropIndex("dbo.TwBook", new[] { "Author_Id" });
            DropTable("dbo.TwPublisher",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Publisher_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TwBook",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Book_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
