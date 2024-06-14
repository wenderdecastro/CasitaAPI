
using CasitaAPI.Models;

namespace CasitaAPI.ViewModels
{
    public class HistoryVM
    {

        public int Month { get; set; }
        public int Year { get; set; }

        public List<Transaction> Items { get; set; }
    }
}
