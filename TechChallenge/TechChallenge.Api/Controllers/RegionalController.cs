using Microsoft.AspNetCore.Mvc;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;

namespace TechChallenge.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RegionalController : ControllerBase
    {
        private readonly IAdicionarRegionalUseCase _adicionarRegionalUseCase;
        private readonly IAlterarRegionalUseCase _alterarRegionalUseCase;
        private readonly IObterRegionalUseCase _obterRegionalUseCase;
        private readonly IListarRegionalUseCase _listarRegionalUseCase;
        private readonly IRemoverRegionalUseCase _removerRegionalUseCase;

        public RegionalController(IAdicionarRegionalUseCase adicionarRegionalUseCase,
            IAlterarRegionalUseCase alterarRegionalUseCase,
            IObterRegionalUseCase obterRegionalUseCase,
            IListarRegionalUseCase listarRegionalUseCase,
            IRemoverRegionalUseCase removerRegionalUseCase)
        {
            _adicionarRegionalUseCase = adicionarRegionalUseCase;
            _alterarRegionalUseCase = alterarRegionalUseCase;
            _obterRegionalUseCase = obterRegionalUseCase;
            _listarRegionalUseCase = listarRegionalUseCase;
            _removerRegionalUseCase = removerRegionalUseCase;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Obter([FromRoute] Guid id)
        {
            try
            {
                return Ok(_obterRegionalUseCase.ObterPorId(id));
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
                return Ok(_listarRegionalUseCase.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}/Contatos")]
        public IActionResult ListarContatosPorRegionalId(Guid id)
        {
            try
            {
                return Ok(_listarRegionalUseCase.ListarContatosPorRegionalId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{ddd:int}/Contatos")]
        public IActionResult ListarContatosPorDdd(int ddd)
        {
            try
            {
                return Ok(_listarRegionalUseCase.ListarContatosPorDdd(ddd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(AdicionarRegionalDto adicionarRegionalDto)
        {
            try
            {
                return Ok(_adicionarRegionalUseCase.Adicionar(adicionarRegionalDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(AlterarRegionalDto alterarRegionalDto)
        {
            try
            {
                _alterarRegionalUseCase.Alterar(alterarRegionalDto);
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
                _removerRegionalUseCase.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
