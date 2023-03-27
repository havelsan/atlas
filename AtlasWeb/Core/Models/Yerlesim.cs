namespace Core.Models
{
    public class Yerlesim
    {
        public int Id
        {
            get;
            set;
        }

        public int ? ParentId
        {
            get;
            set;
        }

        public string YerlesimAdi
        {
            get;
            set;
        }

        public bool AltYerlesimleriVar
        {
            get;
            set;
        }
    }
}