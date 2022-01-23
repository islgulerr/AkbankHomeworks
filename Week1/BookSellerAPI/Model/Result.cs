namespace BookSellerAPI.Model
{
    public class Result
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public List<Book>? BookList { get; set; }
    }
}
