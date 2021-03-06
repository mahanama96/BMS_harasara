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

namespace BMS_harasara
{
    public partial class AccountHistoryUC_a : UserControl
    {
        private static AccountHistoryUC_a _instance_ah_a;
        public static AccountHistoryUC_a Instance_ah_a
        {
            get
            {
                if (_instance_ah_a == null)
                {
                    _instance_ah_a = new AccountHistoryUC_a();
                }
                return _instance_ah_a;
            }
        }
        public AccountHistoryUC_a()
        {
            InitializeComponent();
            FillCombo();
        }

        private void AccountHistoryUC_a_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AccountHistory Instance_ah
           /* if (!panel1.Controls.Contains(AccountHistory.Instance_ah))
            {
                panel1.Controls.Add(AccountHistory.Instance_ah);
                AccountHistory.Instance_ah.Dock = DockStyle.Fill;
                AccountHistory.Instance_ah.BringToFront();
            }
            else
            {
                AccountHistory.Instance_ah.BringToFront();
                AccountHistory.Instance_ah.Visible = true;
            }*/
           /*string query = "SELECT * FROM accounthistory where date BETWEEN '" + this.dateTimePicker2.Text + "'AND'" + this.dateTimePicker1.Text + "'";
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
            MySqlCommand cmdDataBase=new MySqlCommand(query,con);
            MySqlDataReader myreader;*/
            try
            {
                //con.Open();
                //myreader = cmdDataBase.ExecuteReader();
                Database db = new Database();
                DataSet ds = db.dbse("SELECT * FROM accounthistory where accountnumber='"+this.comboBox1.SelectedItem+"'AND date <='" + this.dateTimePicker2.Text + "' AND date>='" + this.dateTimePicker1.Text + "'");
                dataGridView1.DataSource = ds.Tables["load"];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void FillCombo()
        {
            string query="SELECT * FROM Account";
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
            MySqlCommand cmdDataBase=new MySqlCommand(query,con);
            MySqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString("AccountNumber");
                    comboBox1.Items.Add(sname);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillCombo();
        }

    }
}
