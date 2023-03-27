using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class StockActionDTO
    {
        public Guid? StockActionObjectId { get; set; }
        public string OperationNumber { get; set; }
        public DateTime TicketDate { get; set; }
        public string TicketNumber { get; set; }
        public Guid MainStoreId { get; set; }
        public string MainStore { get; set; }
        public Guid? BudgetType { get; set; }
        public int RecordType { get; set; }
        public Guid CompanyId { get; set; }
        public string Company { get; set; }
        public Guid CompanyFromId { get; set; }
        public string CompanyFrom { get; set; }
        public int SupplyType { get; set; }
        public int BuyMethod { get; set; }
        public DateTime? TenderDate { get; set; }
        public string TenderNumber { get; set; }
        public DateTime? ControlDate { get; set; }
        public string ControlNumber { get; set; }
        public DateTime? BreederDocumentDate { get; set; }
        public string BreederDocumentNumber { get; set; }
        public Guid? Deliverer { get; set; }
        public string DelivererName { get; set; }
        public Guid? TakenBy { get; set; }
        public string TakenByName { get; set; }
        public bool PatientOnly { get; set; }
        public string PatientFullName { get; set; }
        public string Description { get; set; }
        public int ReceiptNumber { get; set; }
        public int OperationTicketNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsFormReadOnly { get; set; }
        public MaterialDTO[] MaterialList { get; set; }
        public MKYS_EMalzemeGrupEnum? MaterialGroup { get; set; }
        public Guid? InPatientPhysicianApplication { get; set; }
        public bool SendToMKYS { get; set; }
        public string MKYSPassword { get; set; }
        public bool IsFromMKYS { get; set; }
    }
}
