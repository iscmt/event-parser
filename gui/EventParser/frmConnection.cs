using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace EventParser.GUI
{
    public partial class frmConnection : Form
    {
        public ConnectionSettings connectionSettings = null;// new ConnectionSettings();

        private string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = txtServerName.Text.Trim();
                if (cboAuthenticationType.SelectedIndex == 0)
                {
                    builder.IntegratedSecurity = true;
                }
                else
                {
                    builder.UserID = txtUserName.Text;
                    builder.Password = txtPassword.Text;
                }
                if (!string.IsNullOrEmpty(cboDatabases.Text))
                    builder.InitialCatalog = cboDatabases.Text.Trim();
                return builder.ConnectionString;
            }
        }

        public class ConnectionSettings
        {
            public enum ActionsIfTableExist
            {
                Drop,
                Append,
                Skip
            }

            public string ConnectionString { get; set; }
            public int ComandTimeout { get; set; } = 60;
            public bool DropAndRecreateTables { get; set; } = false;
        }

        public frmConnection()
        {
            InitializeComponent();
            cboAuthenticationType.SelectedIndex = 0;
        }

        private void cboAuthenticationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = (cboAuthenticationType.SelectedIndex == 1);
            lblUserName.Enabled = isSqlAuth;
            lblPassword.Enabled = isSqlAuth;
            txtUserName.Enabled = isSqlAuth;
            txtPassword.Enabled = isSqlAuth;

            cboDatabases.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.connectionSettings = new ConnectionSettings();
            this.connectionSettings.ConnectionString = this.ConnectionString;
            Arguments.connString = this.ConnectionString;
            Arguments.connString = (this.ConnectionString);
            Debug.Write(Arguments.connString);
            this.connectionSettings.ComandTimeout = Convert.ToInt32(updTimeout.Value);
            //this.connectionSettings.DropAndRecreateTables = chkDropCreate.Checked;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cboDatabases_DropDown(object sender, EventArgs e)
        {
            if (CheckRequiredFields(true) == false) return;

            LoadDatabases();

            if (cboDatabases.Items.Count != 0)
                cboDatabases.SelectedIndex = 0;
        }

        private bool CheckRequiredFields(bool showMessage = true)
        {
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                if (showMessage)
                    MessageBox.Show("Server Name must be specified.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboAuthenticationType.SelectedIndex == 1 && (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text)))
            {
                if (showMessage)
                    MessageBox.Show("User ID and Password must be specified.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void LoadDatabases()
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name FROM master..sysdatabases ORDER BY name ASC", cnn))
                {
                    cboDatabases.Items.Clear();
                    SqlDataReader dtr;
                    try
                    {
                        cnn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(ex.ToString());
                        return;
                    }

                    dtr = cmd.ExecuteReader();
                    while (dtr.Read())
                        cboDatabases.Items.Add(dtr[0].ToString());
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    cnn.Open();
                    MessageBox.Show("Test connection succeeded.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            if (this.connectionSettings == null)
                return;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(this.connectionSettings.ConnectionString);
            txtServerName.Text = builder.DataSource;
            if (builder.IntegratedSecurity == true)
                cboAuthenticationType.SelectedIndex = 0;
            cboDatabases.Text = builder.InitialCatalog;
            updTimeout.Value = this.connectionSettings.ComandTimeout;
            //chkDropCreate.Checked = this.connectionSettings.DropAndRecreateTables;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}