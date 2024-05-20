using System.Windows.Forms;
using MySqlConnector;
using RealEstate.Models;

namespace RealEstateGUI
{
    public partial class Form1 : Form
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=ingatlan";
        int selectedSellerId = -1;

        public Form1()
        {
            InitializeComponent();
            FillListBoxEladok();
        }

        private void FillListBoxEladok()
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            
            string query = "SELECT id, name, phone FROM sellers ORDER BY name";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!

            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string phone = reader.GetString(2);
                //osztály neve:
                Seller sellers = new Seller() { Id = id, Name = name, Phone = phone };
                listBoxEladok.Items.Add(sellers);
            }

            listBoxEladok.ValueMember = "Id"; // ez az egyedi kulcsa a kiválaszotott Elado listbox itemnek
            listBoxEladok.DisplayMember = "Name"; // ezt jelenítjük meg 

            connection.Close();
        }



        private void listBoxEladok_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSeller = listBoxEladok.SelectedItem as Seller;  //a kiválasztott item Seller típusra konvertálva
            if (selectedSeller != null) //van-e kiválasztott Seller tpusú obj.
            {
                textBoxNev.Text = selectedSeller.Name;
                textBoxTel.Text = selectedSeller.Phone;
                selectedSellerId = selectedSeller.Id;
            }
        }

        private void buttonHirdetesekBetoltese_Click(object sender, EventArgs e)
        {
            if (selectedSellerId < 0)
            {
                // nincs kiválasztva seller
                return;
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
          
            string query = "SELECT count(id) FROM `realestates` WHERE sellerId = @sellerId";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@sellerId", selectedSellerId);
            Int64 adCount = (Int64)cmd.ExecuteScalar(); //egy érték esetén

            textBoxHSz.Text = adCount.ToString();   //betöltjük a textbox-ba a hirdetések számát
           
            connection.Close();
        }
    }
}