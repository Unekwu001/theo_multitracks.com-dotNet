using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API_with_EntityFramework.Controllers
{
    [Route("api.multitracks.com/artist/")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly ArtistServices _artistService;
        public ArtistController(ArtistServices artistService)
        {
            _artistService = artistService;
        }

         


        [HttpPost("add")]
        public async Task<IActionResult> AddArtist([FromBody] AddArtistDto addArtistDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input"));
                }
                var addArtist = await _artistService.AddArtistAsync(addArtistDto);
                if (addArtist != null)
                {
                    return Ok(ApiResponse.Success("Artist was added successfully"));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed(ModelState));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(ModelState, $"{ex}"));
            }
        }




        [HttpGet("search")]
        public async Task<IActionResult> SearchArtist([FromQuery] SearchArtistDto searchArtistDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input"));
                }
                var addArtist = await _artistService.SearchArtistByNameAsync(searchArtistDto);
                if (addArtist.Any())
                { 
                    return Ok(ApiResponse.Success(addArtist));
                }
                else
                {
                    return NotFound(ApiResponse.Failed("No Artist matches your search. Could you try another name ?"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(ModelState, $"{ex}"));
            }
        }






    }
}
