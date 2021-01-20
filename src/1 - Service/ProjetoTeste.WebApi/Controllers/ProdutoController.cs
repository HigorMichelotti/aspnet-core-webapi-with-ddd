using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Application;
using ProjetoTeste.Application.ViewModels.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ProjetoTestePolicy")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoService;

        public ProdutoController(IProdutoApplicationService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var centroCustos = await _produtoService.ObterTodos();
            if (centroCustos.Count() <= 0) return NoContent();
            return Ok(centroCustos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ProdutoViewModel centroCustoViewModel)
        {
            var centroCusto = await _produtoService.Adicionar(centroCustoViewModel);
            if (!centroCusto.Status) return BadRequest(centroCusto);
            return Created("", centroCusto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(ProdutoViewModel centroCustoViewModel)
        {
            var centroCusto = await _produtoService.Atualizar(centroCustoViewModel);
            if (!centroCusto.Status) return BadRequest();
            return Ok(centroCusto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var centroCusto = await _produtoService.Deletar(id);
            if (!centroCusto.Status) return BadRequest(centroCusto);
            return Ok(centroCusto);
        }
    }
}
