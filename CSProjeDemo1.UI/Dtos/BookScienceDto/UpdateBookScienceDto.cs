namespace CSProjeDemo1.UI.Dtos.BookScienceDto
{
    public class UpdateBookScienceDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public Status Status { get; set; }

        public string Field { get; set; }
    }
}
