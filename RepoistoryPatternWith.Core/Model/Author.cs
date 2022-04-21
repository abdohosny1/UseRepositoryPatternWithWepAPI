using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.Core.Model
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(150),Required]
        public string Name { get; set; }
    }
}
