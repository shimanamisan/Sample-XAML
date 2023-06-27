using DataGrid_Sample.Enitities;
using DataGrid_Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataGrid_Sample.SQL
{
    public sealed class SQLServerClient : IDataGridRepository
    {
    
        public SQLServerClient()
        {
            // サーバーに接続する処理など
        }

        public ObservableCollection<UserEnitity> Get()
        {
            throw new NotImplementedException();
        }
    }
}
