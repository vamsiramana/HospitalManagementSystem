﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class pharmacistViewAll : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        private void connectDatabase()
        {
            String db = "server=localhost;user id=root;password=vamsi123;database=dbs2";
            conn = new MySqlConnection(db);
            conn.Open();
        }

        private void fillInDGV()
        {
            try
            {
                connectDatabase();
                String query = "select * from medicine";
                comm = new MySqlCommand(query, conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_medicines");
                dt = ds.Tables["Tbl_dates"];
                medicinesDGV.DataSource = ds;
                medicinesDGV.DataMember = "Tbl_medicines";
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("" + E, "Exception Encountered");
            }
        }

        public pharmacistViewAll()
        {
            InitializeComponent();
            fillInDGV();
        }

        private void refreshB_Click(object sender, EventArgs e)
        {
            fillInDGV();
            MessageBox.Show("Refreshed", "Information");
        }
    }
}
