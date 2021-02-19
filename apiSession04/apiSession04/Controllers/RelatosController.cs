using apiSession04.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSession04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatosController : ControllerBase
    {
        private readonly Session4Context _context;

        public RelatosController(Session4Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Relatos> GetRelatos()
        {
            return _context.Relatos.Include(u => u.Usuario).ToList();
        }

        [HttpGet("{id}", Name = "GetRelato")]
        public Relatos GeById(int id)
        {
            return _context.Relatos.Include(u => u.Usuario).FirstOrDefault(u => u.Id == id);
        }
        [HttpPost]
        public IActionResult Create(Relatos relatos)
        {
            if (relatos == null)
                return BadRequest();
            _context.Relatos.Add(relatos);
            int i = _context.SaveChanges();
            if (i > 0)
                return CreatedAtRoute("GetRelato", new { id = relatos.Id }, relatos);
            return BadRequest("Erro no servidor");
        }
        [HttpPut]
        public IActionResult Update(Relatos relatos, int id)
        {
            var relato = GeById(id);
            if (relato == null)
                return BadRequest();
            _context.Relatos.Update(relatos);
            int i = _context.SaveChanges();
            if (i > 0)
                return CreatedAtRoute("GetRelato", new { id = relatos.Id }, relatos);
            return BadRequest("Erro no servidor");
        }
        [HttpPut]
        public IActionResult Remove(int id)
        {
            var relato = GeById(id);
            if (relato == null)
                return BadRequest();
            _context.Relatos.Remove(relato);
            int i = _context.SaveChanges();
            if (i > 0)
                return Ok(new { Message = "Excluido com sucesso" });
            return BadRequest("Erro no servidor");
        }
    }
}
