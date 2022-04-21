using RepoistoryPatternWith.Core;
using RepoistoryPatternWith.Core.Model;
using RepoistoryPatternWith.Core.Repository;
using RepoistoryPatternWith.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<Author> Authors { get; private set; }

      //  public IBaseRepository<Book> Books { get; private set; }
        public BookRepository Books { get; private set; }

        IBooksRepository IUnitOfWork.Books => throw new NotImplementedException();

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
           // Books = new BaseRepository<Book>(_context);
            Books = new BookRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
