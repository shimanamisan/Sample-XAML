﻿using DataGrid_Sample.Csv;
using DataGrid_Sample.Enitities;
using DataGrid_Sample.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace DataGrid_Sample
{
    /// <summary>
    /// MainWindowのViewModel。ウィンドウのコンポーネントのコマンドとインタラクションを処理します。
    /// </summary>
    public sealed class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// CSVに接続したりSQLServerに接続したりするリポジトリ
        /// </summary>
        private IDataGridRepository _dataGridRepository;

        /// <summary>
        /// DataGridに表示させるリスト
        /// </summary>
        public ObservableCollection<UserEnitity> UserEntityData
        {
            get => _userEntityData;
            set => SetProperty(ref _userEntityData, value);
        }
        private ObservableCollection<UserEnitity> _userEntityData;

        public DelegateCommand ExecuteGetData { get; }

        public DelegateCommand<object> ExecuteRowSelectedCommand { get; }

        /// <summary>
        /// コンストラクタ初期化子
        /// </summary>
        public MainWindowViewModel(): this(new CSVClient())
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel(IDataGridRepository dataGridRepository)
        {
            _dataGridRepository = dataGridRepository;

            ExecuteGetData = new DelegateCommand(GetData);

            ExecuteRowSelectedCommand = new DelegateCommand<object>(RowSelectedCommand);
        }

        private void RowSelectedCommand(object o)
        {
            var entity = o as UserEnitity;

            if (entity != null)
            {
                var displayValue = $"ユーザーID: {entity.Id}\n" +
                                   $"名前: {entity.Name}\n" +
                                   $"年齢: {entity.Age}\n" +
                                   $"誕生日:  {entity.BrithDay}\n" +
                                   $"性別: {entity.Sex}\n" +
                                   $"メールアドレス: {entity.Email}\n" +
                                   $"電話番号: {entity.Tell}";

                MessageBox.Show($"{displayValue}", 
                                 "ユーザー情報",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);
            }
        }

        private void GetData()
        {
            try
            {
                UserEntityData = _dataGridRepository.Get();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);

                MessageBox.Show("データ取得に失敗しました",
                                "エラー",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }

}