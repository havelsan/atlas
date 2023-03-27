using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class LogisticWorkListViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StockActionId { get; set; }
        public string TIFId { get; set; }
        public Int32 WorkListCount { get; set; }
        public string StateType { get; set; }
        public List<StockActionWorkListItemModel> stockactionlist { get; set; }
        public List<TTObjectClasses.MenuDefinition> menulist { get; set; }
        public List<WorkListItem> workListItems { get; set; }
        public List<WorkListItem> selectedWorkListItems { get; set; }
        public bool PartialCancel { get; set; }
        public bool EHUWait { get; set; }
        public bool IsEmergencyMaterial { get; set; }
    }

    public class StockActionWorkListItemModel
    {
        public string ObjectID { get; set; }
        public Int32 StockActionID { get; set; }
        public string Store { get; set; }
        public string DestinationStore { get; set; }
        public string StockactionName { get; set; }
        public string TransactionDate { get; set; }
        public string StateName { get; set; }
        public string StateFormName { get; set; }
        public string PatientName { get; set; }
        public WorkListResultColorEnum colorEnum { get; set; }
        public bool IsEmergencyMaterial { get; set; }
    }

    public class WorkListItem
    {
        public string ObjectDefName { get; set; }
        public string ObjectDefId { get; set; }
    }
    public enum WorkListResultColorEnum
    {
        red = 0,
        white = 1
    }
}