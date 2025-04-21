using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Web03.Models;

namespace Web03.Controllers
{
    public class SeguridadController : Controller
    {
        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        public string server = "localhost";
        public string puerto = "3306";
        public string database = "empresabd";
        public string uid = "root";
        public string password="usbw";
        // GET: Seguridad
        void ConnectionString()
        {
            string constring;
            constring="SERVER="+server+";"+"PORT="+puerto+";"+"DATABASE="+database+";"+"UID="+uid+";"+"PASSWORD="+password+";";
            con=new MySqlConnection(constring);
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Verificar(User usu)
        { 
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tbusuario";
            dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                
                    con.Close();
                    return View("System");
                }
                else
                {
                    con.Close ();
                return View("Error");
                }
           
        }
    }
}