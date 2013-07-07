namespace CoreGen
{
    internal static class Constants
    {
        private static string _listDBStr =
            @"select * from sys.databases";

        internal static string ListDBStr
        {
            get { return _listDBStr; }
            set { _listDBStr = value; }
        }
        private static string _listTablesStr =
            @"select * from INFORMATION_SCHEMA.Tables
                where TABLE_TYPE = 'BASE TABLE'";

        internal static string ListTablesStr
        {
            get { return _listTablesStr; }
            set { _listTablesStr = value; }
        }


        private static string _listColumnsStr =
            @"select * from INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME='{0}'";

        internal static string ListColumnsStr
        {
            get { return _listColumnsStr; }
            set { _listColumnsStr = value; }
        }

        private static string _connStrTrusted =
            @"Data Source={0};
            Initial Catalog={1};
            Integrated Security=SSPI;";

        internal static string ConnStrTrusted
        {
            get { return _connStrTrusted; }
            set { _connStrTrusted = value; }
        }

        private static string _connStrAuth =
            @"Server={0};
            Database={1};
            User ID={2};
            Password={3};
            Trusted_Connection=False;";

        internal static string _getPrimaryKey =
            @"select COLUMN_NAME from INFORMATION_SCHEMA.KEY_COLUMN_USAGE a
            inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS b
            on a.CONSTRAINT_NAME = b.CONSTRAINT_NAME
            where a.TABLE_CATALOG = '{0}' and a.table_name = '{1}' and constraint_type = 'Primary key'";

        internal static string ConnStrAuth
        {
            get { return _connStrAuth; }
            set { _connStrAuth = value; }
        }
    }
}