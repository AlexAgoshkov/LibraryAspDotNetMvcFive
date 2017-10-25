using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryOnAspDotNetMvcFive.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<SupplyState> SupplyStates { get; set; }
        public DbSet<ReturnState> ReturnStates { get; set; }
    }
}