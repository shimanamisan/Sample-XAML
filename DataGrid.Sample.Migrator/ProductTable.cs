using FluentMigrator;

namespace DataGrid.Sample.Migrator
{
    [CustomMigration(author: "H.Nishihara", branchNumber: 13, year: 2023, month: 7, day: 19, hour: 17, minute: 29)]
    public sealed class ProductTable : Migration
    {

        public override void Up()
        {
            Create.Table("products")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString()
                .WithColumn("price").AsInt32()
                .WithColumn("created_at").AsDateTime()
                .WithColumn("updated_at").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("products");
        }
    }
}
