using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace vFireCal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\vFireCat.mdb;Uid=Admin;Pwd=;";
                string _sqlString = "SELECT DISTINCT vFireType, CatDesc as [Cat Desc], WhatsIncluded as [Whats Included], OneLiner as [One Liner] " +
                        "FROM OneLiner WHERE INSTR(UCASE(vFireType), ?) > 0 OR " +
                        "INSTR(UCASE(CatDesc), ?) > 0 OR INSTR(UCASE(WhatsIncluded), ?) > 0 OR INSTR(UCASE(OneLiner), ?) " +
                        "ORDER BY vFireType, CatDesc; ";

                //myConnection.Open();
                //OdbcCommand _comm = myConnection.CreateCommand();
                //_comm.CommandText = _sqlString;
                //OdbcDataReader _dr = _comm.ExecuteReader();
                //MessageBox.Show(_dr.HasRows.ToString());



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
    }
}
