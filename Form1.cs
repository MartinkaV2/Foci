using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Foci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string connection = "server=localhost;database=foci;user=root;password= ;";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "INSERT INTO regisztracio (nev, email, jelszo, szuletesidatum) VALUES (@nev, @email, @jelszo, @szuletesidatum)";
                    using (MySqlCommand cmd = new MySqlCommand (query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nev", textBox1.Text);
                        cmd.Parameters.AddWithValue("@email", textBox2.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox3.Text);
                        cmd.Parameters.AddWithValue("szuletesidatum", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sikeres volt a regisztráció!");
                        Bejelentkezes b = new Bejelentkezes();
                        b.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
