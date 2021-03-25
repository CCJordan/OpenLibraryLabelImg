namespace OpenLibraryLabelImg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnotationClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50, storeType: "nvarchar"),
                        ColorArgb = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.AnnotationCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        BasePath = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnnotationImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        Excluded = c.Boolean(nullable: false),
                        AnnotationCollection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnnotationCollections", t => t.AnnotationCollection_Id)
                .Index(t => t.AnnotationCollection_Id);
            
            CreateTable(
                "dbo.AnnotationBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        ClassId = c.Int(nullable: false),
                        AnnotaionImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnnotationImages", t => t.AnnotaionImageId, cascadeDelete: true)
                .ForeignKey("dbo.AnnotationClasses", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.AnnotaionImageId);
            
            CreateTable(
                "dbo.YoloNets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        ObjFilePath = c.String(maxLength: 255, storeType: "nvarchar"),
                        YoloFilePath = c.String(maxLength: 255, storeType: "nvarchar"),
                        WeightFolderPath = c.String(maxLength: 255, storeType: "nvarchar"),
                        DataFolderPath = c.String(maxLength: 255, storeType: "nvarchar"),
                        TargetResolution = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassMaps",
                c => new
                    {
                        AnnotationClassId = c.Int(nullable: false),
                        MappedId = c.Int(nullable: false),
                        YoloNet_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.AnnotationClassId, t.MappedId })
                .ForeignKey("dbo.AnnotationClasses", t => t.AnnotationClassId, cascadeDelete: true)
                .ForeignKey("dbo.YoloNets", t => t.YoloNet_Id)
                .Index(t => t.AnnotationClassId)
                .Index(t => t.YoloNet_Id);
            
            CreateTable(
                "dbo.AnnotationCollectionAnnotationClasses",
                c => new
                    {
                        AnnotationCollection_Id = c.Int(nullable: false),
                        AnnotationClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnnotationCollection_Id, t.AnnotationClass_Id })
                .ForeignKey("dbo.AnnotationCollections", t => t.AnnotationCollection_Id, cascadeDelete: true)
                .ForeignKey("dbo.AnnotationClasses", t => t.AnnotationClass_Id, cascadeDelete: true)
                .Index(t => t.AnnotationCollection_Id)
                .Index(t => t.AnnotationClass_Id);
            
            CreateTable(
                "dbo.YoloNetAnnotationCollections",
                c => new
                    {
                        YoloNet_Id = c.Int(nullable: false),
                        AnnotationCollection_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.YoloNet_Id, t.AnnotationCollection_Id })
                .ForeignKey("dbo.YoloNets", t => t.YoloNet_Id, cascadeDelete: true)
                .ForeignKey("dbo.AnnotationCollections", t => t.AnnotationCollection_Id, cascadeDelete: true)
                .Index(t => t.YoloNet_Id)
                .Index(t => t.AnnotationCollection_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YoloNetAnnotationCollections", "AnnotationCollection_Id", "dbo.AnnotationCollections");
            DropForeignKey("dbo.YoloNetAnnotationCollections", "YoloNet_Id", "dbo.YoloNets");
            DropForeignKey("dbo.ClassMaps", "YoloNet_Id", "dbo.YoloNets");
            DropForeignKey("dbo.ClassMaps", "AnnotationClassId", "dbo.AnnotationClasses");
            DropForeignKey("dbo.AnnotationImages", "AnnotationCollection_Id", "dbo.AnnotationCollections");
            DropForeignKey("dbo.AnnotationBoxes", "ClassId", "dbo.AnnotationClasses");
            DropForeignKey("dbo.AnnotationBoxes", "AnnotaionImageId", "dbo.AnnotationImages");
            DropForeignKey("dbo.AnnotationCollectionAnnotationClasses", "AnnotationClass_Id", "dbo.AnnotationClasses");
            DropForeignKey("dbo.AnnotationCollectionAnnotationClasses", "AnnotationCollection_Id", "dbo.AnnotationCollections");
            DropIndex("dbo.YoloNetAnnotationCollections", new[] { "AnnotationCollection_Id" });
            DropIndex("dbo.YoloNetAnnotationCollections", new[] { "YoloNet_Id" });
            DropIndex("dbo.AnnotationCollectionAnnotationClasses", new[] { "AnnotationClass_Id" });
            DropIndex("dbo.AnnotationCollectionAnnotationClasses", new[] { "AnnotationCollection_Id" });
            DropIndex("dbo.ClassMaps", new[] { "YoloNet_Id" });
            DropIndex("dbo.ClassMaps", new[] { "AnnotationClassId" });
            DropIndex("dbo.AnnotationBoxes", new[] { "AnnotaionImageId" });
            DropIndex("dbo.AnnotationBoxes", new[] { "ClassId" });
            DropIndex("dbo.AnnotationImages", new[] { "AnnotationCollection_Id" });
            DropIndex("dbo.AnnotationClasses", new[] { "Title" });
            DropTable("dbo.YoloNetAnnotationCollections");
            DropTable("dbo.AnnotationCollectionAnnotationClasses");
            DropTable("dbo.ClassMaps");
            DropTable("dbo.YoloNets");
            DropTable("dbo.AnnotationBoxes");
            DropTable("dbo.AnnotationImages");
            DropTable("dbo.AnnotationCollections");
            DropTable("dbo.AnnotationClasses");
        }
    }
}
