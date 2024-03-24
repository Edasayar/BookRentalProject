namespace CSProjeDemo1.UI.Dtos.BookHistoryDto
{
  
    public class ListBookHistoryDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }
        public Status Status { get; set; }
        public string HistoricalPeriod { get; set; }
    }
}
