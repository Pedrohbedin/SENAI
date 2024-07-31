namespace minimalAPIMongo.ViewModel
{
    public class OrderViewModel
    {
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public List<string>? ProductId { get; set; }
        public string? ClientId { get; set; }
    }
}
