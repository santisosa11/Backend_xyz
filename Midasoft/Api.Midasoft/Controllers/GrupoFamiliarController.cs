using Core.Midasoft.Models;
using Infrastructure.Midasoft.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Midasoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoFamiliarController : ControllerBase
    {
        private readonly GrupoFamiliarRespository _repository;

        public GrupoFamiliarController(GrupoFamiliarRespository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoFamiliar>>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
