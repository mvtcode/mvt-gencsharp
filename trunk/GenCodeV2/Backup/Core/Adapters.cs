using System;
using System.Data.SqlClient;

namespace CoreGen
{
    public static class Adapters
    {
        private static SqlDataAdapter _serverDA;

        public static SqlDataAdapter ServerDA
        {
            get
            {
                if (_serverDA == null)
                {
                    Commands.ListDBCmd.CommandText = Constants.ListDBStr;
                    Commands.ListDBCmd.Connection = Connections.GetConnection();
                    _serverDA = new SqlDataAdapter(Commands.ListDBCmd);
                }
                return _serverDA;
            }
        }

        private static SqlDataAdapter _lsTablesDA;

        public static SqlDataAdapter LsTablesDA
        {
            get
            {
                Args.InitialCatalog = Args.WheredDb;
                Commands.ListTablesCmd.CommandText = Constants.ListTablesStr;
                Commands.ListTablesCmd.Connection = Connections.GetConnection();
                _lsTablesDA = new SqlDataAdapter(Commands.ListTablesCmd);
                return _lsTablesDA;
            }
        }

        private static SqlDataAdapter _lsColumnsDA;

        public static SqlDataAdapter LsColumnsDA
        {
            get
            {
                Commands.ListColumnsCmd.CommandText = String.Format(Constants.ListColumnsStr, Args.WheredTable);
                Commands.ListColumnsCmd.Connection = Connections.GetConnection();
                _lsColumnsDA = new SqlDataAdapter(Commands.ListColumnsCmd);
                return _lsColumnsDA;
            }
        }

        public static string GetPrimarykey
        {
            get
            {
                Commands.CommandPrimaryKey.CommandText = String.Format(Constants._getPrimaryKey, Args.WheredDb, Args.WheredTable);
                var con = Connections.GetConnection();
                Commands.CommandPrimaryKey.Connection = con;
                con.Open();
                var r = Commands.CommandPrimaryKey.ExecuteReader();
                if (r != null)
                {
                    if (r.Read())
                    {
                        return r["COLUMN_NAME"].ToString();
                    }
                    r.Close();
                    r.Dispose();
                }
                con.Close();
                con.Dispose();
                return "";
            }
        }
    }
}