﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Web;

namespace BMS_harasara
{
    public partial class PettyCashUC_Add_Summary : UserControl
    {
        private static PettyCashUC_Add_Summary _instance_pc_as;
        public static PettyCashUC_Add_Summary Instance_pc_as
        {
            get
            {
                if (_instance_pc_as == null)
                {
                    _instance_pc_as = new PettyCashUC_Add_Summary();
                }
                return _instance_pc_as;
            }
        }
        public PettyCashUC_Add_Summary()
        {
            InitializeComponent();
        }

        private void PettyCashUC_Add_Summary_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            PettyCashUC_Add_Summary.Instance_pc_as.Visible = false;
            PettyCashUC_Add.Instance_pca.BringToFront();
            PettyCashUC_Add.Instance_pca.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            loadChart();
        }
        public void CalculateTotal()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
            MySqlDataReader myreader;
            if (string.Compare(comboBox1.SelectedItem.ToString(),"Sales")==0)
            {
                try
                {
                    string query = "SELECT SUM(Sales) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Profit/Loss") == 0)
            {
                try
                {
                    string query = "SELECT (SUM(Sales)+SUM(Other)+SUM(Income)+SUM(Capital))-(SUM(Salary)+SUM(Utility)+SUM(Rent)) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        if (Convert.ToDouble(tsales) < 0)
                        {
                            label2.Text = tsales;
                            label1.ForeColor = System.Drawing.Color.Red;
                            label1.Text = "Loss";
                        }
                        else
                        {
                            label2.Text = tsales;
                            label1.ForeColor=System.Drawing.Color.Green;
                            label1.Text = "Profit";
                        }
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(string.Compare(comboBox1.SelectedItem.ToString(),"Salary")==0)
            {
                try
                {
                    string query = "SELECT SUM(Salary) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Utility") == 0)
            {
                try
                {
                    string query = "SELECT SUM(Utility) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Rent") == 0)
            {
                try
                {
                    string query = "SELECT SUM(Rent) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Income") == 0)
            {
                try
                {
                    string query = "SELECT SUM(Income) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Capital") == 0)
            {
                try
                {
                    string query = "SELECT SUM(Capital) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Other") == 0)
            {
                try
                {
                    string query = "SELECT SUM(Other) FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        string tsales = myreader.GetString(0);
                        label2.Text = tsales;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Value From the ComboBox");
            }
        }
        public void loadChart()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
            MySqlDataReader myreader;
            if (string.Compare(comboBox1.SelectedItem.ToString(), "Sales") == 0)
            {
                try
                {
                    string query = "SELECT Sales,Date FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        this.chart1.Series["bar1"].Points.AddXY(myreader.GetString("date"), myreader.GetDouble("sales"));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (string.Compare(comboBox1.SelectedItem.ToString(), "Income") == 0)
            {
                try
                {
                    string query = "SELECT Income,Date FROM pettycash WHERE date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'";
                    MySqlCommand cmnd = new MySqlCommand(query, con);
                    con.Open();
                    myreader = cmnd.ExecuteReader();
                    while (myreader.Read())
                    {
                        //string inc = myreader.GetString(0);
                        this.chart1.Series["bar1"].Points.AddXY(myreader.GetString("date"), myreader.GetDouble("income"));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            CalculateTotal();
            loadChart();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
