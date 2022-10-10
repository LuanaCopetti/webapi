using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIProdutos.Business;
using APIProdutos.Models;
using Microsoft.AspNetCore.Authorization;

namespace APIProdutos.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{codigoBarras}")]
        public IActionResult Get(string codigoBr)
        {
            var produto = _service.Obter(codigoBr);
            if (produto != null)
                return new ObjectResult(produto);
            else
                return NotFound();
        }

        [HttpPost]
        public Resultado Post([FromBody]Produto produto)
        {
            return _service.Incluir(produto);
        }

        [HttpPut]
        public Resultado Put([FromBody]Produto produto)
        {
            return _service.Atualizar(produto);
        }

        [HttpDelete("{codigobr}")]
        public Resultado Delete(string codigobr)
        {
            return _service.Excluir(codigobr);
        }
    }
}