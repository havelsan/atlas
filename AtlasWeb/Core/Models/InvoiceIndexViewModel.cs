using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class InvoiceIndexViewModel
    {
        public string Message
        {
            get;
            set;
        }

        public DateTime BaslangicTarihi
        {
            get;
            set;
        }

        public DateTime BitisTarihi
        {
            get;
            set;
        }
    }
}