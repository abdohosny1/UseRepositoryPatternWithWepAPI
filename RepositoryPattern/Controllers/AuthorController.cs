using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoistoryPatternWith.Core;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
       // private readonly IBaseRepository<Author> _authorRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public AuthorController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        //public AuthorController(IBaseRepository<Author> authorRepository)
        //{
        //    _authorRepository = authorRepository;
        //}

        [HttpGet]

        public IActionResult getById(int id)
        {
            var res= _iUnitOfWork.Authors.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
