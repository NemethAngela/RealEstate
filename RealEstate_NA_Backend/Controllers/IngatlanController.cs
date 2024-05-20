
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RealEstate_NA_Backend.Models;

namespace RealEstate_NA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngatlanController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=ingatlan2";

        [HttpGet]
        public IActionResult GetIngatlanok()
        {
            List<Ingatlan> listIngatlanok = new List<Ingatlan>();
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT i.id, k.nev, i.leiras, i.hirdetesDatuma, i.tehermentes, i.ar, i.kepUrl FROM ingatlanok i INNER JOIN kategoriak k ON i.kategoriaId = k.id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string kategoriaNev = reader.GetString(1);
                string leiras = reader.GetString(2);
                DateTime hirdetesDatuma = reader.GetDateTime(3);
                bool tehermentes = reader.GetBoolean(4);
                int ar = reader.GetInt32(5);
                string kepUrl = reader.GetString(6);
                //osztály neve:
                Ingatlan ingatlan = new Ingatlan()
                {
                    Id = id,
                    KategoriaNev = kategoriaNev,
                    Leiras = leiras,
                    HirdetesDatuma = hirdetesDatuma,
                    Tehermentes = tehermentes,
                    Ar = ar,
                    KepUrl = kepUrl
                };
                listIngatlanok.Add(ingatlan);
            }

            connection.Close();

            return Ok(listIngatlanok);
        }

        [HttpPost]
        public IActionResult CreateIngatlan([FromBody] Ingatlan ingatlan)
        {
            // Ellenőrizzük a modell érvényességét
            if (ingatlan == null ||
                ingatlan.KategoriaId <= 0 ||
                string.IsNullOrEmpty(ingatlan.Leiras) ||
                ingatlan.HirdetesDatuma == null ||
                ingatlan.Ar <= 0 ||
                string.IsNullOrEmpty(ingatlan.KepUrl))
            {
                return BadRequest("Hiányos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO ingatlanok (kategoriaId, leiras, hirdetesDatuma, tehermentes, ar, kepUrl) VALUES (@kategoriaId, @leiras, @hirdetesDatuma, @tehermentes, @ar, @kepUrl)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@kategoriaId", ingatlan.KategoriaId);
            cmd.Parameters.AddWithValue("@leiras", ingatlan.Leiras);
            cmd.Parameters.AddWithValue("@hirdetesDatuma", ingatlan.HirdetesDatuma);
            cmd.Parameters.AddWithValue("@tehermentes", ingatlan.Tehermentes);
            cmd.Parameters.AddWithValue("@ar", ingatlan.Ar);
            cmd.Parameters.AddWithValue("@kepUrl", ingatlan.KepUrl);

            cmd.ExecuteNonQuery();
            long insertedIngatlanId = cmd.LastInsertedId;

            connection.Close();

            return Created("id", insertedIngatlanId);
        }

        [HttpDelete]
        public IActionResult DeleteIngatlan(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM ingatlanok WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 0) 
                return NotFound(result);
         
            return NoContent();
        }
    }
}
