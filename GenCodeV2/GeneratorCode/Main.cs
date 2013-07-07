using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CoreGen;

namespace GenCsharp
{
    public partial class Main : Form
    {
        private static string path;
        private DataTable _dtColumns;
        private DataTable _dtTables;

        public Main()
        {
            InitializeComponent();
        }

        public string PrimaryKey { get; set; }

        public static int ToInt32(object obj)
        {
            int retVal = 0;
            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Hide();
            var inputForm = new Input();
            inputForm.ShowDialog();
            ArrayList tagContent;
            bool isValid = true;
            try
            {
                tagContent = inputForm.ConnectorParam;
            }
            catch
            {
                MessageBox.Show("Input Cancelled.");
                isValid = false;
                goto Validity;
            }


            if (tagContent != null)
            {
                var server = tagContent[1] as string;
                var dataBase = tagContent[2] as string;
                var userID = tagContent[3] as string;
                var password = tagContent[4] as string;
                var namespaces = tagContent[5] as string;

                Args.Reset();
                Args.Type = EnmConnStrType.Authorized;
                //'Args.InitialCatalog = EnmConnStrType.Authorized; //contype.Equals(EnmConnStrType.Authorized.ToString()) ? EnmConnStrType.Authorized : EnmConnStrType.Trusted;
                Args.Server = server;
                Args.Database = dataBase;
                Args.UserId = userID;
                Args.Password = password;
                Args.NameSpaceName = namespaces;
                try
                {
                    checkedListBox1.Items.Clear();
                    _dtTables = new DataTable();
                    Args.WheredDb = dataBase;
                    Adapters.LsTablesDA.Fill(_dtTables);
                    checkedListBox1.BeginUpdate();
                    foreach (DataRow row in _dtTables.Rows)
                    {
                        checkedListBox1.Items.Add(row["TABLE_NAME"],true);
                    }
                    checkedListBox1.EndUpdate();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }

            #region Fill All Database

            //try
            //{
            //    Adapters.ServerDA.Fill(_dtDBs);
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid Input");
            //    Application.Exit();
            //}

            //foreach (DataRow row in _dtDBs.Rows)
            //{
            //    string dbname = row["name"].ToString();
            //    if (dbname != "master" && dbname != "tempdb" && dbname != "msdb" && dbname != "model" && dbname != "ReportServer" && dbname != "ReportServerTempDB")
            //    {
            //        listBox1.Items.Add(row["name"]);
            //    }
            //}

            #endregion

            Validity:
            if (isValid)
                Show();
            else
                Dispose(true);
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            if (rtxtClass.Text != String.Empty)
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    rtxtClass.ReadOnly = true;
                    rtxtClass.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Table.");
            }
        }

