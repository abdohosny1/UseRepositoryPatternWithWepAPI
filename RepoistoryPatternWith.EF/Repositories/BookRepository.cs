using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepoistoryPatternWith.Core.consts;
using RepoistoryPatternWith.Core.Model;
using RepoistoryPatternWith.Core.Repository;

namespace RepoistoryPatternWith.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public IEnumerable<Book> SpecialBooks()
        {
            throw new NotImplementedException();
        }
    }
}
