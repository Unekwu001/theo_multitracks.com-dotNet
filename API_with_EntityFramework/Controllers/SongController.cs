using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API_with_EntityFramework.Controllers
{
    [Route("api.multitracks.com/song/")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongServices _songService;

        public SongController(SongServices songService)
        {
            _songService = songService;
        }





        [HttpGet("list")]
        public async Task<IActionResult> GetSongs([FromQuery]GetAllSongsDto getAllSongsDto)
        {
            try
            {
                if (getAllSongsDto.PageSize <= 0 || getAllSongsDto.PageNumber <= 0)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input, Please provide a valid page size or page number greater than 0"));
                }

                var pagedSongs = await _songService.GetAllSongsAsync(getAllSongsDto);
                if (pagedSongs.Any())
                {
                    return Ok(ApiResponse.Success(pagedSongs));
                }
                else
                {
                    return NotFound(ApiResponse.Failed("No songs found."));
                }
              
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed("An error occured " + ModelState, $"{ex}"));
            }
        }








    }
        
}
