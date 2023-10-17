namespace WebAPIBooks.Helpers
{
    public class PaginatedResultsModel<TResultType> where TResultType : class
    {
        public PaginatedResultsModel(IEnumerable<TResultType> records, int count)
        {
            Records = records;
            RecordsCount = count;
        }
        public IEnumerable<TResultType> Records { get; set; }
        public int RecordsCount { get; set; }
    }
}
