using System;
using System.Windows.Forms;
using System.Collections;

namespace GenCsharp
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        public ArrayList ConnectorParam { get; set; }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            ConnectorParam = new ArrayList();
            ConnectorParam.Clear();
            ConnectorParam.Add(false);
            ConnectorParam.Add(txtServer.Text);
            ConnectorParam.Add(txtDatabase.Text);
            ConnectorParam.Add(txtUserID.Text);
            ConnectorParam.Add(txtPassword.Text);
            ConnectorParam.Add(txtnamespace.Text);
            Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Input_Load(object sender, EventArgs e)
        {
            txtServer.Text = "LOCALHOST";
            txtDatabase.Text = "AbcCms";
            txtUserID.Text = "sa";
            txtPassword.Text = "123456";


            //btnConnect2_Click(sender, e);
        }
    }
}