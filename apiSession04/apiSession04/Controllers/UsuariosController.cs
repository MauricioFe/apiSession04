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

        [HttpPost]
        public Usuario LoginUsuarios(Usuario usuario)
        {
            try
            {
                cmd = new SqlCommand($"Select usuario.id as usuarioId, nome, email, telefone, funcao.id, funcao " +
                    $"From usuario inner join funcao on funcao.id = usuario.funcaoid where email={usuario.Email} and Senha = {usuario.Senha}", conn);
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                Usuario usuarioLogado = null;
                foreach (DataRow item in dt.Rows)
                {
                    usuarioLogado = new Usuario();
                    usuarioLogado.Id = Convert.ToInt32(item["usuarioId"]);
                    usuarioLogado.Nome = item["Nome"].ToString();
                    usuarioLogado.Email = item["Email"].ToString();
                    usuarioLogado.Telefone = item["Telefone"].ToString();
                    usuarioLogado.FuncaoId = Convert.ToInt32(item["id"]);
                }
                conn.Close();
                return usuarioLogado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
