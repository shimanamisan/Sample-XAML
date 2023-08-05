namespace DataGrid.Sample.Migrator
{
    public sealed class CustomMigrationAttribute : FluentMigrator.MigrationAttribute
    {
        /// <summary>
        /// マイグレーションの作者を取得する
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="branchNumber">ブランチ番号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時間</param>
        /// <param name="minute">分</param>
        /// <param name="author">マイグレーションの作者</param>
        public CustomMigrationAttribute(int branchNumber, int year, int month, int day, int hour, int minute, string author)
            : base(CalculateValue(branchNumber, year, month, day, hour, minute))
        {
            Author = author;
        }

        /// <summary>
        /// ブランチ番号、年、月、日、時間、および分から値を計算する
        /// </summary>
        /// <param name="branchNumber">ブランチ番号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="hour">時間</param>
        /// <param name="minute">分</param>
        /// <returns>計算結果の値</returns>
        private static long CalculateValue(int branchNumber, int year, int month, int day, int hour, int minute)
        {
            // 各値に重み付けをする計算を実行
            // branchNumber: 1兆
            // year: 1億
            // month: 100万
            // day: 1万
            // hour: 100
            // minute: デフォルト値
            return branchNumber * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
        }
    }
}
