﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pp20
{
    public partial class Form3 : Form
    {
        DataSet data;
        SqlDataAdapter Forg;
        SqlCommandBuilder FFNP;
        //Подключение к SQL Servery
        string connectionString = @"Data Source=DESKTOP-S2RGCRQ\SQLEXPRESS03; Initial Catalog=LD; Integrated Security=True";
        string sql = "SELECT * FROM Roditeli";
        public Form3()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);

                data = new DataSet();
                Forg.Fill(data);
                dataGridView1.DataSource = data.Tables[0];
            }
        }

        void openchild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = data.Tables[0].NewRow();
            data.Tables[0].Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchild(panel1, new Form2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);
                FFNP = new SqlCommandBuilder(Forg);
                Forg.InsertCommand = new SqlCommand("add_Roditeli", connection);
                Forg.InsertCommand.CommandType = CommandType.StoredProcedure;
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Nomer_pp", SqlDbType.Int, 0, "Nomer_pp"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@FIO_otca", SqlDbType.VarChar, 100, "FIO_otca"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Mesto_raboti_otca", SqlDbType.VarChar, 100, "Mesto_raboti_otca"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Telefon_otca ", SqlDbType.VarChar, 11, "Telefon_otca "));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@FIO_materi ", SqlDbType.VarChar, 100, "FIO_materi "));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Mesto_raboti_materi", SqlDbType.VarChar, 100, "Mesto_raboti_materi"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Telefon_materi ", SqlDbType.VarChar, 30, "Telefon_materi "));
                Forg.Update(data);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
