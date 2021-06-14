using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace test_task_cs
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);

                sqlConnection.Open();

                if(sqlConnection.State == ConnectionState.Open)
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Shipment;", sqlConnection);

                    DataSet db = new DataSet();

                    da.Fill(db);

                    dataGridView1.DataSource = db.Tables[0];
                }
            }
            catch(Exception)
            {
                throw;
            }

        }
   
        private void button1_Click(object sender, EventArgs e)
        {

            CheckBox[] box = new CheckBox[5];

            box[0] = checkBox1;
            box[1] = checkBox2;
            box[2] = checkBox3;
            box[3] = checkBox4;
            box[4] = checkBox5;

            string checkBoxSelect = "";

            for (int i = 0; i < box.Length; i++)
            {
                if (box[i].Checked)
                {
                    if (checkBoxSelect == "")
                    {
                        checkBoxSelect = box[i].Text;
                    }
                    else
                    {
                        checkBoxSelect += ", " + box[i].Text;
                    }
                }
            }

            string query = "SELECT " + checkBoxSelect + ", Sum(Количество) AS Количество, Sum(Сумма) AS Сумма FROM Shipment GROUP BY " + checkBoxSelect + " ;";

            if (checkBoxSelect == "")
            {
                query = "SELECT * FROM Shipment;";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);

            DataSet db = new DataSet();

            da.Fill(db);

            dataGridView1.DataSource = db.Tables[0];


        }
    }
}
