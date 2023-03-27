namespace Infrastructure.Filters
{
    public class AtlasResult<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public string InfoMessage { get; set; }
        public int DbAccessCount { get; set; }
    }
}