#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agendamentos_jacto.Models;
using Nancy.Json;

namespace agendamentos_jacto.Controllers
{
    public class AgendaController : Controller
    {
        private readonly Contexto _context;

        public AgendaController(Contexto context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            //Retorna somente os seus agendamentos
            return View(await _context.Agendas.AsNoTracking()
                .Where(predicate: x => x.User == User.Identity.Name)
                .ToListAsync()); ;
           
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }
            //Usuario só consegue ver seus agendamentos
            if (agenda.User != User.Identity.Name)
            {
                return NotFound();
            }
           
            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local,Cep,Endereco,Bairro,Cidade,Estado,Detalhes,Feito,CriadoEm,FinalizacaoEstimada,FinalizadoEm,User")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                //Pega o usuario logado
                agenda.User = User.Identity.Name;

                //Usuario não consegue salvar uma data anterior da atual
                agenda.CriadoEm = DateTime.Now;

                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local,Cep,Endereco,Bairro,Cidade,Estado,Detalhes,Feito,CriadoEm,FinalizacaoEstimada,FinalizadoEm,User")] Agenda agenda)
        {
            //Usuario não consegue salvar uma data anterior da atual
            agenda.CriadoEm = DateTime.Now;
            

            if(agenda.Feito == true && agenda.FinalizadoEm  < agenda.FinalizacaoEstimada)
            {
                return Ok("Data e hora finalizada tem que ser igual ou maior Data e hora estimada");
            }
            if (id != agenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.Id == id);
        }

        /*
        public string Consulta(string cep)
        {
            var cepObj = Cep.Busca(cep);
            return new Nancy.Json.JavaScriptSerializer().Serialize(cepObj);
        }
        */
    }
   
}
