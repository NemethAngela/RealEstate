
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RealEstate_NA_Backend.Models;

namespace RealEstate_NA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=ingatlan2";

        [HttpGet]
        public IActionResult GetKategoriak()
        {
            List<Kategoria> listKategoriak = new List<Kategoria>();
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT id, nev FROM kategoriak";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string kategoriaNev = reader.GetString(1);
               
                //osztály neve:
                Kategoria ingatlan = new Kategoria()
                {
                    Id = id,
                    Nev = kategoriaNev
                };

                listKategoriak.Add(ingatlan);
            }

            connection.Close();

            return Ok(listKategoriak);
        }
    }
}
