using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resolutions.Server.Model;
using Resolutions.Server.Services;

namespace Resolutions.Server.Controllers
{
    //całość authorize na admina
    [ApiController]
    [Route("api/constants/[action]")]
    public class BussinessConfigurationConstantsController : ControllerBase
    {
        IBussinessConfigurationConstantsService _constantsService;

        public BussinessConfigurationConstantsController(IBussinessConfigurationConstantsService constantsService)
        {
            _constantsService = constantsService;
        }

        [HttpGet]
        public async Task<ActionResult<BussinessConfigurationConstant>> Get()
        {
            return Ok(await _constantsService.GetConstants());
        }

        [HttpPost]
        public async Task<ActionResult<BussinessConfigurationConstant>> Create(string name, int value)
        {
            try
            {
                var configConstant = await _constantsService.CreateConstant(name, value);
                return Ok(configConstant);
            } catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BussinessConfigurationConstant>> Update(string name, int value)
        {
            try
            {
                var configConstant = await _constantsService.UpdateConstant(name, value);
                return Ok(configConstant);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string name)
        {
            await _constantsService.DeleteConstant(name);
            return Ok();
        }
    }
}
