using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using CoreGen;

namespace GenCsharp
{
    public partial class Main : Form
    {
        DataTable _dtTables;
        DataTable _dtColumns;

        public string PrimaryKey { get; set; }

        public Main()
        {
            InitializeComponent();
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtClass.Clear();
            rtService.Clear();
            rtImplement.Clear();
            rtprocedure.Clear();

            _dtColumns = new DataTable();
            string tableName;
            try
            {
                tableName = listBox2.SelectedItem.ToString();
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
                var paths1 = Path.GetFullPath("Templete/" + Argument.FileEntity);
                rtxtClass.LoadFile(paths1, RichTextBoxStreamType.PlainText);

                var paths2 = Path.GetFullPath("Templete/" + Argument.FileService);
                rtService.LoadFile(paths2, RichTextBoxStreamType.PlainText);

                var paths3 = Path.GetFullPath("Templete/" + Argument.FileImpl);
                rtImplement.LoadFile(paths3, RichTextBoxStreamType.PlainText);

                var paths4 = Path.GetFullPath("Templete/" + Argument.FileSproc);
                rtprocedure.LoadFile(paths4, RichTextBoxStreamType.PlainText);
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

            //Generator Service
            Generator.BeginGeneration(rtService.Text);
            Generator.AddTableDbName(tableName, dbName);
            Generator.EndGeneration();
            rtService.Text = Generator.RawClassText.Replace("[namespace]", Args.NameSpaceName);

            //Generator Implement
            Generator.BeginGeneration(rtImplement.Text);
            Generator.AddTableDbName(tableName, dbName);
            int c = _dtColumns.Rows.Count;
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                var colname = row["COLUMN_NAME"].ToString();
                var pmkey = false;
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
            rtImplement.Text = Generator.RawClassText.Replace("<column_name>", "").Replace("[namespace]", Args.NameSpaceName);

            //Generator Storeprocedure
            Generator.BeginGeneration(rtprocedure.Text);
            Generator.AddTableDbName(tableName, dbName);

            for (int i = 0; i < c; i++)
            {
                DataRow row = _dtColumns.Rows[i];
                var colname = row["COLUMN_NAME"].ToString();
                var pmkey = false;
                if (colname == PrimaryKey)
                    pmkey = true;
                bool end = false;
                if (i == c - 1)
                    end = true;

                Generator.AddParamSql(row["DATA_TYPE"].ToString(), colname, ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()), end, pmkey);
                Generator.AddFileData(colname, end, pmkey);
                Generator.AddFileParamInsert(colname, end, pmkey);
                Generator.AddParamSqlUpdate(row["DATA_TYPE"].ToString(), colname, ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString()), end, pmkey);
                Generator.AddFileParamUpdate(colname, end, pmkey);
            }

            Generator.EndGeneration();
            rtprocedure.Text = Generator.RawClassText.Replace("[column_name]", "").Replace("$column_name$", "").Replace("!column_name!", "").Replace("#column_name#", "");
        }

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
            var isValid = true;
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
                Args.NameSpaceName = tagContent[5] as string;

                Args.Reset();
                Args.Type = EnmConnStrType.Authorized;
                Args.Server = server;
                Args.Database = dataBase;
                Args.UserId = userID;
                Args.Password = password;

                try
                {
                    listBox2.Items.Clear();
                    _dtTables = new DataTable();
                    Args.WheredDb = dataBase;
                    Adapters.LsTablesDA.Fill(_dtTables);
                    listBox2.BeginUpdate();
                    foreach (DataRow row in _dtTables.Rows)
                    {
                        listBox2.Items.Add(row["TABLE_NAME"]);
                    }
                    listBox2.EndUpdate();
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
    }
}