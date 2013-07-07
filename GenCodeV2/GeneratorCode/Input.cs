using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace GenCsharp
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        public static string Namespace;

        public ArrayList ConnectorParam { get; set; }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            string sConnect = string.Format("SERVER={0};DATABASE={1};UID={2};PWD={3};Connect Timeout=10", txtServer.Text, txtDatabase.Text, txtUserID.Text, txtPassword.Text);
            SqlConnection connection = new SqlConnection(sConnect);
            try
            {

                connection.Open();

                ConnectorParam = new ArrayList();
                ConnectorParam.Clear();
                ConnectorParam.Add(false);
                ConnectorParam.Add(txtServer.Text);
                ConnectorParam.Add(txtDatabase.Text);
                ConnectorParam.Add(txtUserID.Text);
                ConnectorParam.Add(txtPassword.Text);
                ConnectorParam.Add(txtnamespace.Text);
                Namespace = txtnamespace.Text;

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể connection đến database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void Input_Load(object sender, EventArgs e)
        {
            txtServer.Text = "localhost";
            txtDatabase.Text = "data";
            txtUserID.Text = "sa";
            txtPassword.Text = "123";
            txtnamespace.Text = "MVT";
            txtServer.Focus();
        }
    }
}