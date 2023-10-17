﻿namespace WebAPIBooks.DTOs
{
    public class BooksFilterDto
    {
        public string Title { get; set; }
        public IEnumerable<string> AuthorNames { get; set; }
        public int SkipNrOfElements { get; set; } = 0;
        public int TakeNrOfElements { get; set; } = 10;

    }
}
