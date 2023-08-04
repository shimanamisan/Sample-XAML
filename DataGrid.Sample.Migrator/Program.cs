using DataGrid.Sample.Migrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

/// <summary>
/// サービスのプロバイダーを作成
/// </summary>
/// <param name="sourcePath">データソースのパス</param>
/// <returns>サービスプロバイダーのインスタンス</returns>
static IServiceProvider CreateServices(string sourcePath)
{
    return new ServiceCollection()
        // 共通のFluentMigratorサービスを追加する
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // FluentMigrator に SQLite サポートを追加する。
            .AddSQLite()
            // 接続文字列を設定する
            .WithGlobalConnectionString($"Data Source={sourcePath}")
            // マイグレーションを含むアセンブリを定義する
            .ScanIn(typeof(UsersTable).Assembly).For.Migrations())
        // FluentMigrator の方法でコンソールへのロギングを有効にする。
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // サービスプロバイダーの構築
        .BuildServiceProvider(false);
}

/// <summary>
/// SQLiteのリソースファイルをコピーする
/// </summary>
static void CopySQLiteResource(string sourcePath)
{
    // 出力先のフォルダ
    string destFolderPath = ConfigurationManager.AppSettings.Get("OutputPath");

    // ファイル名を含めた出力先のパス
    string destFilePath = Path.Combine(destFolderPath, ConfigurationManager.AppSettings.Get("DBResource"));

    try
    {

        // コピー先のフォルダが存在しなければ作成する
        if (!File.Exists(destFolderPath))
        {
            Directory.CreateDirectory(destFolderPath);
        }

        // コピー元のファイルが存在するか確認
        if (File.Exists(sourcePath))
        {
            // ファイルをコピー
            // 第三引数の true は、目的のファイルが存在する場合に上書きすることを意味する
            File.Copy(sourcePath, Path.Combine(destFilePath), true);

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"コピー時にエラーが発生しました。\n {ex.Message}");
    }

}

// 実行ファイル（.exe）が実行されている直下のフォルダに存在するデータベースファイルのフルパスを取得
var dataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              ConfigurationManager.AppSettings.Get("DBResource"));

var serviceProvider = CreateServices(dataSource);

using (var scope = serviceProvider.CreateScope())
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    Console.WriteLine("Please specify a command: 'up' or 'down'.");

    // コンソール画面でユーザーからの入力を待つ
    var input = Console.ReadLine();

    switch (input)
    {
        case "up":
            // マイグレーションを実行する
            runner.MigrateUp();
            break;

        case "down":
            // ロールバックを実行（バージョンを指定）
            runner.MigrateDown(0);
            break;

        default:
            Console.WriteLine("Invalid command. Please use 'up' or 'down'.");
            break;
    }

}

// マイグレーションが実行されたファイルを指定した場所へコピーする
CopySQLiteResource(dataSource);