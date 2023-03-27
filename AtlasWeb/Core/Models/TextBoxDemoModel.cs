using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class TextBoxDemoModel
    {
        public string TekMetin
        {
            get;
            set;
        }

        public string CokSatirliMetin
        {
            get;
            set;
        }

        public string SeciliNesne
        {
            get;
            set;
        }

        public object SeciliTree
        {
            get;
            set;
        }
    }
}