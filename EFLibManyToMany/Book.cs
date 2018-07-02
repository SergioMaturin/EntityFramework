using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lib3
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Book() { Authors = new List<Author>(); }

    }
}
