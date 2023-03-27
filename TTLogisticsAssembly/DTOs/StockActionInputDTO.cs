using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class StockActionInputDTO
    {
        public Guid StoreId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TIFNumber { get; set; }
        public string OperationNumber { get; set; }
        public string BillNumber { get; set; }
        public Guid? BudgetType { get; set; }
        public int? State { get; set; }
        public string ReceiptNumber { get; set; }
        public Guid? SupplierId { get; set; }
        public string Supplier { get; set; }
        public Guid? AccountancyId { get; set; }
        public string Accountancy { get; set; }
        public Guid? Material { get; set; }
        public string PatientProtocolNumber { get; set; }
        public string StockHareketId { get; set; }
        public Guid? InPatientPhysicianApplication { get; set; }
        public bool? PatientSpecial { get; set; }
    }
}
