using apiSession04.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace apiSession04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        SqlConnection conn = new SqlConnection(@"Data source= .\SQLEXPRESS; Initial Catalog=SessaoMobile; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                cmd = new SqlCommand("Select * From Usaurio inner join funcao on funcao.id =  usuario.funcaoid", conn);
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                foreach (var item in dt.Rows)
                {

                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return usuarios;
        }
    }
}
