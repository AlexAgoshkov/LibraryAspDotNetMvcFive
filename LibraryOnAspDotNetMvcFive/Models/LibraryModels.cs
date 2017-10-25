using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOnAspDotNetMvcFive.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string Author { get; set; }

        public string Year { get; set; }

        public int? ReaderId { get; set; }

        public int? SupplyStateId { get; set; }

        public int? ReturnStateId { get; set; }

        public Reader Reader { get; set; }

        public SupplyState SupplyState { get; set; }

        public ReturnState ReturnState { get; set; }
    }

    public class Reader
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Addres { get; set; }

        public string Phone { get; set; }

        public ICollection<Book> Books { get; set; }

        public Reader()
        {
            Books = new List<Book>();
        }
    }

    public class SupplyState
    {
        public int Id { get; set; }

        public string IssueStatus { get; set; }

        public ICollection<Book> Books { get; set; }

        public SupplyState()
        {
            Books = new List<Book>();
        }
    }

    public class ReturnState
    {
        public int Id { get; set; }

        public string RetState { get; set; }

        public ICollection<Book> Books { get; set; }

        public ReturnState()
        {
            Books = new List<Book>();
        }
    }


}