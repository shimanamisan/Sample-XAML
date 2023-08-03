using FluentMigrator;

namespace DataGrid.Sample.Migrator
{
    [Migration(1)]
    public sealed class UsersTable : Migration
    {
        /// <summary>
        /// マイグレーション実行時に作成するテーブルを定義
        /// </summary>
        public override void Up()
        {
            Create.Table("users")
                // AsInt32 = int
                // AsInt64 = long
                // AsInt16 = short
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                // AsString = string
                .WithColumn("first_name").AsString()
                .WithColumn("last_name").AsString()
                .WithColumn("age").AsInt32()
                // AsDateTime = System.DateTime
                .WithColumn("birthday").AsDateTime()
                .WithColumn("gender").AsInt16()
                .WithColumn("email").AsString()
                .WithColumn("phone_number").AsString()
                .WithColumn("created_at").AsDateTime()
                .WithColumn("updated_at").AsDateTime();

            //Insert.IntoTable("users").Row(new
            //{
            //    first_name = "John",
            //    last_name = "Doe",
            //    age = 30,
            //    birthday = new DateTime(1993, 2, 15),
            //    gender = 1, // 例: 1 = 男性, 2 = 女性
            //    email = "john.doe@example.com",
            //    phone_number = "123-456-7890",
            //    created_at = DateTime.Now,
            //    updated_at = DateTime.Now
            //});
        }

        /// <summary>
        /// ロールバック時に削除するテーブルを定義
        /// </summary>
        public override void Down()
        {
            Delete.Table("users");
        }


    }
}


/*
 CREATE TABLE "products" (
    "id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
    "name" TEXT NOT NULL,
    "price" INTEGER NOT NULL,
    "created_at" DATETIME NOT NULL,
    "updated_at" DATETIME NOT NULL
)
 */