using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;
using static TTObjectClasses.InPatientTreatmentClinicApplication;
using Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel;
using System.ComponentModel;
using Core.Models;
using TTInstanceManagement;
using System.Collections;

namespace Core.Models
{
    public class ErrorWatcherFormViewModel
    {
        public string UserID;
        public string WorkStationName;
        public string Description;
        public DateTime ErrorDate;
    }

}