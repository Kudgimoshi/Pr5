using System;
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
    public partial class Form2 : Form
    {
        DataSet data;
        SqlDataAdapter Forg;
        SqlCommandBuilder FFNP;
        //Подключение к SQL Servery
        string connectionString = @"Data Source=DESKTOP-S2RGCRQ\SQLEXPRESS03; Initial Catalog=LD; Integrated Security=True";
        string sql = "SELECT * FROM Ucheniki";
        public Form2()
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

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);
                FFNP = new SqlCommandBuilder(Forg);
                Forg.InsertCommand = new SqlCommand("add_Ucheniki", connection);
                Forg.InsertCommand.CommandType = CommandType.StoredProcedure;
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Nomer_pp", SqlDbType.Int, 0, "Nomer_pp"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Familia", SqlDbType.VarChar, 30, "Familia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Imia", SqlDbType.VarChar, 30, "Imia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Otchestvo", SqlDbType.VarChar, 30, "Otchestvo"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Pol", SqlDbType.VarChar, 10, "Pol"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Data_rozhdenia", SqlDbType.Date, 0, "Data_rozhdenia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Nomer_Lichnogo_dela", SqlDbType.VarChar, 30, "Nomer_Lichnogo_dela"));
                Forg.Update(data);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
