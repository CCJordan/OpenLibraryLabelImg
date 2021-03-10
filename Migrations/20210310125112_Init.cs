using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenLibraryLabelImg.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassLabel = table.Column<string>(type: "TEXT", nullable: true),
                    ColorArgb = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BasePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ObjFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    YoloFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    WeightFolderPath = table.Column<string>(type: "TEXT", nullable: true),
                    DataFolderPath = table.Column<string>(type: "TEXT", nullable: true),
                    TargetXResolution = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetYResolution = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationClassAnnotationCollection",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationClassAnnotationCollection", x => new { x.ClassesId, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_AnnotationClassAnnotationCollection_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationClassAnnotationCollection_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Excluded = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnnotationCollectionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Collections_AnnotationCollectionId",
                        column: x => x.AnnotationCollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationCollectionYoloNet",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    NetsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationCollectionYoloNet", x => new { x.CollectionsId, x.NetsId });
                    table.ForeignKey(
                        name: "FK_AnnotationCollectionYoloNet_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationCollectionYoloNet_Nets_NetsId",
                        column: x => x.NetsId,
                        principalTable: "Nets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassMap",
                columns: table => new
                {
                    AnnotationClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    MappedId = table.Column<int>(type: "INTEGER", nullable: false),
                    YoloNetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMap", x => new { x.AnnotationClassId, x.MappedId });
                    table.ForeignKey(
                        name: "FK_ClassMap_Classes_AnnotationClassId",
                        column: x => x.AnnotationClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassMap_Nets_YoloNetId",
                        column: x => x.YoloNetId,
                        principalTable: "Nets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationBox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnnotaionImageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnotationBox_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationBox_Images_AnnotaionImageId",
                        column: x => x.AnnotaionImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationBox_AnnotaionImageId",
                table: "AnnotationBox",
                column: "AnnotaionImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationBox_ClassId",
                table: "AnnotationBox",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationClassAnnotationCollection_CollectionsId",
                table: "AnnotationClassAnnotationCollection",
                column: "CollectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationCollectionYoloNet_NetsId",
                table: "AnnotationCollectionYoloNet",
                column: "NetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassLabel",
                table: "Classes",
                column: "ClassLabel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassMap_YoloNetId",
                table: "ClassMap",
                column: "YoloNetId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AnnotationCollectionId",
                table: "Images",
                column: "AnnotationCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnotationBox");

            migrationBuilder.DropTable(
                name: "AnnotationClassAnnotationCollection");

            migrationBuilder.DropTable(
                name: "AnnotationCollectionYoloNet");

            migrationBuilder.DropTable(
                name: "ClassMap");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Nets");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
