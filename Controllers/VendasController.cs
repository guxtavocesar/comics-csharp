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
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Venda.Include(v => v.Cliente).Include(v => v.Quadrinho);
            return View(await contexto.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Quadrinho)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome");
            ViewData["IdQuadrinho"] = new SelectList(_context.Quadrinho, "IdQuadrinho", "Titulo");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdCliente,IdQuadrinho,Quantidade,ValorTotal,DataVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                // Buscar o quadrinho associado
                var quadrinho = await _context.Quadrinho.FindAsync(venda.IdQuadrinho);
                if (quadrinho == null)
                {
                    return NotFound("Quadrinho não encontrado.");
                }

                // Atualizar a quantidade em estoque
                if (quadrinho.QuantidadeEstoque >= venda.Quantidade)
                {
                    quadrinho.QuantidadeEstoque -= venda.Quantidade;
                }
                else
                {
                    ModelState.AddModelError("", "Quantidade insuficiente em estoque.");
                    return View(venda);
                }

                // Salvar a venda
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", venda.IdCliente);
            ViewData["IdQuadrinho"] = new SelectList(_context.Quadrinho, "IdQuadrinho", "Titulo", venda.IdQuadrinho);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", venda.IdCliente);
            ViewData["IdQuadrinho"] = new SelectList(_context.Quadrinho, "IdQuadrinho", "Titulo", venda.IdQuadrinho);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdCliente,IdQuadrinho,Quantidade,ValorTotal,DataVenda")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Buscar a venda original
                    var vendaOriginal = await _context.Venda.AsNoTracking().FirstOrDefaultAsync(v => v.IdVenda == id);
                    if (vendaOriginal == null)
                    {
                        return NotFound("Venda original não encontrada.");
                    }

                    // Buscar o quadrinho associado
                    var quadrinho = await _context.Quadrinho.FindAsync(venda.IdQuadrinho);
                    if (quadrinho == null)
                    {
                        return NotFound("Quadrinho não encontrado.");
                    }

                    // Atualizar a quantidade em estoque
                    var diferenca = vendaOriginal.Quantidade - venda.Quantidade;
                    if (quadrinho.QuantidadeEstoque + diferenca >= 0)
                    {
                        quadrinho.QuantidadeEstoque += diferenca;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Quantidade insuficiente em estoque.");
                        return View(venda);
                    }

                    // Atualizar a venda
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
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

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", venda.IdCliente);
            ViewData["IdQuadrinho"] = new SelectList(_context.Quadrinho, "IdQuadrinho", "Titulo", venda.IdQuadrinho);
            return View(venda);
        }


        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Quadrinho)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.IdVenda == id);
        }
    }
}
