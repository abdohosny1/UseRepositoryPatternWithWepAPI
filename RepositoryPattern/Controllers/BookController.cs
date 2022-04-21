using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoistoryPatternWith.Core.consts;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;

        public BookController(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var allBook=  await _bookRepository.GetAll();
            return Ok(allBook);
        }

        [HttpGet("GetbyName")]
        public IActionResult GetbyName()
        {

            var findBook =  _bookRepository.Find(e=>e.Title=="action");
            if(findBook == null)
            {
                return NotFound();
            }
            return Ok(findBook);
        }

        [HttpGet("GetbyNameInclude")]
        public IActionResult GetbyNameInclude()
        {

            var findBook = _bookRepository.Find(e => e.Title == "action",new [] {"Author"});
            if (findBook == null)
            {
                return NotFound();
            }
            return Ok(findBook);
        }

        [HttpGet("GetbyAll")]
        public IActionResult GetbyAll()
        {

            var findBook = _bookRepository.FindAll(e => e.Title == "action", new[] { "Author" });
            if (findBook == null)
            {
                return NotFound();
            }
            return Ok(findBook);
        }


        [HttpGet("GetbyOrder")]
        public IActionResult GetbyOrder()
        {

            var findBook = _bookRepository.FindAll(e => e.AuthorId==1, null,null,b=>b.Id,OrderBy.Descending);
            if (findBook == null)
            {
                return NotFound();
            }
            return Ok(findBook);
        }


        [HttpPost("Addone")]
        public IActionResult Addone()
        {

            var res = _bookRepository.Add(new Book { Title = "test", AuthorId = 2 });
            return Ok(res);
        }
    }
}
