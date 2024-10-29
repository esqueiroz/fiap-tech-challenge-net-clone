using Microsoft.AspNetCore.Mvc;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Obter;

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

        public RegionalController(IAdicionarRegionalUseCase adicionarRegionalUseCase,
            IAlterarRegionalUseCase alterarRegionalUseCase,
            IObterRegionalUseCase obterRegionalUseCase,
            IListarRegionalUseCase listarRegionalUseCase)
        {
            _adicionarRegionalUseCase = adicionarRegionalUseCase;
            _alterarRegionalUseCase = alterarRegionalUseCase;
            _obterRegionalUseCase = obterRegionalUseCase;
            _listarRegionalUseCase = listarRegionalUseCase;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                return Ok(_obterRegionalUseCase.ObterPorId(new ObterRegionalDto
                {
                    Id = id
                }));
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

        [HttpPost]
        public IActionResult Post(AdicionarRegionalDto adicionarRegionalDto)
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
        public IActionResult Put(AlterarRegionalDto alterarRegionalDto)
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



    }
}
