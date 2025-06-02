using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Foci
{
    public partial class Meccsek : Form
    {
        public Meccsek()
        {
            InitializeComponent();
        }
        public static string connection = "server=localhost;database=foci;user=root;password= ;";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Meccsek_Load(object sender, EventArgs e)
        {
            List<Merkozesek> merkozesek = new List<Merkozesek>();
            string[] sorok = File.ReadAllLines("foci.txt");
            foreach (string s in sorok) {
                string[] adatok = s.Split(',');
                Merkozesek merkozes = new Merkozesek(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4], adatok[5]);
                merkozesek.Add(merkozes);
            }
            foreach (var m in merkozesek)
            {
                dataGridView1.Rows.Add(m.datum, m.ellenfel, m.helyszin, m.sajatgol, m.ellenfelgol, m.nyerteke);
            }
            using (MySqlConnection conn = new MySqlConnection(connection)) {
            conn.Open();
                string query = "SELECT COUNT(*) FROM meccsek";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int soroksz = Convert.ToInt32(cmd.ExecuteScalar());
                    if (soroksz > 0)
                    {
                        string query1 = "INSERT INTO meccsek (datum, ellenfel, helyszin, sajatgol, ellenfelgol, nyerteke) VALUES (@datum, @ellenfel, @helyszin, @sajatgol, @ellenfelgol, @nyerteke)";
                        foreach (var mer in merkozesek) {
                            using (MySqlCommand cmd1 = new MySqlCommand (query1, conn))
                            {
                                cmd1.Parameters.AddWithValue("datum", mer.datum);
                                cmd1.Parameters.AddWithValue("ellenfel", mer.ellenfel);
                                cmd1.Parameters.AddWithValue("helyszin", mer.helyszin);
                                cmd1.Parameters.AddWithValue("sajatgol",mer.sajatgol);
                                cmd1.Parameters.AddWithValue("ellenfelgol",mer.ellenfelgol);
                                cmd1.Parameters.AddWithValue("nyerteke",mer.nyerteke);
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
