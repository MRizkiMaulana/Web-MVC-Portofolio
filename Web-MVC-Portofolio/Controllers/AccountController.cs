using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_MVC_Portofolio.Models;
using MySql.Data.MySqlClient;
using BCrypt.Net;


namespace Web_MVC_Portofolio.Controllers
{
    public class AccountController : Controller
    {
        private MySqlConnection con;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        private void ConnectionString()
        {
            string connectionString = "Server=127.0.0.1; Database=portofolio; Uid=root; Pwd=; Charset=utf8mb4;";
            con = new MySqlConnection(connectionString);
        }

        [HttpPost]
        public ActionResult Verifikasi(Account acc)
        {
            ConnectionString();
            con.Open();

            string query = "SELECT * FROM users WHERE username = @username AND password = @password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", acc.Username);
            cmd.Parameters.AddWithValue("@password", acc.Password); // Langsung menggunakan password plain-text

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // User found and password matches
                reader.Close();
                con.Close();
                return RedirectToAction("Index", "Dashboard/Index");
            }

            // User not found or password does not match
            reader.Close();
            con.Close();
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("Login");
        }
    }
}