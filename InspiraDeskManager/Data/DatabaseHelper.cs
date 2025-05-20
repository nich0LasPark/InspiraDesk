using System.Collections.Generic;
using InspiraQuotesManager.Models;

namespace InspiraQuotesManager.Data
{
    public class DatabaseHelper
    {
        private List<Quote> quotes = new List<Quote>();
        private int nextId = 1;

        public List<Quote> GetAllQuotes()
        {
            return new List<Quote>(quotes); // Return a copy
        }

        public void AddQuote(Quote quote)
        {
            quote.Id = nextId++;
            quotes.Insert(0, quote); // Insert at top
        }

        public void UpdateQuote(Quote updated)
        {
            var idx = quotes.FindIndex(q => q.Id == updated.Id);
            if (idx >= 0)
                quotes[idx] = updated;
        }

        public void DeleteQuote(int id)
        {
            quotes.RemoveAll(q => q.Id == id);
        }
    }
}
