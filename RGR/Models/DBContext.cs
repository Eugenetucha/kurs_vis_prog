using System;
using System.Data;
using System.Data.SQLite;

namespace RGR.Models
{
    public class DbContext
    {
        static DbContext? _instance;
        public static DbContext GetInstance()
        {
            if (_instance == null) _instance = new DbContext();
            return _instance;
        }
        


        private SQLiteConnection _sqlCon;
        private DataSet _tables;

        public DataSet GetDataSet()
        {
            return _tables.Copy();
        }
        private void getTables()
        {

            SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY 1", _sqlCon);
            DataTable tablesNames = new DataTable();
            tablesNames.Load(command.ExecuteReader());

            foreach (DataRow row in tablesNames.Rows)
            {
                string? name = row.ItemArray[0]?.ToString();
                if (name == "sqlite_sequence") continue;
                SQLiteCommand sqlTab = new SQLiteCommand("SELECT * FROM (" + name + ")", _sqlCon);
                DataTable table = new DataTable();
                table.Load(sqlTab.ExecuteReader());
                _tables.Tables.Add(table);
            }
        }

        public void GetQuery(string query, DataTable table)
        {
            SQLiteCommand command = new SQLiteCommand(query, _sqlCon);
            table.Load(command.ExecuteReader());
        }

        public void Save(DataSet sTables) {
            foreach (DataTable table in _tables.Tables) {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from (" + table.TableName + ")", _sqlCon);
                adapter.UpdateCommand = new SQLiteCommandBuilder(adapter).GetUpdateCommand();
                adapter.InsertCommand = new SQLiteCommandBuilder(adapter).GetInsertCommand();
                adapter.DeleteCommand = new SQLiteCommandBuilder(adapter).GetDeleteCommand();
                adapter.Update(sTables, table.TableName);
                
             }
        }
        private DbContext() {
            _tables = new DataSet();

            _sqlCon = new SQLiteConnection("Data Source=MotoGP.db;Mode=ReadWrite");
            _sqlCon.Open();
            if (_sqlCon.State != ConnectionState.Open)
            {
                throw new Exception("Connection failed!");
            }

            getTables();
        }

        ~DbContext()
        {
            _sqlCon.Close();
        }
    }
}
