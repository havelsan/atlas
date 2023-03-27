namespace Infrastructure.Models
{
    public class ValidationConfig
    {
        public string Type
        {
            get;
            set;
        }

        public int Min
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}