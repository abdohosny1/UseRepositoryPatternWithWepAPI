using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.Core.Model
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(150),Required]
        public string Title { get; set; }


        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
