using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class MKYSRequestDTO
    {
        public Guid StockActionId { get; set; }
        public string MKYSPwd { get; set; }
        public int ReceiptNumber { get; set; }
    }
}
