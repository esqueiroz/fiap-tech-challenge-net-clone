using Microsoft.AspNetCore.Mvc;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;
        private readonly IAlterarContatoUseCase _alterarContatoUseCase;
        private readonly IObterContatoUseCase _obterContatoUseCase;
        private readonly IListarContatoUseCase _listarContatoUseCase;
        private readonly IRemoverContatoUseCase _removerContatoUseCase;

        public ContatoController(IAdicionarContatoUseCase adicionarContatoUseCase,
            IAlterarContatoUseCase alterarContatoUseCase,
            IObterContatoUseCase obterContatoUseCase,
            IListarContatoUseCase listarContatoUseCase,
            IRemoverContatoUseCase removerContatoUseCase)
        {
            _adicionarContatoUseCase = adicionarContatoUseCase;
            _alterarContatoUseCase = alterarContatoUseCase;
            _obterContatoUseCase = obterContatoUseCase;
            _listarContatoUseCase = listarContatoUseCase;
            _removerContatoUseCase = removerContatoUseCase;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Obter([FromRoute] Guid id)
        {
            try
            {
                return Ok(_obterContatoUseCase.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_listarContatoUseCase.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(AdicionarContatoDto adicionarContatoDto)
        {
            try
            {
                return Ok(_adicionarContatoUseCase.Adicionar(adicionarContatoDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(AlterarContatoDto alterarContatoDto)
        {
            try
            {
                _alterarContatoUseCase.Alterar(alterarContatoDto);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                _removerContatoUseCase.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
