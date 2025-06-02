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
using MySqlX.XDevAPI;

namespace Foci
{
    public partial class Bejelentkezes : Form
    {
        public Bejelentkezes()
        {
            InitializeComponent();
        }

        public static string connection = "server=localhost;database=foci;user=root;password= ;";

        private void Bejelentkezes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email, jelszo;
            email = textBox1.Text;
            jelszo = textBox2.Text;

            try {
                using (MySqlConnection conn = new MySqlConnection(connection)) {
                    conn.Open();
                    string query = "SELECT * FROM regisztracio WHERE email = @email AND jelszo = @jelszo";
                    using (MySqlDataAdapter data = new MySqlDataAdapter(query, conn))
                    {
                        data.SelectCommand.Parameters.AddWithValue("@email", email);
                        data.SelectCommand.Parameters.AddWithValue("@jelszo", jelszo);
                        DataTable datatable = new DataTable();
                        data.Fill(datatable);
                        if (datatable.Rows.Count > 0)
                        {
                            MessageBox.Show("Sikeres volt a belépés!");
                            textBox1.Clear();
                            textBox2.Clear();

                            Session.belepemail = email;
                            Meccsek meccsek = new Meccsek();

                            meccsek.Show();
                            this.Hide();
                        }
                    }
                }
                }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message);
            }
        }
    }
}
