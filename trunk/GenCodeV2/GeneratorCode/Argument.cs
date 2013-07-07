namespace GenCsharp
{
    public class Argument
    {
        public static string FileEntity = "Entity.txt";
        public static string FileData = "Data.txt";

        //public static string FileImpl = "Impl.txt";
        //public static string FileService = "Service.txt";

        public static string FileSproc = "StoreProcedure.txt";

        public static string GetPrimaryKey =
            @"select COLUMN_NAME from INFORMATION_SCHEMA.KEY_COLUMN_USAGE a
            inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS b
            on a.CONSTRAINT_NAME = b.CONSTRAINT_NAME
            where a.TABLE_CATALOG = '{0}' and a.table_name = '{1}' and constraint_type = 'Primary key'";

        //pstatic string Entity = "";

    }
}
