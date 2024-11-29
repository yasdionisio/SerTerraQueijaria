using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerTerraQueijaria.Data;
using SerTerraQueijaria.Models;

namespace SerTerraQueijaria.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly SerTerraContext _context;

        public ProdutosController(SerTerraContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var serTerraContext = _context.Produtos.Include(p => p.TiposProdutos);
            return View(await serTerraContext.ToListAsync());
        }

        public async Task<IActionResult> ProdutosCard()
        {
            var serTerraContext = _context.Produtos.Include(p => p.TiposProdutos);
            return View(await serTerraContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.TiposProdutos)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["TiposProdutosId"] = new SelectList(_context.TiposProd, "TiposProdutosId", "TipoProduto");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,NomeProduto,Descricao,PrecoUnitario,QtdEstoque,TiposProdutosId")] Produto produto, IFormFile Imagem)
        {
            if (ModelState.IsValid)
            {
                produto.ProdutoId = Guid.NewGuid();

                // Verifique se um arquivo foi enviado
                if (Imagem != null && Imagem.Length > 0)
                {
                    // Gera um nome único para a imagem
                    var nomeArquivo = Path.GetFileName(Imagem.FileName);
                    var extArquivo = Path.GetExtension(Imagem.FileName);

                    // Alterar o nome do arquivo.
                    nomeArquivo = String.Concat(produto.ProdutoId.ToString().ToUpper(), extArquivo);

                    var caminhoSalvar = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "produto", nomeArquivo);

                    // Salva a imagem no diretório
                    using (var stream = new FileStream(caminhoSalvar, FileMode.Create))
                    {
                        Imagem.CopyTo(stream);
                    }

                    // Armazena o caminho da imagem no modelo
                    produto.Imagem = "/img/produto/" + nomeArquivo;
                }

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
              
            }

            ViewData["TiposProdutosId"] = new SelectList(_context.TiposProd, "TiposProdutosId", "TipoProduto", produto.TiposProdutosId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["TiposProdutosId"] = new SelectList(_context.TiposProd, "TiposProdutosId", "TipoProduto", produto.TiposProdutosId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdutoId,NomeProduto,Descricao,PrecoUnitario,QtdEstoque,TiposProdutosId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["TiposProdutosId"] = new SelectList(_context.TiposProd, "TiposProdutosId", "TipoProduto", produto.TiposProdutosId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.TiposProdutos)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
