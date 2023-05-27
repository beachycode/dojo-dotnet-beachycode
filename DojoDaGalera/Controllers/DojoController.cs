using DojoDaGalera.Classes;
using DojoDaGalera.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DojoDaGalera.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DojoController : ControllerBase
    {
        private readonly IDojoRepository _dojoRepository;

        public DojoController(IDojoRepository dojoRepository)
        {
            _dojoRepository = dojoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Dojo>> ListarDados()
        {
            return await _dojoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Dojo> ObterDado(string id)
        {
            return await _dojoRepository.Get(id);
        }

        [HttpPost]
        public async Task<Dojo> SalvarDado(Dojo dojo)
        {
            return await _dojoRepository.Add(dojo);
        }

        [HttpPut("{id}")]
        public async Task<Dojo> AtualizarDado(string id, [FromBody] Dojo dojo)
        {
            return await _dojoRepository.Update(id, dojo);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletarDado(string id)
        {
            return await _dojoRepository.Delete(id);
        }
    }
}