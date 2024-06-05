using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_MVC_Portofolio.Models;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Web.Security;


namespace Web_MVC_Portofolio.Controllers
{
    public class AccountController : Controller
    {
        private MySqlConnection con;

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Verifikasi(Account acc)
        {
            ConnectionString();
            con.Open();

            string query = "SELECT * FROM users WHERE username = @username AND password = @password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", acc.Username);
            cmd.Parameters.AddWithValue("@password", acc.Password);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Autentikasi berhasil, atur sesi atau tanda pengenal pengguna di sini jika diperlukan
                reader.Close();
                con.Close();

                // Set cookie autentikasi menggunakan FormsAuthentication
                FormsAuthentication.SetAuthCookie(acc.Username, false);

                return RedirectToAction("Index", "Dashboard/Index");
            }

            // Autentikasi gagal
            reader.Close();
            con.Close();
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("Login");
        }

        // GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            // Hapus cookie autentikasi
            FormsAuthentication.SignOut();

            // Redirect ke halaman login setelah logout
            return RedirectToAction("Login", "Account");
        }

        private void ConnectionString()
        {
            string connectionString = "Server=127.0.0.1; Database=portofolio; Uid=root; Pwd=; Charset=utf8mb4;";
            con = new MySqlConnection(connectionString);
        }
    }
}