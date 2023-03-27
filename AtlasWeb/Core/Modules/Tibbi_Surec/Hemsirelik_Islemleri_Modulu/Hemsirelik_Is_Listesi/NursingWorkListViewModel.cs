using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace Core.Models
{
    public partial class NursingWorkListViewModel
    {
        public OutputResource output
        {
            get;
            set;
        }

        public OutputDrugOrderDetail output_drugOrderDetails
        {
            get;
            set;
        }
        public List<PatientItem> patients
        {
            get;
            set;
        }
        public List<StatusItem> statusList
        {
            get;
            set;
        }

        public bool toolOption
        {
            get;
            set;
        }

        public OutputCaseOFNeedDrugOrder output_caseOfNeedDrugOrder
        {
            get;
            set;
        }

        public string ksMaterialNote { get; set; }
        public bool pharmcyOpen { get; set; }
    }
    public class OutputResource
    {
        public List<Resource> resources
        {
            get;
            set;
        }

        public DateTime startDate
        {
            get;
            set;
        }
        public DateTime endDate
        {
            get;
            set;
        }
    }

    public class OutputDrugOrderDetail
    {
        public List<DrugOrderDetailOutputItem> drugOrderDetails
        {
            get;
            set;
        }
    }


    public class OutputCaseOFNeedDrugOrder
    {
        public List<CostomDrugOrder> caseOfNeedDrugOrders
        {
            get;
            set;
        }
    }

    public class CostomDrugOrder
    {
        public string objectId { get; set; }
        public string PatientName { get; set; }
        public string DrugName { get; set; }

        public string DrugBarcode { get; set; }
        public string MasterResourceName { get; set; }

        public string DoseAmount { get; set; }

        public DateTime PlannedDateTime { get; set; }
    }






    public class InputFor_Get_DrugOrderDetails
    {
        public DateTime start_Time
        {
            get;
            set;
        }
        public DateTime end_Time
        {
            get;
            set;
        }

        public List<Guid> MasterResourcesList
        {
            get;
            set;
        }

        public int typeID { get; set; }
        public bool justMyPatient { get; set; }
    }

    public class DrugOrderDetailOutputItem
    {
        public Guid id
        {
            get;
            set;
        }
        public Guid stateDefID
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }

        public OrderTypeEnum typeId
        {
            get;
            set;
        }

        public string typeName { get; set; }

        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string statusName
        {
            get;
            set;
        }

        public DateTime periodStartTime
        {
            get;
            set;
        } //ana orderin başlama zamanı

        public bool? isChanged
        {
            get;
            set;
        } //takvim üzerinden değişiklik yapıldı mı

        public string doctorDescription
        {
            get;
            set;
        }

        public bool allDay
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string StateID
        {
            get;
            set;
        }

        public string PatientFullName
        {
            get;
            set;
        }
        public string MasterResourceName
        {
            get;
            set;
        }
        public string BackColorName { get; set; }
    }

    public class InputFor_StateUpdateForSelecetedItem
    {
        public List<Guid> DrugOrderDetails
        {
            get;
            set;
        }
    }


    public class InputFor_UnnotifiedBaseTreatmentMaterialToUTS
    {
        public List<Guid> ResourceIds
        {
            get;
            set;
        }
    }

    public class PatientItem
    {
        public Guid ObjectID
        {
            get;
            set;
        }
        public string PatientFullName
        {
            get;
            set;
        }
        public string PatientUniqueRefNo
        {
            get;
            set;
        }
    }
    public class StatusItem
    {
        public Guid StateID
        {
            get;
            set;
        }
        public string StatusItemName
        {
            get;
            set;
        }

        public int TypeID { get; set; }
    }





}