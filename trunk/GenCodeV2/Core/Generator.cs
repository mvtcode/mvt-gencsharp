using System;

namespace CoreGen
{
    public static class Generator
    {

        public static string RawClassText { get; set; }

        public static void BeginGeneration(string rawText)
        {
            RawClassText = rawText;
        }

        public static void EndGeneration()
        {
            RawClassText = RawClassText.Replace("<column_name>", "");
        }

        public static void Reset()
        {
            RawClassText = String.Empty;
        }

        public static void AddTableDbName(string tableName, string dbName)
        {
            tableName = tableName.Replace(" ", "");
            RawClassText =
                RawClassText.Replace("<table_name>", tableName).Replace("<database_name>", dbName);

            switch (Args.Type)
            {
                case EnmConnStrType.Trusted:
                    RawClassText =
                        RawClassText.Replace("<server_name>", Args.DataSource);
                    break;
                case EnmConnStrType.Authorized:
                    RawClassText =
                        RawClassText.Replace("<server_name>", Args.Server);
                    break;
                default:
                    RawClassText =
                        RawClassText.Replace("<server_name>", ".");
                    break;
            }
        }

        public static void AddField(string dataType, string colName)
        {
            string propertyType;
            switch (dataType)
            {
                case "int":
                case "bigint":
                    propertyType = "int";
                    break;
                case "nvarchar":
                case "varchar":
                case "text":
                case "ntext":
                    propertyType = "string";
                    break;
                case "datetime":
                case "smalldatetime":
                    propertyType = "DateTime";
                    break;
                case "money":
                case "bigmoney":
                case "smallmoney":
                    propertyType = "double";
                    break;
                case "tinyint":
                    propertyType = "byte";
                    break;
                case "decimal":
                    propertyType = "decimal";
                    break;
                case "image":
                    propertyType = "byte[]";
                    break;
                case "bit":
                    propertyType = "bool";
                    break;
                default:
                    propertyType = "object";
                    break;
            }
            var propertyName = colName.Replace(" ", "");
            var fieldText =
                String.Format("public {0} {1}", propertyType, propertyName) + " { get; set; }\n\t\t<column_name>";
            RawClassText = RawClassText.Replace("<column_name>", fieldText);
        }

        public static void AddParamSql(string dataType, string colName, int maxlength, bool end, bool pmkey)
        {
            var sml = "";
            if (dataType.ToLower() == "varchar" || dataType.ToLower() == "nvarchar")
            {
                sml = "(" + maxlength + ")";
            }
            var c = ",";
            if (end)
            {
                c = "";
            }
            if (pmkey)
            {
                var propertyName = colName.Replace(" ", "");
                var fieldText =
                    String.Format("@{0} {1}{2}", propertyName, dataType, sml) + "\n\t";
                RawClassText = RawClassText.Replace("<column_name>", fieldText);
            }
            else
            {
                var propertyName = colName.Replace(" ", "");
                var fieldText =
                    String.Format("@{0} {1}{2}{3}", propertyName, dataType, sml, c) + "\n\t[column_name]";
                RawClassText = RawClassText.Replace("[column_name]", fieldText);
            }

        }

        public static void AddParamSqlUpdate(string dataType, string colName, int maxlength, bool end, bool pmkey)
        {
            var sml = "";
            if (dataType.ToLower() == "varchar" || dataType.ToLower() == "nvarchar")
            {
                sml = "(" + maxlength + ")";
            }
            var fieldText = "";
            var propertyName = colName.Replace(" ", "");
            if (end)
            {
                fieldText = String.Format("@{0} {1}{2}", propertyName, dataType, sml) + "\n\t";
            }
            else
            {
                fieldText = String.Format("@{0} {1}{2},", propertyName, dataType, sml) + "\n\t[column_nameu]";
            }


            RawClassText = RawClassText.Replace("[column_nameu]", fieldText);
        }

        public static void AddFileData(string colName, bool end, bool pmkey)
        {
            if (pmkey)
            {
                return;
            }
            var c = ",";
            if (end)
            {
                c = "";
            }

            var propertyName = colName.Replace(" ", "");
            var fieldText =
                String.Format("[{0}]{1}", propertyName, c) + "\n\t\t$column_name$";
            RawClassText = RawClassText.Replace("$column_name$", fieldText);
        }

        public static void AddFileParamInsert(string colName, bool end, bool pmkey)
        {
            var c = ",";
            if (end)
            {
                c = "";
            }

            if (pmkey)
            {
                return;
            }
            var propertyName = colName.Replace(" ", "");
            var fieldText =
                String.Format("@{0}{1}", propertyName, c) + "\n\t\t!column_name!";
            RawClassText = RawClassText.Replace("!column_name!", fieldText);
        }

        public static void AddFileParamUpdate(string colName, bool end, bool pmkey)
        {
            if (pmkey)
            {

                var propertyName = colName.Replace(" ", "");
                var fieldText =String.Format("{0}=@{1}", propertyName, propertyName) + "\n\t\t";
                RawClassText = RawClassText.Replace("#primakey#", fieldText);

                var fieldText1 = String.Format("{0}", propertyName) + "\n\t\t";
                RawClassText = RawClassText.Replace("#primakey1#", fieldText1);
            }
            else
            {
                var c = ",";
                if (end)
                {
                    c = "";
                }

                var propertyName = colName.Replace(" ", "");
                var fieldText =
                    String.Format("[{0}]=@{1}{2}", propertyName, propertyName, c) + "\n\t\t#column_name#";
                RawClassText = RawClassText.Replace("#column_name#", fieldText);
            }
        }

        public static void AddParameterSql(string colName, bool end, bool pmkey)
        {
            var propertyName = colName.Replace(" ", "");
            if (pmkey)
            {
                var fieldText = String.Format("new SqlParameter(\"@{0}\", id)", propertyName) + "\n\t\t\t";
                RawClassText = RawClassText.Replace("#primakey#", fieldText);

                var fieldText1 = String.Format("new SqlParameter(\"@{0}\", info.{0})", propertyName) + "\n\t\t\t";
                RawClassText = RawClassText.Replace("#primakey1#", fieldText1);
            }
            else
            {
                var fieldText = "";


                if (end)
                {
                    fieldText = String.Format("new SqlParameter(\"@{0}\", info.{0})", propertyName) + "\t\t\t";
                }
                else
                {
                    fieldText = String.Format("new SqlParameter(\"@{0}\", info.{0}),", propertyName) + "\n\t\t\t[column_name]";
                }

                RawClassText = RawClassText.Replace("[column_name]", fieldText);
            }
        }

        public static void AddReaderSql(string dataType, string colName)
        {
            var propertyName = colName.Replace(" ", "");
            var fieldText = "";
            //info.Birthday = r["Birthday"].ToString();
            switch (dataType)
            {
                case "int":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetInt32(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "bigint":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetInt64(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "nvarchar":
                case "varchar":
                case "text":
                case "ntext":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetString(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "datetime":
                case "smalldatetime":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetDateTime(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "money":
                case "bigmoney":
                case "smallmoney":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetDouble(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "bit":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetBoolean(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "tinyint":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetInt16(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                case "decimal":
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = r.GetDecimal(r.GetOrdinal(\"{0}\"));\n\t\t\t<column_name>", propertyName);
                    break;
                default:
                    fieldText = String.Format("if (!r.IsDBNull(r.GetOrdinal(\"{0}\"))) info.{0} = (Object)r[\"{0}\"];\n\t\t\t<column_name>", propertyName);
                    break;
            }

            RawClassText = RawClassText.Replace("<column_name>", fieldText);
        }
    }
}