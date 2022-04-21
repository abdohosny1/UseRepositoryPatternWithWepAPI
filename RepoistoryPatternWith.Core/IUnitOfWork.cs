using RepoistoryPatternWith.Core.Model;
using RepoistoryPatternWith.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.Core
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        // IBaseRepository<Book> Books { get; }

        IBooksRepository Books { get; }


        int Complete();

    }
}
