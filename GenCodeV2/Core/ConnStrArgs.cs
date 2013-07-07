using System;

namespace CoreGen
{
    [Serializable]
    public static class Args
    {

        public static void Reset()
        {
            Database =
                DataSource =
                InitialCatalog =
                Password =
                Server =
                UserId = null;
            Type = EnmConnStrType.Default;
        }

        private static EnmConnStrType _type = EnmConnStrType.Default;

        public static EnmConnStrType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public static string DataSource { get; set; }

        public static string InitialCatalog { get; set; }

        public static string Server { get; set; }

        public static string Database { get; set; }

        public static string UserId { get; set; }

        public static string Password { get; set; }

        public static string WheredTable { get; set; }

        public static string WheredDb { get; set; }

        public static string NameSpaceName { get; set; }
    }
}