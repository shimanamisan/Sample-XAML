﻿using System;
using System.Windows.Input;

namespace ComboBox_Sample
{
    /// <summary>
    /// 任意の型を受け取るDelegateCommandクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        // 実行するアクションを保持する変数
        private readonly Action<T> _execute;
        // コマンドの実行可否を判定する関数を保持する
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action<T> execute) : this(execute, () => true)
        { }

        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            // RequerySuggested： コマンドを実行できるかどうかを変更する可能性のある条件が、
            //                    CommandManagerによって検出された場合に発生する
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute((T)parameter);
        }
    }

    /// <summary>
    /// 任意の型を指定する必要がないDelegateCommandクラス
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute) : this(execute, () => true)
        { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            // RequerySuggested： コマンドを実行できるかどうかを変更する可能性のある条件が、
            //                    CommandManagerによって検出された場合に発生する
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
