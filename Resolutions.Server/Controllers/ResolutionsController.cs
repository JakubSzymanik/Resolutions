using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Resolutions.Server.Model;
using Resolutions.Server.Services;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Resolutions.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ResolutionsController : ControllerBase
    {
        UserManager<AppUser> _userManager;
        IResolutionsService _resolutionService;

        public ResolutionsController(UserManager<AppUser> userManager, IResolutionsService resolutionService)
        {
            _userManager = userManager;
            _resolutionService = resolutionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResolutionDTO>>> GetUserResolutions
            ([FromBody][Required][EmailAddress] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) { return BadRequest("User with this email does not exist!"); }

            var resolutions = await _resolutionService.GetUserResolutions(user);
            if(resolutions == null) { return StatusCode(StatusCodes.Status500InternalServerError); }

            return Ok(resolutions.Select(v => new ResolutionDTO() { Name = v.Name, Id = v.Id})); //MAPPER
        }

        [HttpPost]
        public async Task<ActionResult> CreateResolution
            (ResolutionCreateDTO resolution)
        {
            var user = await _userManager.FindByEmailAsync(resolution.UserEmail);
            if (user == null) 
                return BadRequest("User with this email does not exist");

            var nameExists = await _resolutionService.UserResolutionExists(user, resolution.Name);
            if (nameExists)
                return BadRequest("User alredy has a resolution with this name");

            var createdResolution = await _resolutionService.CreateResolution(resolution, user);
            var createdResolutionDTO = new ResolutionDTO() { Id = createdResolution.Id, Name = createdResolution.Name }; //MAPPER
            return CreatedAtAction(nameof(GetResolution), new { id = createdResolution.Id }, createdResolution);
        }

        [HttpGet] 
        public async Task<ActionResult<ResolutionDTO>> GetResolution(int id)
        {
            var resolution = await _resolutionService.GetResolutionByID(id);
            if (resolution == null) return BadRequest("Resolution with this id does not exist");
            return new ResolutionDTO() { Name = resolution.Name }; //MAPPER
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteResolution(int id)
        {
            int result = await _resolutionService.DeleteResolution(id);
            if (result > 0) return Ok();
            else return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditResolution(ResolutionDTO resolutionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resolution = new Resolution() { Id = resolutionDTO.Id, Name = resolutionDTO.Name }; //MAPPER
            var newResolution = await _resolutionService.EditResolution(resolution);
            if (newResolution == null)
                return BadRequest("Resolution does not exist");

            return Ok();
        }
    }
}
