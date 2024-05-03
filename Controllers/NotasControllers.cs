using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notas.Data;
using Notas.Models;


[Route("api/NotasController")]
[ApiController]

public class NotasController : Controller
{
    private readonly BaseContext  _context;

  public NotasController(BaseContext context)
  {
    _context = context;
  }
[HttpGet]
    public async Task<ActionResult<IEnumerable<Nota>>> GetNotas()
    {
        return await _context.Notas.ToListAsync();
    } 



    [HttpGet("{Id}")]    
    public async Task<ActionResult<Nota>> GetId(int Id)
        {
            var Nota = await _context.Notas.FindAsync(Id);
            if(Nota == null)
            {
                return NotFound();
            }
            return Nota;
        }
    [HttpPost]    
    public async Task<ActionResult<Nota>> PostNota(Nota nota)
    {
        _context.Notas.Add(nota);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostNota", new {id = nota.Id}, nota);
    }




}

