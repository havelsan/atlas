using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class StockActionDataDTO
    {
        public Guid StockActionObjectDefID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public string StockActionID { get; set; }
        public string Store { get; set; }
        public string DestinationStore { get; set; }
        public string CurrentStateDefID { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionDate { get; set; }
        public string PatientNameSurname { get; set; }
        public string PatientProtocolNumber { get; set; }
        public string TIFNumber { get; set; }
        public string State { get; set; }
    }
}
