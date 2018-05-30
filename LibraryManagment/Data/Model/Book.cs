using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Book
    {
        [Key]
        public int ID { get; set; }        
        public string Name { get; set; }
        public string Version { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}

