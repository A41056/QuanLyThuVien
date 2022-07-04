using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public sealed class DataProvider
    {
        private static DataProvider _instance = null;

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DataProvider();
                return _instance;
            }
        }

        public DataProvider() { }

        private const string SqlConnection = @"Data Source=DESKTOP-P2A4PIM\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True";

        public async Task<DataTable> executeQueryAsync(string pzQuery, object[] pParameter = null)
        {
            DataTable _data = null;
           
            using (SqlConnection _connection = new SqlConnection(SqlConnection))
            using (SqlCommand _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
                try
                {
                    await _cmd.Connection.OpenAsync();

                    try
                    {
                        addParameter(pzQuery, pParameter, _cmd);
                        SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);

                        try
                        {
                            _data = new DataTable();
                            await Task.Run(() => _adapter.Fill(_data)); 
                        }
                        finally
                        {
                            _adapter.Dispose();
                        }
                    }
                    finally
                    {
                        if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                            _connection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(QuanLyThuVien.Resource.OpenConnectionError);
                }
            }
            return _data;
        }
        public async Task<DataTable> executeQueryAsync(string pzQuery,CancellationToken pCancellationToken, object[] pParameter = null)
        {
            DataTable _data = null;

            using (SqlConnection _connection = new SqlConnection(SqlConnection))
            using (SqlCommand _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
                try
                {
                    await _cmd.Connection.OpenAsync(pCancellationToken);

                    if (pCancellationToken.IsCancellationRequested)
                        MessageBox.Show("CANCELLED");

                    try
                    {
                        addParameter(pzQuery, pParameter, _cmd);
                        SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);

                        try
                        {
                            _data = new DataTable();
                            await Task.Run(() => _adapter.Fill(_data));
                        }
                        finally
                        {
                            _adapter.Dispose();
                        }
                    }
                    finally
                    {
                        if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                            _connection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(QuanLyThuVien.Resource.OpenConnectionError);
                }
            }
            return _data;
        }

        public async Task<int> executeNonQueryAsync(string pzQuery, object[] pParameter = null)
        {
            int _nData = 0;
            using (var _connection = new SqlConnection(SqlConnection))
            using (var _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
                await _connection.OpenAsync();
                try
                {
                    addParameter(pzQuery, pParameter, _cmd);
                    _nData = await _cmd.ExecuteNonQueryAsync(); 
                }
                finally
                {
                    if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                        _connection.Close();
                }
            }
            return _nData;
        }

        public async Task<object> executeScalar(string pzQuery, object[] pParameter = null)
        {
            object _data = new object();
            using (SqlConnection _connection = new SqlConnection(SqlConnection))
            using (var _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
                await _connection.OpenAsync();

                try
                {
                    addParameter(pzQuery, pParameter, _cmd);
                    _data = await Task.Run(() => _cmd.ExecuteScalarAsync());
                }
                finally
                {
                    if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                        _connection.Close();
                }
            }
            return _data;
        }

        private void addParameter(string pzQuery, object[] pParameter, SqlCommand pCommand)
        {
            if (pParameter != null)
            {
                string[] _zListParameter = pzQuery.Split(' ');
                int i = 0;
                foreach (string _zItem in _zListParameter)
                {
                    if (_zItem.Contains("@"))
                    {
                        pCommand.Parameters.AddWithValue(_zItem, pParameter[i]);
                        ++i;
                    }
                }
            }
        }
    }
}
