using System;
using Microsoft.AspNetCore.Mvc;
using API.Repositories.Artist.AddArtist;
using API.Models;


namespace API.Controllers.Artist
{


	[Route("api.multitracks.com/artist")]
	[ApiController]
	public class AddArtistController : ControllerBase
	{



		private readonly IAddArtistRepository _addartistRepository;

		public AddArtistController(IAddArtistRepository addartistRepository)
		{
			_addartistRepository = addartistRepository;
		}





		[HttpPost("add")]
		public IActionResult AddArtist([FromBody] AddArtistModel request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				try
				{
					_addartistRepository.AddArtist(request.Title, request.Biography, request.ImageURL, request.HeroURL);

					return Ok("Successfully added an artist");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return BadRequest(ex);
				}

			}
			
		}




	}

	 

}
