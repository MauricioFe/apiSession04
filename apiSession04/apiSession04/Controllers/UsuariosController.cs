using apiSession04.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace apiSession04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Session4Context _context;

        public UsuariosController(Session4Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuario.Include(u => u.Funcao).ToList();
        }

        [HttpGet("{id}")]
        public Usuario GeById(int id)
        {
            return _context.Usuario.Include(u => u.Funcao).FirstOrDefault(u => u.Id == id);
        }
        [HttpPost]
        public Usuario Login(Usuario usuario)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha); 
        }
    }
}
