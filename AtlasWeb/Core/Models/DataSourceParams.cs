namespace Core.Models
{
    public class DataSourceParams
    {
        public string Filter { get; set; }
        public string Sort { get; set; }
        public string Group { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string Select { get; set; }
        public string SearchValue { get; set; }
        public string SearchOperation { get; set; }
        public string SearchExpr { get; set; }
    }
}
