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
    public partial class DrugCorrectionViewModel
    {
      
    }
    
    public class InputFor_getPatientInfo
    {
        public string stockActionID
        {
            get;
            set;
        }
    }

    public class InputFor_getPatientInfo_FromWristband
    {
        public string subEpisodeID
        {
            get;
            set;
        }
    }

    public class InputFor_ApplyTheDrugOrderDetail
    {
        public DrugOrderInfo drugOrderInfo
        {
            get;
            set;
        }
    }

    public class OutputFor_ApplyTheDrugOrderDetail
    {
        public bool processCompleted
        {
            get;
            set;
        }

        public string resultMessage
        {
            get;
            set;
        }

        public DrugOrderInfo updatedDrugOrder
        {
            get;
            set;
        }

    }

    public class PatientInfo
    {
        public string patientObjectID
        {
            get;
            set;
        }

        public string patientRefNo
        {
            get;
            set;
        }
        public string patientName
        {
            get;
            set;
        }
        
        public string inpatientClinicName
        {
            get;
            set;
        }

        public List<DrugOrderInfo> DrugOrderInfoList
        {
            get;
            set;
        }
        

        public string physicalStateClinic
        {
            get;
            set;
        }
        public string roomGroup
        {
            get;
            set;
        }
        public string room
        {
            get;
            set;
        }
        public string bed
        {
            get;
            set;
        }
        public string admissionDoctor
        {
            get;
            set;
        }


    }

    public class DrugOrderInfo
    {
        public string objectID { get; set; }
        public string stateDefID { get; set; }
        public string MaterialName { get; set; }
        public string MaterialBarcode { get; set; }
        public string Amount { get; set; }
        public int DrugCounter { get; set; }
        public DateTime OrderPlannedDatetime { get; set; }
        public string DrugUsageType { get; set; }
        public string ExpirationDatetime { get; set; }
        public bool IsItInTheTimeInterval { get; set; }
        public bool drugType { get; set; }
        public bool drugDone { get; set; }
    }

}