        private void btnSaveALL_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "";
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    text += GetValue(item.ToString());
                }
                GetValue("SQL", text, "SQL", "SqlCMD");
            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi: "+ex.Message);
            }
            MessageBox.Show("Đã generate thành công");
        }

        private string GetValue(string tableNames)
        {
            _dtColumns = new DataTable();
            if (tableNames.Equals("")) return "";
            string dbName = Args.Database;
            Args.InitialCatalog = dbName;
            Args.WheredTable = tableNames;
            Args.WheredDb = dbName;
            Adapters.LsColumnsDA.Fill(_dtColumns);

            PrimaryKey = Adapters.GetPrimarykey;

            try
            {
                string paths = Path.GetFullPath("Templete/" + Argument.FileEntity);
                rtxtClass.LoadFile(paths, RichTextBoxStreamType.PlainText);

                paths = Path.GetFullPath("Templete/" + Argument.FileData);
                rtData.LoadFile(paths, RichTextBoxStreamType.PlainText);

                paths = Path.GetFullPath("Templete/" + Argument.FileSproc);
                rtprocedure.LoadFile(paths, RichTextBoxStreamType.PlainText);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

            //Generator Entity
            Generator.BeginGeneration(rtxtClass.Text);
            Generator.AddTableDbName(tableNames, dbName);
            foreach (DataRow row in _dtColumns.Rows)
            {
                Generator.AddField(row["DATA_TYPE"].ToString(), row["COLUMN_NAME"].ToString());
            }
            Generator.EndGeneration();
            string textEntity = Generator.RawClassText.Replace("[namespace]", Args.NameSpaceName);
            GetValue(tableNames.Replace("tbl_", ""), textEntity.Replace("tbl_", ""), "Entity", "Info");

            ////Generator Service
            //Generator.BeginGeneration(rtService.Text);
            //Generator.AddTableDbName(tableNames, dbName);
            //Generator.EndGeneration();
            //string textService = Generator.RawClassText.Replace("[namespace]", Args.NameSpaceName);
            //GetValue("I" + tableNames.Replace("tbl_", ""), textService.Replace("tbl_", ""), "Services", "");

            ////Generator Implement
            //Generator.BeginGeneration(rtImplement.Text);
            //Generator.AddTableDbName(tableNames, dbName);
            //int c = _dtColumns.Rows.Count;
            //for (int i = 0; i < _dtColumns.Rows.Count; i++)
            //{
            //    DataRow row = _dtColumns.Rows[i];
            //    string colname = row["COLUMN_NAME"].ToString();
            //    bool pmkey = false;
            //    if (colname == PrimaryKey)
            //    {
            //        pmkey = true;
            //    }

            //    bool end = false;
            //    if (i == c - 1)
            //        end = true;
            //    Generator.AddParameterSql(colname, end, pmkey);
            //    Generator.AddReaderSql(row["DATA_TYPE"].ToString(), colname);
            //}
            //Generator.EndGeneration();
            //string textImpl = Generator.RawClassText.Replace("<column_name>", "").Replace("[namespace]",
            //                                                                              Args.NameSpaceName);
            //GetValue(tableNames.Replace("tbl_", ""), textImpl.Replace("tbl_", ""), "Impl", "Impl");

            //Generator Data
            Generator.BeginGeneration(rtData.Text);
            Generator.AddTableDbName(tableNames, dbName);
            int c = _dtColumns.Rows.Count;
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                string colname = row["COLUMN_NAME"].ToString();
                bool pmkey = false;
                if (colname == PrimaryKey)
                {
                    pmkey = true;
                }

                bool end = false;
                if (i == c - 1)
                    end = true;
                Generator.AddParameterSql(colname, end, pmkey);
                Generator.AddReaderSql(row["DATA_TYPE"].ToString(), colname);
            }
            Generator.EndGeneration();
            string textData = Generator.RawClassText.Replace("<column_name>", "").Replace("[namespace]",Args.NameSpaceName);
            GetValue(tableNames.Replace("tbl_", ""), textData.Replace("tbl_", ""), "Data", "Data");

            //Generator Storeprocedure
            Generator.BeginGeneration(rtprocedure.Text);
            Generator.AddTableDbName(tableNames, dbName);

            for (int i = 0; i < c; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                string colname = row["COLUMN_NAME"].ToString();
                bool pmkey = false;
                if (colname == PrimaryKey)
                    pmkey = true;
                bool end = false;
                if (i == c - 1)
                    end = true;

                Generator.AddParamSql(row["DATA_TYPE"].ToString(), colname,ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()),end, pmkey);
                Generator.AddFileData(colname, end, pmkey);
                Generator.AddFileParamInsert(colname, end, pmkey);
                Generator.AddParamSqlUpdate(row["DATA_TYPE"].ToString(), colname,ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()), end, pmkey);
                Generator.AddFileParamUpdate(colname, end, pmkey);
            }

            Generator.EndGeneration();
            return Generator.RawClassText.Replace("[column_name]", "").Replace("$column_name$", "").Replace(
                "!column_name!", "").
                Replace("#column_name#", "");
        }

        private void GetValue(string tableNames, string textForm, string prefixDev, string suffixWord)
        {
            string t = path;
            if (!Directory.Exists(path + "\\" + Args.NameSpaceName + "." + prefixDev))
            {
                Directory.CreateDirectory(path + "\\" + Args.NameSpaceName + "." + prefixDev);
            }
            using (
                var writer =
                    new StreamWriter(
                        path + "\\" + Args.NameSpaceName + "." + prefixDev + "\\" + tableNames + suffixWord + ".cs",
                        true))
            {
                writer.WriteLine(textForm);
            }
        }

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtClass.Clear();
            //rtService.Clear();
            //rtImplement.Clear();
            rtData.Clear();
            rtprocedure.Clear();

            _dtColumns = new DataTable();
            string tableName;
            try
            {
                tableName = checkedListBox1.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                return;
            }

            string dbName = Args.Database;
            Args.InitialCatalog = dbName;
            Args.WheredTable = tableName;
            Args.WheredDb = dbName;
            Adapters.LsColumnsDA.Fill(_dtColumns);

            PrimaryKey = Adapters.GetPrimarykey;

            try
            {
                string paths = Path.GetFullPath("Templete/" + Argument.FileEntity);
                rtxtClass.LoadFile(paths, RichTextBoxStreamType.PlainText);

                //string paths2 = Path.GetFullPath("Templete/" + Argument.FileService);
                //rtService.LoadFile(paths2, RichTextBoxStreamType.PlainText);
                //string paths3 = Path.GetFullPath("Templete/" + Argument.FileImpl);
                //rtImplement.LoadFile(paths3, RichTextBoxStreamType.PlainText);

                paths = Path.GetFullPath("Templete/" + Argument.FileData);
                rtData.LoadFile(paths, RichTextBoxStreamType.PlainText);

                paths = Path.GetFullPath("Templete/" + Argument.FileSproc);
                rtprocedure.LoadFile(paths, RichTextBoxStreamType.PlainText);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

            //Generator Entity
            Generator.BeginGeneration(rtxtClass.Text);
            Generator.AddTableDbName(tableName, dbName);
            foreach (DataRow row in _dtColumns.Rows)
            {
                Generator.AddField(row["DATA_TYPE"].ToString(), row["COLUMN_NAME"].ToString());
            }
            Generator.EndGeneration();
            rtxtClass.Text = Generator.RawClassText.Replace("[namespace]", Args.NameSpaceName);

            ////Generator Service
            //Generator.BeginGeneration(rtService.Text);
            //Generator.AddTableDbName(tableName, dbName);
            //Generator.EndGeneration();
            //rtService.Text = Generator.RawClassText.Replace("[namespace]", Args.NameSpaceName);

            ////Generator Implement
            //Generator.BeginGeneration(rtImplement.Text);
            //Generator.AddTableDbName(tableName, dbName);
            //int c = _dtColumns.Rows.Count;
            //for (int i = 0; i < _dtColumns.Rows.Count; i++)
            //{
            //    DataRow row = _dtColumns.Rows[i];
            //    string colname = row["COLUMN_NAME"].ToString();
            //    bool pmkey = false;
            //    if (colname == PrimaryKey)
            //    {
            //        pmkey = true;
            //    }

            //    bool end = false;
            //    if (i == c - 1)
            //        end = true;
            //    Generator.AddParameterSql(colname, end, pmkey);
            //    Generator.AddReaderSql(row["DATA_TYPE"].ToString(), colname);
            //}
            //Generator.EndGeneration();
            //rtImplement.Text = Generator.RawClassText.Replace("<column_name>", "").Replace("[namespace]",
            //                                                                               Args.NameSpaceName);


            //Generator Data
            Generator.BeginGeneration(rtData.Text);
            Generator.AddTableDbName(tableName, dbName);
            int c = _dtColumns.Rows.Count;
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                string colname = row["COLUMN_NAME"].ToString();
                bool pmkey = false;
                if (colname == PrimaryKey)
                {
                    pmkey = true;
                }

                bool end = false;
                if (i == c - 1)
                    end = true;
                Generator.AddParameterSql(colname, end, pmkey);
                Generator.AddReaderSql(row["DATA_TYPE"].ToString(), colname);
            }
            Generator.EndGeneration();
            rtData.Text = Generator.RawClassText.Replace("<column_name>", "").Replace("[namespace]",Args.NameSpaceName);

            //Generator Storeprocedure
            Generator.BeginGeneration(rtprocedure.Text);
            Generator.AddTableDbName(tableName, dbName);

            for (int i = 0; i < c; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                string colname = row["COLUMN_NAME"].ToString();
                bool pmkey = false;
                if (colname == PrimaryKey)
                    pmkey = true;
                bool end = false;
                if (i == c - 1)
                    end = true;

                Generator.AddParamSql(row["DATA_TYPE"].ToString(), colname,
                                      ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()), end, pmkey);
                Generator.AddFileData(colname, end, pmkey);
                Generator.AddFileParamInsert(colname, end, pmkey);
                Generator.AddParamSqlUpdate(row["DATA_TYPE"].ToString(), colname,
                                            ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()), end, pmkey);
                Generator.AddFileParamUpdate(colname, end, pmkey);
            }

            Generator.EndGeneration();
            rtprocedure.Text =
                Generator.RawClassText.Replace("[column_name]", "").Replace("$column_name$", "").Replace(
                    "!column_name!", "").Replace("#column_name#", "");
        }
    }
}