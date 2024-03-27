﻿namespace CSProjeDemo1.UI.Dtos.BookNovelDto
{
    public class CreateBookNovelDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public Status Status { get; set; }
     

        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
    }
}
