
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
    /// İlaç Direktifi
    /// </summary>
    public  partial class InpatientDrugOrder : DrugOrder
    {
        public partial class GetDrugsToInPatientsForDoctorNameReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetKScheduleDrugsForDoctorNameReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetKScheduleDrugsForDrugNameReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInPatientAmountForStatisticReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDrugsToInPatientsForDrugNameReportQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            return;

#endregion PostInsert
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PreTransition_New2Cancelled
            
            

            ExternalPharmacyDistributionTerm openTerm = null;
            IList openterms = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(ObjectContext);
            if (openterms.Count > 0)
            {
                openTerm = (ExternalPharmacyDistributionTerm)openterms[0];
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(919));
            }
            
            if(InpatientPrescription.ExternalPharmacy != null)
            {
                ExternalPharmacyPrescriptionTransaction externalPharmacyPrescriptionTransaction = new ExternalPharmacyPrescriptionTransaction (ObjectContext);
                externalPharmacyPrescriptionTransaction.ExternalPharmacy = InpatientPrescription.ExternalPharmacy ;
                externalPharmacyPrescriptionTransaction.Prescription = (Prescription)InpatientPrescription ;
                externalPharmacyPrescriptionTransaction.Price = ((double)Material.CurrentPrice * PackageAmount) * -1;
                externalPharmacyPrescriptionTransaction.TransactionDate = DateTime.Now;
                externalPharmacyPrescriptionTransaction.DistributionTerm = openTerm;
                DrugOrder drugOrder = (DrugOrder)ObjectContext.GetObject((Guid)DrugOrderID, "DRUGORDER");
                drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
            }
            


#endregion PreTransition_New2Cancelled
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                base.OnConstruct();
                if(this is InpatientDrugOrder)
                    CurrentStateDefID = InpatientDrugOrder.States.New;
                if(Amount == null)
                    Amount = 0 ;
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientDrugOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InpatientDrugOrder.States.New && toState == InpatientDrugOrder.States.Cancelled)
                PreTransition_New2Cancelled();
        }

    }
}