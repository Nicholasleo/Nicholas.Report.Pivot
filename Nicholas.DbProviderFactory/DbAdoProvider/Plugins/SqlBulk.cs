/*==============================================
*CLR版本：4.0.30319.36388
*名称：SqlBulk
*命名空间名称：Nicholas.DbProviderFactory.DbAdoProvider.Plugins
*文件名称：SqlBulk
*创建时间：2017/9/5 10:59:05
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Data.SqlClient;
using System.Data;
using Nicholas.Entities;

namespace Nicholas.DbProviderFactory.DbAdoProvider.Plugins
{
    internal class SqlBulk : IDisposable
    {
        SqlBulkCopy bulkCopy = null;
        public BulkCopiedArgs BulkCopiedHandler { get; set; }

        public BulkCopyOptions Option { get; private set; }

        public string ConnectionString { get; private set; }

        public SqlBulk(string ConnectionString, int timeout = 1800, BulkCopyOptions option = BulkCopyOptions.KeepIdentity)
        {
            this.Option = option;
            this.ConnectionString = ConnectionString;

            bulkCopy = CreatedBulkCopy(option);
            bulkCopy.BulkCopyTimeout = timeout;
        }

        public SqlBulk(IDbConnection dbConnection, IDbTransaction dbTrans = null,
            int timeout = 1800, BulkCopyOptions option = BulkCopyOptions.KeepIdentity)
        {
            this.Option = option;
            this.ConnectionString = ConnectionString;

            SqlConnection connection = (SqlConnection)dbConnection;
            if (dbTrans == null) bulkCopy = new SqlBulkCopy(connection);
            else bulkCopy = new SqlBulkCopy(connection, (SqlBulkCopyOptions)option, (SqlTransaction)dbTrans);

            bulkCopy.BulkCopyTimeout = timeout;
        }

        private SqlBulkCopy CreatedBulkCopy(BulkCopyOptions option)
        {
            if (option == BulkCopyOptions.None)
            {
                return new SqlBulkCopy(ConnectionString);
            }
            else
            {
                return new SqlBulkCopy(ConnectionString, (SqlBulkCopyOptions)option);
            }
        }

        public void Dispose()
        {
            if (bulkCopy != null)
            {
                bulkCopy.Close();
                bulkCopy = null;
            }
        }

        public void Close()
        {
            if (bulkCopy != null)
                bulkCopy.Close();
        }

        private void InitBulkCopy(DataTable dt, int batchSize = 102400)
        {
            if (bulkCopy.ColumnMappings.Count > 0) bulkCopy.ColumnMappings.Clear();

            bulkCopy.ColumnMappings.Capacity = dt.Columns.Count;
            bulkCopy.DestinationTableName = dt.TableName;
            bulkCopy.BatchSize = batchSize;

            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName,
                    dt.Columns[i].ColumnName);
            }
            if (BulkCopiedHandler != null)
            {
                bulkCopy.NotifyAfter = batchSize;
                bulkCopy.SqlRowsCopied += bulkCopy_SqlRowsCopied;
            }
        }

        private void InitBulkCopy(string tableName, string[] columnNames, int batchSize = 102400)
        {
            if (bulkCopy.ColumnMappings.Count > 0) bulkCopy.ColumnMappings.Clear();

            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BatchSize = batchSize;

            for (int i = 0; i < columnNames.Length; ++i)
            {
                bulkCopy.ColumnMappings.Add(columnNames[i],
                    columnNames[i]);
            }
            if (BulkCopiedHandler != null)
            {
                bulkCopy.NotifyAfter = batchSize;
                bulkCopy.SqlRowsCopied += bulkCopy_SqlRowsCopied;
            }
        }

        private void InitBulkCopy(string tableName, int batchSize = 102400)
        {
            if (bulkCopy.ColumnMappings.Count > 0) bulkCopy.ColumnMappings.Clear();

            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BatchSize = batchSize;

            if (BulkCopiedHandler != null)
            {
                bulkCopy.NotifyAfter = batchSize;
                bulkCopy.SqlRowsCopied += bulkCopy_SqlRowsCopied;
            }
        }

        void bulkCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            if (BulkCopiedHandler != null)
            {
                BulkCopiedHandler(e.RowsCopied);
            }
        }

        public void WriteToServer(DataTable dt, int batchSize = 102400)
        {
            InitBulkCopy(dt, batchSize);
            bulkCopy.WriteToServer(dt);
        }

        public void WriteToServer(string tableName, IDataReader iDataReader, int batchSize = 102400)
        {
            string[] columnNames = new string[iDataReader.FieldCount];
            for (int i = 0; i < columnNames.Length; ++i)
            {
                columnNames[i] = iDataReader.GetName(i);
            }
            InitBulkCopy(tableName, columnNames, batchSize);
            bulkCopy.WriteToServer(iDataReader);
        }

        public void WriteToServer(string tableName, DataRow[] rows)
        {
            InitBulkCopy(tableName);
            bulkCopy.WriteToServer(rows);
        }

        public void WriteToServer(DataTable dt, DataRowState rowState, int batchSize = 102400)
        {
            InitBulkCopy(dt, batchSize);
            bulkCopy.WriteToServer(dt, rowState);
        }

        public void WriteToServer(DataRow[] rows, int batchSize = 102400)
        {
            InitBulkCopy(rows[0].Table, batchSize);
            bulkCopy.WriteToServer(rows);
        }
    }
}
