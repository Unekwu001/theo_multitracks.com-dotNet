using Microsoft.AspNetCore.Mvc;
using API.Repositories.Song;
using System.Data;
using System.Text.Json;

namespace API.Controllers.Song
{

    [Route("api.multitracks.com/song")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        private readonly ISongsRepository _songsRepository;


        public SongsController(ISongsRepository songsRepository)
        {
            _songsRepository = songsRepository;
        }




        [HttpGet("list")]
        public IActionResult ListSongs(int pageNumber, int pageSize)
        {
            try
            {
                int totalItems = _songsRepository.GetTotalSongCount();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                string dataTable = _songsRepository.GetSongs(pageNumber, pageSize);

                var response = new
                {
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    Songs = dataTable
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // You may want to throw or handle the exception in a different way
                return StatusCode(500, "An error occurred");
            }
        }

























    }



}
