using FluentMigrator;

namespace DataGrid.Sample.Migrator
{
    [CustomMigration(author: "H.Nishihara", branchNumber: 12, year: 2023, month: 7, day: 19, hour: 17, minute: 29)]
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
                .WithColumn("name").AsString()
                .WithColumn("age").AsInt32()
                // AsDateTime = System.DateTime
                .WithColumn("birthday").AsDateTime()
                .WithColumn("gender").AsInt16()
                .WithColumn("email").AsString()
                .WithColumn("phone_number").AsString()
                .WithColumn("created_at").AsDateTime()
                .WithColumn("updated_at").AsDateTime();

            // データをインサートする
            var entities = CSVClient.GetInsertData();

            if(entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    Insert.IntoTable("users").Row(new
                    {
                        name = entity[0],
                        age = entity[1],
                        birthday = entity[2],
                        gender = entity[3] == "女" ? 2 : 1,
                        email = entity[4],
                        phone_number = entity[5],
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    });
                }
            }
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