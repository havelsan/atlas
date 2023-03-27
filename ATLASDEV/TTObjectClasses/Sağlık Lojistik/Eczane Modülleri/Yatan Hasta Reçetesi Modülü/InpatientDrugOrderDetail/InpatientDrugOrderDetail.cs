
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// İlaç Direktifi Uygulamaları
    /// </summary>
    public  partial class InpatientDrugOrderDetail : DrugOrderDetail
    {
        protected void PreTransition_Supply2Apply()
        {
            // From State : Supply   To State : Apply
#region PreTransition_Supply2Apply
            
            Eligible = false;

#endregion PreTransition_Supply2Apply
        }

        protected void PostTransition_Supply2Apply()
        {
            // From State : Supply   To State : Apply
#region PostTransition_Supply2Apply
            
            
            InpatientDrugOrderDetail inpatientDrugOrderDetail = this;
            Guid guidInpatientDrugOrder = inpatientDrugOrderDetail.DrugOrder.ObjectID;
            IList myPatientRestDose = inpatientDrugOrderDetail.ObjectContext.QueryObjects("PATIENTRESTDOSE","DRUGORDER = '" + guidInpatientDrugOrder.ToString()+ "'");
            double totalDose = 0 ;
            double newTotalDose = 0 ;
            
            if (myPatientRestDose.Count == 1 )
            {
                foreach (PatientRestDoseDetail patientRestDoseDetail in ((PatientRestDose)myPatientRestDose[0]).PatientRestDoseDetails)
                {
                    totalDose += (double)patientRestDoseDetail.Dose ;
                }

                newTotalDose = totalDose + (double)inpatientDrugOrderDetail.Amount;
                
                if (((PatientRestDose)myPatientRestDose[0]).TotalDose >= newTotalDose)
                {
                    PatientRestDoseDetail newPatientRestDoseDetail = new PatientRestDoseDetail(inpatientDrugOrderDetail.ObjectContext);
                    newPatientRestDoseDetail.DrugOrderDetail = inpatientDrugOrderDetail;
                    newPatientRestDoseDetail.Dose = inpatientDrugOrderDetail.Amount;
                    newPatientRestDoseDetail.PatientRestDose = ((PatientRestDose)myPatientRestDose[0]);
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(985));
                }
            }
            bool presComp = true ;
            foreach(InpatientDrugOrder presDrugOrder in ((InpatientDrugOrder)inpatientDrugOrderDetail.DrugOrder).InpatientPrescription.InpatientDrugOrders)
            {
                if(presDrugOrder.CurrentStateDefID != InpatientDrugOrder.States.Completed)
                {
                    presComp = false ;
                    break;
                }
            }
            if (presComp)
            {
               ((InpatientDrugOrder)inpatientDrugOrderDetail.DrugOrder).InpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Completed ;  
            }

#endregion PostTransition_Supply2Apply
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientDrugOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InpatientDrugOrderDetail.States.Supply && toState == InpatientDrugOrderDetail.States.Apply)
                PreTransition_Supply2Apply();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientDrugOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InpatientDrugOrderDetail.States.Supply && toState == InpatientDrugOrderDetail.States.Apply)
                PostTransition_Supply2Apply();
        }

    }
}