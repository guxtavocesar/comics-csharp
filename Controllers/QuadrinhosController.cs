using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicShop.Models;

namespace Comics.Controllers
{
    public class QuadrinhosController : Controller
    {
        private readonly Contexto _context;

        public QuadrinhosController(Contexto context)
        {
            _context = context;
        }

        // GET: Quadrinhos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Quadrinho.Include(q => q.Editora).Include(q => q.Fornecedor);
            return View(await contexto.ToListAsync());
        }

        // GET: Quadrinhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .Include(q => q.Editora)
                .Include(q => q.Fornecedor)
                .FirstOrDefaultAsync(m => m.IdQuadrinho == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // GET: Quadrinhos/Create
        public IActionResult Create()
        {
            ViewData["IdEditora"] = new SelectList(_context.Editora, "IdEditora", "Nome");
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "Nome");
            return View();
        }

        // POST: Quadrinhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuadrinho,Titulo,Autor,Preco,IdEditora,QuantidadeEstoque,IdFornecedor")] Quadrinho quadrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quadrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEditora"] = new SelectList(_context.Editora, "IdEditora", "Nome", quadrinho.IdEditora);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "Nome", quadrinho.IdFornecedor);
            return View(quadrinho);
        }

        // GET: Quadrinhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho.FindAsync(id);
            if (quadrinho == null)
            {
                return NotFound();
            }
            ViewData["IdEditora"] = new SelectList(_context.Editora, "IdEditora", "Nome", quadrinho.IdEditora);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "Nome", quadrinho.IdFornecedor);
            return View(quadrinho);
        }

        // POST: Quadrinhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuadrinho,Titulo,Autor,Preco,IdEditora,QuantidadeEstoque,IdFornecedor")] Quadrinho quadrinho)
        {
            if (id != quadrinho.IdQuadrinho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quadrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuadrinhoExists(quadrinho.IdQuadrinho))
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
            ViewData["IdEditora"] = new SelectList(_context.Editora, "IdEditora", "Nome", quadrinho.IdEditora);
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "IdFornecedor", "Nome", quadrinho.IdFornecedor);
            return View(quadrinho);
        }

        // GET: Quadrinhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .Include(q => q.Editora)
                .Include(q => q.Fornecedor)
                .FirstOrDefaultAsync(m => m.IdQuadrinho == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // POST: Quadrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quadrinho = await _context.Quadrinho.FindAsync(id);
            if (quadrinho != null)
            {
                _context.Quadrinho.Remove(quadrinho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuadrinhoExists(int id)
        {
            return _context.Quadrinho.Any(e => e.IdQuadrinho == id);
        }
    }
}
