using FluentMigrator;

namespace DataGrid.Sample.Migrator
{
    public sealed class UsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("first_name").AsString()
                .WithColumn("last_name").AsString();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }


    }
}
