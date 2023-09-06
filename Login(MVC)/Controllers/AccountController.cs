using System;
using System.Web.Mvc;
using Login_MVC_.Models;
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            // Esta ação retorna a página de login.
            return View();
        }

        // Este método configura a string de conexão com o banco de dados.
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-ILA6CSR\\SQLGABRIELEXPRESS; database=dream_rh; integrated security=SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            // Configura a conexão e a abre.
            connectionString();
            con.Open();
            com.Connection = con;

            // Constrói uma consulta SQL para verificar as credenciais do usuário.
            com.CommandText = "select * from tbl_login where username='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                // Se uma linha foi encontrada, as credenciais são válidas. Você deve adicionar lógica aqui para lidar com a autenticação bem-sucedida.
                con.Close();
                return View(); // Retorna alguma view relacionada à autenticação bem-sucedida.
            }
            else
            {
                // Se não foram encontradas linhas, as credenciais são inválidas. Você deve adicionar lógica aqui para lidar com a autenticação falhada.
                con.Close();
                return View(); // Retorna alguma view relacionada à autenticação falhada.
            }
        }
    }
}
