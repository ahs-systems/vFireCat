using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using OfficeOpenXml;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LogsApp2
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan ts;
        bool toggleStopWatch;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (comboBox1.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Please select a category");
            //        comboBox1.Focus();
            //        return;
            //    }

            //    int mins;
            //    if (!int.TryParse(txtMins.Text, out mins))
            //    {
            //        MessageBox.Show("Only whole numbers can be entered in minutes");
            //        txtMins.Focus();
            //        return;
            //    }                

           

            //    if (txtMins.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter minutes");
            //        txtMins.Focus();
            //        return;
            //    }

            //    using (OdbcConnection myConnection = new OdbcConnection())
            //    {
            //        //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
            //        myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\logs.mdb;Uid=Admin;Pwd=;";
            //        myConnection.Open();

            //        OdbcCommand myCommand = myConnection.CreateCommand();

            //        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //        string category = comboBox1.SelectedIndex == -1 ? "" : comboBox1.SelectedItem.ToString();
            //        string subCategory = comboBox2.SelectedIndex == -1 ? "" : comboBox2.SelectedItem.ToString();
            //        myCommand.CommandText = "Insert into logs (user, category, sub_category, comments, minutes) values ('" + userName +
            //            "', '" + category + "', '" + subCategory + "', '" + Regex.Replace(txtComments.Text.Trim(), "[][\"'-]","`") +
            //            "', " + txtMins.Text.Trim() + ")";

            //        SaveIt(myCommand.CommandText);

            //        myCommand.ExecuteNonQuery();

            //        //myCommand.CommandText = "SELECT SUM(MINUTES) AS TOTAL FROM LOGS where  FORMAT(now(),'mm-dd-yyyy') = FORMAT(DATESAVED,'mm-dd-yyyy')";

            //        //OdbcDataReader myReader;
            //        //myReader = myCommand.ExecuteReader();
            //        //myReader.Read();

            //        //lblTotalMinutes.Text = myReader["TOTAL"].ToString();
            //        //myReader.Close();

            //        MessageBox.Show("Successfully Saved!", "Confirmation");                    
            //        txtComments.Text = txtMins.Text = "";

            //        dateTimePicker1.Value = DateTime.Today;
            //        GetTotalMinutes(dateTimePicker1.Value.ToString("MM-dd-yyyy"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ooops, there's an error: " + ex.Message, "ERROR");
            //}
        }

        private void SaveIt(string _sqlCommand)
        {
            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\regionalstaf\Operations - RSSS Systems Group\WorkstationInstall\logs.dat;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = _sqlCommand;
                    myCommand.ExecuteNonQuery();
                    myCommand.Dispose();
                }
            }
            catch
            {
                
            }
        }

        private void GetTotalMinutes(string _date)
        {
            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {                   

                    //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();

                    if (rdoAll.Checked)
                    {
                        myCommand.CommandText = "SELECT (SELECT SUM(MINUTES) FROM LOGS where '" + _date + "' = FORMAT(DATESAVED,'MM-dd-yyyy')) AS TOTAL_USER, " +
                                        "(SELECT COUNT(*) * 435  FROM (SELECT DISTINCT USER FROM LOGS where '" + _date + "' = FORMAT(DATESAVED,'MM-dd-yyyy'))) AS TOTAL FROM DUAL";
                    }
                    else
                    {
                        string _CurrUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;                        

                        myCommand.CommandText = "SELECT (SELECT SUM(MINUTES) FROM LOGS where '" + _date + "' = FORMAT(DATESAVED,'MM-dd-yyyy') AND USER = '" + _CurrUser + "') AS TOTAL_USER, " +
                                                "(SELECT COUNT(*) * 435  FROM (SELECT DISTINCT USER FROM LOGS where '" + _date + "' = FORMAT(DATESAVED,'MM-dd-yyyy') AND USER = '" + _CurrUser + "')) AS TOTAL FROM DUAL";
                    }


                    OdbcDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    myReader.Read();
                    if (myReader["TOTAL_USER"].ToString() != "")
                    {
                        lblTotalMinutes.Text = myReader["TOTAL_USER"].ToString();

                        pbCurrentUser.Value = (int)((Convert.ToDouble(myReader["TOTAL_USER"]) / Convert.ToDouble(myReader["TOTAL"])) * 100) < 100 ? 
                            (int)((Convert.ToDouble(myReader["TOTAL_USER"]) / Convert.ToDouble(myReader["TOTAL"])) * 100) : 100;
                        lblPercentage.Text = ((int)((Convert.ToDouble(myReader["TOTAL_USER"]) / Convert.ToDouble(myReader["TOTAL"])) * 100)) + "% from max of " + myReader["TOTAL"] + " mins.";
                        if (rdoAll.Checked)
                        {
                            //pbCurrentUser.Value = (int)((Convert.ToDouble(myReader["TOTAL_USER"]) / Convert.ToDouble(myReader["TOTAL"])) * 100);
                            //lblPercentage.Text = pbCurrentUser.Value + "% from total " + myReader["TOTAL"].ToString() + " mins.";
                            lblPercentage.Text += " (" + (Convert.ToDouble(myReader["TOTAL"]) / 435).ToString() + " pax)";
                        }
                    }
                    else
                    {
                        lblTotalMinutes.Text = "0";
                        lblPercentage.Text = "0%";
                        pbCurrentUser.Value = 0;
                    }
                    myReader.Close();
                    myReader.Dispose();
                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCategory(comboBox1.SelectedItem.ToString());
            
        }

        private void LoadSubCategory(string _category)
        {
            try
            {
                comboBox2.Items.Clear();

                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();
                    myCommand.CommandText = "SELECT Sub_Category from SUB_CATEGORY_DROPDOWN WHERE Category = '" + _category + "' ORDER BY Sub_Category";
                    OdbcDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        comboBox2.Visible = true;
                        while (myReader.Read())
                        {
                            comboBox2.Items.Add(myReader["Sub_Category"].ToString());
                        }
                    }
                    else
                    {
                        comboBox2.Visible = false;
                    }
                    myReader.Close();
                    myReader.Dispose();
                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Text + ":  Current User[" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "]";
            rdoCurrentUser.Text = "For \"" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "\"";
            dateTimePicker1.Value = DateTime.Today;

            LoadCategory();

            GetTotalMinutes(dateTimePicker1.Value.ToString("MM-dd-yyyy"));

            //MessageBox.Show(Application.StartupPath);
        }

        private void LoadCategory()
        {
            try
            {
                comboBox1.Items.Clear();

                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();
                    myCommand.CommandText = "SELECT Category from CATEGORY_DROPDOWN ORDER BY Category";
                    OdbcDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            comboBox1.Items.Add(myReader["Category"].ToString());
                        }
                    }
                    myReader.Close();
                    myReader.Dispose();
                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetTotalMinutes(dateTimePicker1.Value.ToString("MM-dd-yyyy"));
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string _date = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            string _filter = "";

            if (rdoCurrentUser.Checked)
            {
                _filter = " AND user = '" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "'";
            }

            using (OdbcConnection myConnection = new OdbcConnection())
            {
                //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\logs.mdb;Uid=Admin;Pwd=;";
                myConnection.Open();

                OdbcCommand myCommand = myConnection.CreateCommand();

                myCommand.CommandText = "SELECT user, FORMAT(dateSaved,'ddmmmyyyy hh:mm:ss') as [Date Saved], Category, Sub_Category, minutes, comments FROM LOGS WHERE '" + _date + "' = FORMAT(DATESAVED,'MM-dd-yyyy')" + _filter;
                //myCommand.CommandText = "SELECT * FROM LOGS";

                OdbcDataAdapter _da = new OdbcDataAdapter(myCommand);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                using (ExcelPackage pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                    ws.Cells["A1"].LoadFromDataTable(_dt, true);
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "Logs " + DateTime.Now.ToString("ddMMMyy");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pck.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }                    
                }

                _da.Dispose();
            }
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            if (!toggleStopWatch) 
            {
                txtMins.Text = "";
                stopWatch.Reset();
                stopWatch.Start();
                dateTimePicker1.Enabled = comboBox1.Enabled = comboBox2.Enabled = txtComments.Enabled = txtMins.Enabled = btnSave.Enabled = button2.Enabled = btnExportToExcel.Enabled = false;
                timer1.Enabled = true;
            }
            else
            {
                stopWatch.Stop();
                timer1.Enabled = false;
                txtMins.Text =  ((ts.Hours * 60) + (ts.Minutes + 1)).ToString();
                btnTimer.Text = "Start Timer";
                dateTimePicker1.Enabled = comboBox1.Enabled = comboBox2.Enabled = txtComments.Enabled = txtMins.Enabled = btnSave.Enabled = button2.Enabled = btnExportToExcel.Enabled = true;
            }
            toggleStopWatch = !toggleStopWatch;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);

            btnTimer.Text = elapsedTime;
            btnTimer.Update();
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            GetTotalMinutes(dateTimePicker1.Value.ToString("MM-dd-yyyy"));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetTotalMinutes(dateTimePicker1.Value.ToString("MM-dd-yyyy"));
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
            }
            else if (e.Button == MouseButtons.Right)
            {
                // frmCredits _frm = new frmCredits();
                //_frm.ShowDialog();
            }
        }
    }
}
