using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;

namespace Patrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosController(IEquipamentoRepository contexto)
        {
            _equipamentoRepository = contexto;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_equipamentoRepository.Listar());
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public IActionResult Listar(int id)
        {
            return Ok (_equipamentoRepository.BuscarPorID(id));

        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Alterar (int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

           _equipamentoRepository.Alterar(equipamento);

            return NoContent();
        }

        // POST: api/Equipamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Cadastrar (Equipamento equipamento, IFormFile arquivo)
        {
            #region Upload da Imagem com extensões permitidas apenas
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            equipamento.Imagem = uploadResultado;
            #endregion

            equipamento.DataCadastro = DateTime.Now;

            _equipamentoRepository.Cadastrar(equipamento);
            
            return Created("equipamento",equipamento);
        }

        // DELETE: api/Equipamentos/5
        [HttpDelete ("{id}")]
        public IActionResult Excluir(int id)
        {
            var EquipamentoAchado = _equipamentoRepository.BuscarPorID(id);

            if (EquipamentoAchado == null)
            {
                return NotFound();
            }

            _equipamentoRepository.Excluir(EquipamentoAchado);

            return NoContent();
        }

        //private bool EquipamentoExists(int id)
        //{
            //return _context.Equipamentos.Any(e => e.Id == id);

            //return _equipamentoRepository.BuscarPorID(id);    
        //}
    }
}
