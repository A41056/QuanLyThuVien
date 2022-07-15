using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        private const string SqlConnection = @"Data Source=DESKTOP-P2A4PIM\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True;Connection Timeout=30";


        public async Task<DataTable> executeQueryAsync(string pzQuery, object[] pParameter = null)
        {
            DataTable _data = null;

            using (SqlConnection _connection = new SqlConnection(SqlConnection))
            using (SqlCommand _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
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
                        _cmd.Connection.Close();
                }
            }
            return _data;
        }

        public async Task<bool> executeQueryAsync(string pzQuery, CancellationToken pCancellationToken, object[] pParameter = null)
        {
            using (SqlConnection _connection = new SqlConnection(SqlConnection))
            using (SqlCommand _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;

                await _cmd.Connection.OpenAsync(pCancellationToken);

                try
                {
                    addParameter(pzQuery, pParameter, _cmd);

                    using (var _dataReader = await _cmd.ExecuteReaderAsync(pCancellationToken))
                        return _dataReader.HasRows;
                }
                finally
                {
                    if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                        _cmd.Connection.Close();
                }
            }
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

        public async Task<int> executeNonQueryAsync(string pzQuery, CancellationToken pCancellationToken, object[] pParameter = null)
        {
            int _nData = 0;
            using (var _connection = new SqlConnection(SqlConnection))
            using (var _cmd = _connection.CreateCommand())
            {
                _cmd.CommandText = pzQuery;
                await _connection.OpenAsync(pCancellationToken);
                try
                {
                    addParameter(pzQuery, pParameter, _cmd);
                    _nData = await _cmd.ExecuteNonQueryAsync(pCancellationToken);
                }
                finally
                {
                    if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                        _cmd.Connection.Close();
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
                    _data = await _cmd.ExecuteScalarAsync();
                }
                finally
                {
                    if (_cmd.Connection != null && _cmd.Connection.State != ConnectionState.Closed)
                        _cmd.Connection.Close();
                }
            }
            return _data;
        }

        private void addParameter(string pzQuery, object[] pParameter, SqlCommand pCommand)
        {
            if (pParameter != null)
            {
                string[] _zListParameter = pzQuery.Split( new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int _i = 0; _i < _zListParameter.Length; _i++)
                {
                    if (_zListParameter[_i].Contains("@"))
                        pCommand.Parameters.AddWithValue(_zListParameter[_i], pParameter[_i - 1]);
                }
            }
        }
    }
}
