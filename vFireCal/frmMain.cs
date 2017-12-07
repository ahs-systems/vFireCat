using System;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace vFireCal
{
    public partial class frmMain : Form
    {
        private string ConnStr = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\vFireCat.dat;Uid=Admin;Pwd=;";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = ConnStr;
                string _sqlString = "SELECT DISTINCT vFireType, CatDesc as [Title / Description], WhatsIncluded as [Whats Included], OneLiner as [One Liner] " +
                        "FROM vFireCat WHERE INSTR(UCASE(vFireType), ?) > 0 OR " +
                        "INSTR(UCASE(CatDesc), ?) > 0 OR INSTR(UCASE(WhatsIncluded), ?) > 0 OR INSTR(UCASE(OneLiner), ?) " +
                        "ORDER BY vFireType, CatDesc; ";

                using (OdbcDataAdapter da = new OdbcDataAdapter(_sqlString, myConnection))
                {
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", txtSearchStr.Text.Trim().ToUpper());
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", txtSearchStr.Text.Trim().ToUpper());
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", txtSearchStr.Text.Trim().ToUpper());
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", txtSearchStr.Text.Trim().ToUpper());

                    DataTable t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (dataGridView1.Rows.Count == 0)
                    {
                        lblMsg1.Text = "0 item(s) found.";
                    }
                    else
                    {
                        lblMsg1.Text = dataGridView1.Rows.Count + " item(s) found.";
                    }
                }


            }
        }



        private void dataGridView1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedCells[3].Value.ToString());
        }

        private void txtSearchStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnCopyCatDesc1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("There is nothing to copy from");
                return;
            }

            Clipboard.SetText(dataGridView1.SelectedCells[1].Value.ToString().Trim());
            lblMsg1.Text = "Category Description copied to clipboard!";
            timer1.Tag = "1";
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Tag.ToString() == "1") // update lblMsg1
            {
                lblMsg1.Text = dataGridView1.Rows.Count + " item(s) found.";
            }
            else // Update lblsMsg2
            {
                lblMsg2.Text = "";
            }
            timer1.Enabled = false;
            Update();
        }

        private void btnCopyOneLiner1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("There is nothing to copy from");
                return;
            }

            Clipboard.SetText(dataGridView1.SelectedCells[3].Value.ToString().Trim());
            lblMsg1.Text = "One liner copied to clipboard!";
            timer1.Tag = "1";
            timer1.Enabled = true;
        }

        private void CheckIfDbExist()
        {
            if (!File.Exists(Application.StartupPath + @"\vFireCat.dat"))
            {
                MessageBox.Show("Database is missing, program cannot continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void PopulateV_FireType()
        {
            CheckIfDbExist();

            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = ConnStr;
                string _sqlString = "SELECT DISTINCT vFireType FROM vFireCat ORDER BY vFireType";

                using (OdbcDataAdapter da = new OdbcDataAdapter(_sqlString, myConnection))
                {
                    //da.SelectCommand.Parameters.AddWithValue("SearchStr", txtSearchStr.Text.Trim().ToUpper());                  

                    DataTable t = new DataTable();
                    da.Fill(t);
                    lbV_FireType.DisplayMember = "vFireType";
                    lbV_FireType.DataSource = t;
                }
            }
        }

        private void PopulateCategoryDesc(string _vFireType)
        {
            CheckIfDbExist();

            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = ConnStr;
                string _sqlString = "SELECT DISTINCT CatDesc FROM vFireCat WHERE vFireType = ? ORDER BY CatDesc";

                using (OdbcDataAdapter da = new OdbcDataAdapter(_sqlString, myConnection))
                {
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _vFireType);

                    DataTable t = new DataTable();
                    da.Fill(t);
                    lbCatDesc.DisplayMember = "CatDesc";
                    lbCatDesc.DataSource = t;
                }
            }
        }

        private void PopulateWhatsIncluded(string _vFireType, string _CatDesc)
        {
            CheckIfDbExist();

            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = ConnStr;
                string _sqlString = "SELECT DISTINCT WhatsIncluded FROM vFireCat WHERE vFireType = ? AND CatDesc = ? ORDER BY WhatsIncluded";

                using (OdbcDataAdapter da = new OdbcDataAdapter(_sqlString, myConnection))
                {
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _vFireType);
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _CatDesc);

                    DataTable t = new DataTable();
                    da.Fill(t);
                    lbWhatsIncluded.DisplayMember = "WhatsIncluded";
                    lbWhatsIncluded.DataSource = t;
                }
            }
        }

        private void PopulateOneLiner(string _vFireType, string _CatDesc, string _whatsIncluded)
        {
            CheckIfDbExist();

            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = ConnStr;
                string _sqlString = "SELECT DISTINCT OneLiner FROM vFireCat WHERE vFireType = ? AND CatDesc = ? AND WhatsIncluded = ? ORDER BY OneLiner";

                using (OdbcDataAdapter da = new OdbcDataAdapter(_sqlString, myConnection))
                {
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _vFireType);
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _CatDesc);
                    da.SelectCommand.Parameters.AddWithValue("SearchStr", _whatsIncluded);

                    DataTable t = new DataTable();
                    da.Fill(t);
                    lbOneLiner.DisplayMember = "OneLiner";
                    lbOneLiner.DataSource = t;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateV_FireType();
            btnSearch_Click(sender, e);
        }

        private void lbV_FireType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCategoryDesc(lbV_FireType.GetItemText(lbV_FireType.SelectedValue));
        }

        private void lbCatDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateWhatsIncluded(lbV_FireType.GetItemText(lbV_FireType.SelectedValue), lbCatDesc.GetItemText(lbCatDesc.SelectedValue));
        }

        private void lbWhatsIncluded_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOneLiner(lbV_FireType.GetItemText(lbV_FireType.SelectedValue), lbCatDesc.GetItemText(lbCatDesc.SelectedValue), lbWhatsIncluded.GetItemText(lbWhatsIncluded.SelectedValue));
        }

        private void btnCopyCatDesc2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbCatDesc.GetItemText(lbCatDesc.SelectedValue).Trim());
            lblMsg2.Text = "Category Description copied to clipboard!";
            timer1.Tag = "2";
            timer1.Enabled = true;
        }

        private void btnCopyOneLiner2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbOneLiner.GetItemText(lbOneLiner.SelectedValue).Trim());
            lblMsg2.Text = "Category Description copied to clipboard!";
            timer1.Tag = "2";
            timer1.Enabled = true;
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        mnuCopyFromList.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        private void mnuCopyEmpNum_Click(object sender, EventArgs e)
        {
            btnCopyCatDesc1_Click(sender, e);
        }

        private void mnuCopyEmpName_Click(object sender, EventArgs e)
        {
            btnCopyOneLiner1_Click(sender, e);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchStr.Text = "";
            btnSearch_Click(sender, e);
        }
    }
}
