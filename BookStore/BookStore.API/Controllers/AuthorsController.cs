using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Services;
using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.ResourceParameters;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controllers
{
  [ApiController]
  [Route("api/authors")]
  [Produces("application/json","application/xml")]  // this make the swagger to show application/json as select by defualt in response media type
  //[Authorize(Roles = "Administrator")]
  //[Authorize]
  public class AuthorsController : ControllerBase
  {
    private readonly IBookStoreRepository _bookstoreRepository;
    private readonly IMapper _mapper;  //install AUTOMAPPER and create PROFILE file to handle the mapping
    public IConfiguration Configuration { get; }
    public AuthorsController(IBookStoreRepository bookstoreRepository,
        IMapper mapper,
        IConfiguration configuration)
    {
      _bookstoreRepository = bookstoreRepository ??
          throw new ArgumentNullException(nameof(bookstoreRepository));
      _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));

      Configuration = configuration;
    }

    //http://localhost:12000/api/authors?maincategory=Rum&searchquery=Nancy
    //http://localhost:12000/api/authors?maincategory=rum
    //http://localhost:12000/api/authors?searchtype=nancy
    //http://localhost:12000/api/authors
    [HttpGet]
    [HttpHead]
    public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters) //Use FROMQUERY when dealing with complex types
    {
      var authorsFromRepo = _bookstoreRepository.GetAuthors(authorsResourceParameters);
      return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }
    // OR
   /* [HttpGet]
    [HttpHead]
    public ActionResult<IEnumerable<AuthorDto>> GetAuthors(string mainCategory, string searchQuery)
    {
      var authorsFromRepo = _bookstoreRepository.GetAuthors(new AuthorsResourceParameters { MainCategory = mainCategory, SearchQuery = searchQuery });
      return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }*/


    //http://localhost:12000/api/authors/da2fd609-d754-4feb-8acd-c4f9ff13ba96
    [HttpGet("{authorId}", Name = "GetAuthor")]  //"GetAuthor" is used when a resource is created using HttoPost.
    public IActionResult GetAuthor(Guid authorId)
    {
      var authorFromRepo = _bookstoreRepository.GetAuthor(authorId);

      if (authorFromRepo == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
    }

    [HttpPost]
    public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
    {
      var authorEntity = _mapper.Map<Entities.Author>(author);

      _bookstoreRepository.AddAuthor(authorEntity);

      _bookstoreRepository.Save();

      var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

      return CreatedAtRoute("GetAuthor",
                             new { authorId = authorToReturn.Id },
                             authorToReturn);
    }

    [HttpOptions]
    public IActionResult GetAuthorsOptions()
    {
      Response.Headers.Add("Allow", "GET,OPTIONS,POST");
      return Ok();
    }

    [HttpDelete("{authorId}")]
    public ActionResult DeleteAuthor(Guid authorId)
    {
      var authorFromRepo = _bookstoreRepository.GetAuthor(authorId);

      if (authorFromRepo == null)
      {
        return NotFound();
      }

      _bookstoreRepository.DeleteAuthor(authorFromRepo);

      _bookstoreRepository.Save();

      return NoContent();
    }

    //BASKAR: Currently you can update only author's lastname  
    [HttpPatch("{authorId}")]
    public IActionResult UpdateAuthor(Guid authorId,AuthorForUpdateDto course)
    {
      if (!_bookstoreRepository.AuthorExists(authorId))
      {
        return NotFound();
      }

      var authorFromRepoforUpdate = _bookstoreRepository.GetAuthor(authorId);

      if (authorFromRepoforUpdate == null)
      {
        return NotFound();
      }

      authorFromRepoforUpdate.LastName = course.LastName;
     // _mapper.Map(course, authorFromRepoforUpdate);

      _bookstoreRepository.UpdateAuthor(authorFromRepoforUpdate);

      _bookstoreRepository.Save();

      return NoContent();
    }


    

  }
}