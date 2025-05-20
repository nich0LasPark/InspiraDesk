namespace InspiraQuotesManager.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string QuoteText { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; } // Added to track which user created the quote
    }
}
