namespace CasitaAPI.ViewModels
{
    public class TListVM
    {
        public int TransactionTypeId { get; set; } 
        public string Name { get; set; }
        public Guid FinantialId { get; set; }
        public decimal? AmountSpent { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<HistoryVM> Transactions {  get; set; }
    }
}
