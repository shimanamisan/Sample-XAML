using System.Text;

namespace DataGrid.Sample.Migrator
{
    public static class CSVClient
    {
        /// <summary>
        /// 現在処理中の行が1行目か判定する
        /// </summary>
        private static bool _isFirstLine = true;

        /// <summary>
        /// アプリケーションが実行されているディレクトリを取得し、指定した文字列を結合させる
        /// </summary>
        private static string _currentDomain = AppDomain.CurrentDomain.BaseDirectory;

        public static List<List<string>> GetInsertData()
        {
            var entities = new List<List<string>>();

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var reader = new StreamReader(_currentDomain + "dummyData.csv", Encoding.GetEncoding("Shift_JIS")))
                {
                    // 1.whileで1行ずつ読み込む
                    // 2.最初の行はスキップする
                    // 3.split(",") でカンマを基準に各要素を配列に変換する
                    // 4.UserEntityに必要な要素だけインデックスを指定して取り出す

                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLine();

                        if (_isFirstLine)
                        {
                            _isFirstLine = false;

                            continue;
                        }

                        var strArray = line.Split(",");


                        entities.Add(new List<string>
                        {
                            strArray[0],
                            strArray[3],
                            strArray[4],
                            strArray[5],
                            strArray[7],
                            strArray[8]
                        });
                    }

                    return entities;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new List<List<string>>();
            }

        }
    }
}
