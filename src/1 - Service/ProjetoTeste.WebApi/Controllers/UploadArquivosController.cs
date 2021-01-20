using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebApi.Controllers
{
    [Route("api/upload-arquivos")]
    [ApiController]
    public class UploadArquivosController : ControllerBase
    {
        private readonly string _caminhoImagem;
        public UploadArquivosController()
        {
            //_caminhoImagem = @"C:/xampp/htdocs/arquivos-teste/"; // (Apache) Caso queira que as imagens apareçam no front basta salvar neste diretório e rodar o apache :)
            _caminhoImagem = @"C:\Users\higor.michelotti\source\repos\ProjetoTeste.WebApi\src\1 - Service\ProjetoTeste.WebApi\"; // (Diretório do projeto) É necessário trocar o diretorio de acordo com seu computador
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(_caminhoImagem + arquivo.FileName, FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                    }
                }

                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(IFormFile arquivo, [FromForm] string caminhoImagem)
        {

            if (ModelState.IsValid)
            {
                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(_caminhoImagem + arquivo.FileName, FileMode.Create))
                    {
                        if (System.IO.File.Exists(_caminhoImagem + caminhoImagem))
                        {
                            System.IO.File.Delete(_caminhoImagem + caminhoImagem);
                        }

                        await arquivo.CopyToAsync(fileStream);
                    }
                }

                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult Delete(string caminhoImagem)
        {
            if (ModelState.IsValid)
            {
                if (caminhoImagem != null && System.IO.File.Exists(_caminhoImagem + caminhoImagem))
                {
                    System.IO.File.Delete(_caminhoImagem + caminhoImagem);
                }
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
