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
    public partial class ExpenditureManagerUC : UserControl
    {
        private static ExpenditureManagerUC _instance;
        public static ExpenditureManagerUC Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenditureManagerUC();
                }
                return _instance;
            }
        }
        public ExpenditureManagerUC()
        {
            InitializeComponent();
            LoadLabels();
            LoadExpenditure();
            LoadBalance();
        }

        private void ExpenditureManagerUC_Load(object sender, EventArgs e)
        {

        }
        public void LoadLabels()
        {
            //string date=trunc
            try
            {
                DateTime dt=DateTime.Now;
                string dat = dt.ToString("yyyy-MM-dd");
                string query = "SELECT profit,date FROM profit_loss WHERE date='"+dat+"'";
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
                MySqlCommand cmnd = new MySqlCommand(query, con);
                MySqlDataReader myReader;
                con.Open();
                myReader = cmnd.ExecuteReader();
                while(myReader.Read())
                {
                    string inc = myReader.GetString("profit");
                    string pdate = myReader.GetString("date");
                    bunifuCustomLabel5.Text = inc;
                    bunifuCustomLabel6.Text = dat;
                    bunifuCustomLabel7.Text = dat;
                    bunifuCustomLabel10.Text = dat;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadExpenditure()
        {
            try
            {
                DateTime dt = DateTime.Now;
                string dat = dt.ToString("yyyy-MM-dd");
                string query = "SELECT SUM(Salary)+SUM(Utility)+SUM(Rent) FROM pettycash WHERE date='" + dat + "'";
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
                MySqlCommand cmnd = new MySqlCommand(query, con);
                MySqlDataReader myReader;
                con.Open();
                myReader = cmnd.ExecuteReader();
                while (myReader.Read())
                {
                    string bal = myReader.GetString(0);
                    bunifuCustomLabel8.Text = bal;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadBalance()
        {
            try
            {
                DateTime dt = DateTime.Now;
                string dat = dt.ToString("yyyy-MM-dd");
                string query = "SELECT BALANCE FROM account WHERE accountnumber=123456789112456";
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=harasaraindustries");
                MySqlCommand cmnd = new MySqlCommand(query, con);
                MySqlDataReader myReader;
                con.Open();
                myReader = cmnd.ExecuteReader();
                while (myReader.Read())
                {
                    string bal = myReader.GetString(0);
                    bunifuCustomLabel11.Text = bal;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
