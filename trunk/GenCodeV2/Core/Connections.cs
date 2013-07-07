using System;
using System.Data.SqlClient;

namespace CoreGen
{
    public enum EnmConnStrType
    {
        Trusted,
        Authorized,
        Default
    }

    internal static class Connections
    {
        #region private fields

        private static SqlConnection _connection = null;

        #endregion

        internal static SqlConnection GetConnection()
        {
            switch (Args.Type)
            {
                case EnmConnStrType.Trusted:
                    return _connection = 
                           new SqlConnection(
                               String.Format(Constants.ConnStrTrusted, Args.DataSource, Args.InitialCatalog));
                case EnmConnStrType.Authorized:
                    return _connection = 
                           new SqlConnection(
                               String.Format(
                                   Constants.ConnStrAuth, 
                                   Args.Server, Args.Database, Args.UserId, Args.Password));
                default:
                    return null;
            }
        }
    }
}