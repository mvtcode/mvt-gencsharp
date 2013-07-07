using System.Data.SqlClient;

namespace CoreGen
{
    internal static class Commands
    {
        private static SqlCommand _listDBCmd;

        internal static SqlCommand ListDBCmd
        {
            get
            {
                if (_listDBCmd == null)
                {
                    _listDBCmd = new SqlCommand();
                }
                return _listDBCmd;
            }
        }

        private static SqlCommand _listTablesCmd;

        internal static SqlCommand ListTablesCmd
        {
            get
            {
                if (_listTablesCmd == null)
                {
                    _listTablesCmd = new SqlCommand();
                }
                return _listTablesCmd;
            }
        }

        private static SqlCommand _listColumnsCmd;

        internal static SqlCommand ListColumnsCmd
        {
            get
            {
                if (_listColumnsCmd == null)
                {
                    _listColumnsCmd = new SqlCommand();
                }
                
                return _listColumnsCmd;
            }
        }

        private static SqlCommand _commandPrimaryKey;
        internal static SqlCommand CommandPrimaryKey
        {
            get
            {
                if (_commandPrimaryKey == null)
                {
                    _commandPrimaryKey = new SqlCommand();
                }
                return _commandPrimaryKey;
            }
        }
    }
}