using CSProjeDemo1.Entitys;

namespace ProjeDemo1.API.Dtos
{
    public class BorrowBookRequest
    {
        public int BookId { get; set; }
        public Member Member { get; set; }
        public BookHistory Book { get; set; }
    }
}
